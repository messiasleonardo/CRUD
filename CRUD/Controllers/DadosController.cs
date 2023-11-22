using CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DadosController : Controller
    {
        static readonly List<Customer>? _customers = new List<Customer>();
        [HttpGet]
        public List<Customer> GetCustomer()
        {
            return _customers.ToList(); 
        }
        [HttpPost]
        public bool InsertCustomer(Customer customer)
        {
            try
            {
                _customers.Add(customer);
                return true;
            }
            catch (Exception e)
            {
                
                return false;
            }
        }
        [HttpPut]
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                _customers.Remove(_customers.Where(x => x.Id == customer.Id).FirstOrDefault());
                _customers.Add(customer);
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }
        [HttpDelete("{idCustomer}")]
        public bool DeleteCustomer(int idCustomer)
        {
            try
            {
                _customers.Remove(_customers.Where(x=>x.Id == idCustomer).FirstOrDefault());
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
    }
}
