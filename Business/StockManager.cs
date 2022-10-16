using Core.Utilities.Results;
using DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.OrderResult;
using System.Collections;

namespace Business
{
    public class StockManager : IStockService
    {
        private IStockDal _stockDal;

        public StockManager(IStockDal stockDal)
        {
            _stockDal = stockDal;          
        }

        public IResult Add(Stock stock)
        {
            try
            {
                _stockDal.Add(stock);
                var result = new SuccessStockResult()
                {
                    StcokNo = stock.ID, 
                    Message = Messages.StockAdded,
                    
                };
                return result;
            }
            catch (Exception ex)
            {
                var result = new ErrorStockResult()
                {
                    StcokNo = stock.ID,
                    Message = ex.Message,

                };
                return result;
            }
           
        }

        public IResult Delete(Stock stock)
        {
            try
            {
                _stockDal.Delete(stock);
                var result = new SuccessStockResult()
                {
                    StcokNo = stock.ID,
                    Message = Messages.StockDeleted,

                };
                return result;
            }
            catch (Exception ex)
            {
                var result = new ErrorStockResult()
                {
                    StcokNo = stock.ID,
                    Message = ex.Message,

                };
                return result;
            }
            
        }

        public IDataResult<Stock> GetByVariantCode(string stockNo)
        {
            return new SuccessDataResult<Stock>(_stockDal.Get(filter: p => p.VariantCode == stockNo));
        }

        public IDataResult<Stock> GetByProductCode(string stockNo)
        {
            return new SuccessDataResult<Stock>(_stockDal.Get(filter: p => p.ProductCode == stockNo));
        }

        public IDataResult<List<Stock>> GetList()
        {
            return new SuccessDataResult<List<Stock>>(_stockDal.GetList().ToList());
        }


        public IResult Update(Stock stock)
        {
            try
            {
                _stockDal.Update(stock);
                var result = new SuccessStockResult()
                {
                    StcokNo = stock.ID,
                    Message = Messages.StockUpdated,
                };
                return result;
            }
            catch (Exception ex)
            {

                var result = new ErrorStockResult()
                {
                    StcokNo = stock.ID,
                    Message = ex.Message,

                };
                return result;
            }
          
           
        }
    }
}
