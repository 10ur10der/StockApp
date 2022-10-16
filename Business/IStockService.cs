using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IStockService
    {
        IDataResult<Stock> GetByVariantCode(string stockNo);
        IDataResult<Stock> GetByProductCode(string stockNo);
        IDataResult<List<Stock>> GetList();
        IResult Add(Stock stock);
        IResult Delete(Stock stock);
        IResult Update(Stock stock);

    }
}
