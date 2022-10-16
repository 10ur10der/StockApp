using Business;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Core.Utilities.Results;
using System;
using IResult = Core.Utilities.Results.IResult;

namespace StockAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private IStockService _stockService;
        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }


        [HttpGet("variantcode")]
        public IActionResult GetVariantCode(string variantcode)
        {
            var result = _stockService.GetByVariantCode(variantcode);

            if (result.Status)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("productcode")]
        public IActionResult GetStockCode(string productcode)
        {
            var result = _stockService.GetByProductCode(productcode);

            if (result.Status)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost]
        public IActionResult Add(Stock stock)
        {
            IResult result;
            try
            {
                result = _stockService.Add(stock);

                if (result.Status)
                {
                    return Ok(result.Message);
                }
                return BadRequest(result.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("variantcode/quantity")]
        public IActionResult UpdateStock(string variantcode,int quantity)
        {
            IResult result;
            try
            {
                var stock = _stockService.GetByVariantCode(variantcode);

                if (stock.Data == null)
                {
                    return BadRequest("Varianta ait stock bilgisi bulunamadı");
                }

                stock.Data.Quantity = quantity;
                stock.Data.UpdateTime = DateTime.Now;

                result = _stockService.Update(stock.Data);

                if (result.Status)
                {
                    return Ok(result.Message);
                }
                return BadRequest(result.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
