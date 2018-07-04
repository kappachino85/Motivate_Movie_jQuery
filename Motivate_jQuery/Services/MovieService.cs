using Motivate_jQuery.Domain;
using Motivate_jQuery.Services.Interfaces;
using System;
using System.Collections.Generic;
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

        }
    }
}