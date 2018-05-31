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
    public class QuoteService : IQuoteService
    {
        IBaseService _baseService;

        public QuoteService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public IEnumerable<Quotes> ReadAll()
        {
            return _baseService.SqlAdapter.LoadObject<Quotes>(new DbCommandDef
            {
                DbCommandText = "dbo.Quotes_SelectAll",
                DbCommandType = System.Data.CommandType.StoredProcedure
            });
        }

        public IEnumerable<Quotes> ReadRand()
        {
            return _baseService.SqlAdapter.LoadObject<Quotes>(new DbCommandDef
            {
                DbCommandText = "dbo.Quotes_SelectRandom",
                DbCommandType = System.Data.CommandType.StoredProcedure
            });
        }

        public Quotes ReadById(int id)
        {
            return _baseService.SqlAdapter.LoadObject<Quotes>(new DbCommandDef
            {
                DbCommandText = "dbo.Quotes_SelectById",
                DbCommandType = System.Data.CommandType.StoredProcedure,
                DbParameters = new SqlParameter[]
                {
                    new SqlParameter("@Id", id)
                }
            }).FirstOrDefault();
        }

        public void UpdateById(QuoteUpdateRequest model)
        {

        }

        public int Insert(QuoteAddRequest model)
        {
            SqlParameter id = SqlDbParameter.Instance.BuildParam("@Id", 0, System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Output);
            _baseService.SqlAdapter.ExecuteQuery(new DbCommandDef
            {
                DbCommandText = "dbo.Quotes_Insert",
                DbCommandType = System.Data.CommandType.StoredProcedure,
                DbParameters = new SqlParameter[]
                {
                    new SqlParameter("@Quote", model.Quote),
                    new SqlParameter("@Author", model.Author),
                    id
                }
            });
            return id.Value.ToInt32();
        }

        public void DeleteById(int id)
        {

        }
    }
}