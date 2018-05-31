using Motivate_jQuery.Domain;
using Motivate_jQuery.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motivate_jQuery.Services.Interfaces
{
    public interface IMovieService
    {
        IEnumerable<Movies> ReadAll();
        IEnumerable<Movies> ReadRand();
        Movies ReadById(int Id);
        int Insert(MovieAddRequest model);
        void UpdateById(MovieUpdateRequest model);
        void DeleteById(int Id);

    }
}
