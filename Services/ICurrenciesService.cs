using Cr_Interface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cr_Interface.Services
{
    public interface ICurrenciesService
    {
        Task<IEnumerable<Asset>> GetTopCurrencies(int amountOfCurrencies);
    }
}
