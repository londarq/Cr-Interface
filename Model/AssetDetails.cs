using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cr_Interface.Model
{
    public class AssetDetails
    {
        public double? CurrentPrice { get; set; }

        public double? TotalVolume { get; set; }

        public double? PriceChange24h { get; set; }
    }
}
