using DatabaseConn.Adapter;
using DatabaseConn.Tools;
using Motivate_jQuery.Domain;
using Motivate_jQuery.Models.Requests;
using Motivate_jQuery.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Motivate_jQuery.Services
{
    public class MovieService : IMovieService
    {
        IBaseService _baseService;

        public MovieService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public IEnumerable<Movies> ReadAll()
        {
            return _baseService.SqlAdapter.LoadObject<Movies>(new DbCommandDef
            {
                DbCommandText = "dbo.Movies_SelectAll",
                DbCommandType = System.Data.CommandType.StoredProcedure
            });
        }

        public IEnumerable<Movies> ReadRand()
        {
            return _baseService.SqlAdapter.LoadObject<Movies>(new DbCommandDef
            {
                DbCommandText = "dbo.Movies_SelectRandom",
                DbCommandType = System.Data.CommandType.StoredProcedure
            });
        }

        public Movies ReadById(int id)
        {
            return _baseService.SqlAdapter.LoadObject<Movies>(new DbCommandDef
            {
                DbCommandText = "dbo.Movies_SelectById",
                DbCommandType = System.Data.CommandType.StoredProcedure,
                DbParameters = new SqlParameter[]
                {
                    new SqlParameter("@Id", id)
                }
            }).FirstOrDefault();
        }

        public void UpdateById(MovieUpdateRequest model)
        {
            _baseService.SqlAdapter.ExecuteQuery(new DbCommandDef
            {
                DbCommandText = "dbo.Movies_UpdateById",
                DbCommandType = System.Data.CommandType.StoredProcedure,
                DbParameters = new SqlParameter[]
                {
                    new SqlParameter("@Id", model.Id),
                    new SqlParameter("@Title", model.Title),
                    new SqlParameter("@Genre", model.Genre)
                }
            });
        }

        public int Insert(MovieAddRequest model)
        {
            SqlParameter id = SqlDbParameter.Instance.BuildParam("@Id", 0, System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Output);
            _baseService.SqlAdapter.ExecuteQuery(new DbCommandDef
            {
                DbCommandText = "dbo.Movies_Insert",
                DbCommandType = System.Data.CommandType.StoredProcedure,
                DbParameters = new SqlParameter[]
                {
                    new SqlParameter("@Title", model.Title),
                    new SqlParameter("@Genre", model.Genre),
                    id
                }
            });
            return id.Value.ToInt32();
        }

        public void DeleteById(int id)
        {
            _baseService.SqlAdapter.ExecuteQuery(new DbCommandDef
            {
                DbCommandText = "dbo.Movies_DeleteById",
                DbCommandType = System.Data.CommandType.StoredProcedure,
                DbParameters = new SqlParameter[]
                {
                    new SqlParameter("@Id", id)
                }
            });
        }
    }
}