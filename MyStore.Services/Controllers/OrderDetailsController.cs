using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Data.Services;
using MyStore.Domain.Entities;
using MyStore.Domain.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyStore.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailService orderDetailService;

        public OrderDetailsController(IOrderDetailService orderDetailService)
        {
            this.orderDetailService = orderDetailService;
        }


        // GET: api/<OrderDetailsController>
        [HttpGet]
        public ActionResult<IEnumerable<OrderDetailModel>> Get()
        {
            var detailsList = orderDetailService.GetAll();
            return Ok(detailsList);
        }

        // GET api/<OrderDetailsController>/5
        [HttpGet("{id}")]
        public ActionResult<OrderDetailModel> Get(int id)
        {
            var orderDetails = orderDetailService.GetById(id);
            if (orderDetails == null)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }

        // POST api/<OrderDetailsController>
        [HttpPost]
        public IActionResult Post([FromBody] OrderDetail newOrderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var addedDetails = orderDetailService.AddDetail(newOrderDetail);
            return CreatedAtAction("Get", new { id = addedDetails.Orderid }, addedDetails);
        }

        // PUT api/<OrderDetailsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDetailModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(OrderDetailModel))]
        public IActionResult Put(int id, [FromBody] OrderDetailModel modelToUpdate)
        {
            if(id!=modelToUpdate.Orderid)
            {
                return BadRequest();
            }
            if(!orderDetailService.Exists(id))
            {
                return NotFound();
            }

            orderDetailService.UpdateDetails(modelToUpdate);
            return NoContent();
        }

        // DELETE api/<OrderDetailsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(!orderDetailService.Exists(id))
            {
                return NotFound();
            }

            var isDeleted = orderDetailService.Delete(id);

            if(isDeleted)
            {
                return UnprocessableEntity();
            }
            return NoContent();
        }
    }
}
