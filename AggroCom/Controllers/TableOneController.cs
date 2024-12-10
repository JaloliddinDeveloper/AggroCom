using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using System.Threading.Tasks;
using System;
using AggroCom.Models.Foundations.ProductOnes;
using AggroCom.Services.Foundations.TableOnes;

namespace AggroCom.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TableOneController:RESTFulController
    {
        private readonly ITableOneService tableOneService;

        public TableOneController(ITableOneService tableOneService)=>
            this.tableOneService = tableOneService;
        
        [HttpPost]
        public async ValueTask<ActionResult<TableOne>> PostTableOneAsync(TableOne TableOne)
        {
            try
            {
                TableOne addTableOne = new TableOne
                {
                    Id = TableOne.Id,
                    EkinTuri = TableOne.EkinTuri,
                    BegonaQarshi = TableOne.BegonaQarshi,
                    SarfMeyori=TableOne.SarfMeyori,
                    Cheklovlar=TableOne.Cheklovlar,
                    MavsumNechta=TableOne.MavsumNechta,
                    ProductOneId= TableOne.ProductOneId
                };

                return await this.tableOneService.AddTableOneAsync(addTableOne);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
