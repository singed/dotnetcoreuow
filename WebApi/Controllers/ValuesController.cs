using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Northwind.DataAccess;
using Northwind.DataAccess.Models;
using WebApi.DataAccess;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly INorthwindUnitOfWork _unitOfWork;

        public ValuesController(INorthwindUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var list = _unitOfWork.Repository<Product>().Queryable().Include("Category").ToList().Take(2);
            return list;
        }


        // GET api/values/categories
        [HttpGet("categories")]
        public IEnumerable<Category> GetCategories()
        {
            var list = _unitOfWork.Repository<Category>().Queryable().ToList();
            return list;
        }


        // GET api/values/suppliers
        [HttpGet("suppliers")]
        public IEnumerable<Supplier> GetSuppliers()
        {
            var list = _unitOfWork.Repository<Supplier>().Queryable().ToList();
            return list;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            //return _unitOfWork.Repository<Category>().Queryable().FirstOrDefault(x => x.Id == id);
            return _unitOfWork.Repository<Category>().Find(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Category category)
        {
            _unitOfWork.Repository<Category>().Insert(category);
            _unitOfWork.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody] Category category)
        {
            _unitOfWork.Repository<Category>().Update(category);
            _unitOfWork.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _unitOfWork.Repository<Category>().Delete(id);
            _unitOfWork.SaveChanges();
        }
    }
}