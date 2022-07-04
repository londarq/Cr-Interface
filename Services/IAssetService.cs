using Cr_Interface.Model;
using Cr_Interface.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cr_Interface.Services
{
    public interface IAssetService
    {
        Task<IEnumerable<PriceUWU>> GetAsset(string assetId);
    }
}
