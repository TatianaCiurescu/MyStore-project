using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Domain.Entities;
using MyStore.Models;
using MyStore.Services;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly IMapper mapper;
        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            this.orderService = orderService;
            this.mapper = mapper;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public ActionResult<IEnumerable<OrderModel>> Get([FromQuery] List<string> country, [FromQuery] List<string> city )
        {

            var allOrders = orderService.GetAll(country, city);
            var mappedOrders = mapper.Map<List<OrderModel>>(allOrders);

            return Ok(mappedOrders) ;
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        { 
            return "value";
        }
 

        // POST api/<OrdersController>
        [HttpPost]
        public IActionResult Post([FromBody] OrderModel model)
        {
          
            //model->domain object
            var order = mapper.Map<Order>(model);

            var addedItem = orderService.Add(order);

            //do a reverse mapping - Order->OrderModel
            return CreatedAtAction("Get", new { id = addedItem.Orderid },
                mapper.Map<OrderModel>(addedItem));
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(OrderModel))]
        public IActionResult Put(int id, [FromBody] OrderModel orderToUpdate)
        {
            if(id!= orderToUpdate.Orderid)
            {
                return BadRequest();
            }

            if (!orderService.Exists(id))
            {
                return NotFound();
            }

            orderService.UpdateOrder(orderToUpdate);
            return NoContent();
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!orderService.Exists(id))
            {
                return NotFound();
            }

            var deletedOrder = orderService.Delete(id);
            if (deletedOrder == orderService.Delete(id))
            {
                return UnprocessableEntity();
            }

            return NoContent();
        }
    }
}
