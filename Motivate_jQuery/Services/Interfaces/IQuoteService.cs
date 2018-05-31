using Motivate_jQuery.Domain;
using Motivate_jQuery.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motivate_jQuery.Services.Interfaces
{
    public interface IQuoteService
    {
        IEnumerable<Quotes> ReadAll();
        IEnumerable<Quotes> ReadRand();
        Quotes ReadById(int Id);
        int Insert(QuoteAddRequest model);
        void DeleteById(int Id);
        void UpdateById(QuoteUpdateRequest model);
    }
}
