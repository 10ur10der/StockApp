using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.OrderResult
{
    public class SuccessStockResult : SuccessResult
    { 
        public int StcokNo { get; set; }
    }
}
