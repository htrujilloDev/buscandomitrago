using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coctel.BackEnd.Services
{
    public interface ISearchService
    {
        Task<Object> GstSearchByName(string name);
    }
}
