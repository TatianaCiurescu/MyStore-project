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
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        // GET: api/<CustomersController>
        [HttpGet]
        public ActionResult<IEnumerable<CustomerModel>> Get()
        {
            var customerList = customerService.GetAllCustomers();
            return Ok(customerList);
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public ActionResult<CustomerModel> GetCustomer(int id)
        {
            var customer = customerService.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(customer);
            }
        }

        // POST api/<CustomersController>
        [HttpPost]
        public IActionResult Post([FromBody] Customer newCustomer)
        {
            if (!ModelState.IsValid)
            {
                ///customerService.Add()
                ///
                return BadRequest();
            }
            var addedCustomer = customerService.AddCustomer(newCustomer);
            return CreatedAtAction("Get", new { id = addedCustomer.Custid }, addedCustomer);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type= typeof(CustomerModel))]
        public IActionResult Put(int id, [FromBody] CustomerModel customerToUpdate)
        {
            if (id!= customerToUpdate.Custid)
            {
                return BadRequest();
            }
            if(!customerService.Exists(id))
            {
                return NotFound();
            }

            customerService.UpdateCustomer(customerToUpdate);
            return NoContent();
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(!customerService.Exists(id))
            {
                return NotFound();
            }

            var isDeleted = customerService.Delete(id);

            if (isDeleted)
            {
                return UnprocessableEntity();
            }

            return NoContent();
        }
    }
}
