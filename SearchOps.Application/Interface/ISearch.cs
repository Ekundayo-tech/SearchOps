using Nest;
using SearchOps.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchOps.Application.Interface
{
    public interface ISearch
    {
        Task<Property> SearchProperty(string searchText);
        Task<Mgmt> SearchMgmt(string searchText);
        Task<Property> SearchProprtyByMarket(string market);
          
    }
}
