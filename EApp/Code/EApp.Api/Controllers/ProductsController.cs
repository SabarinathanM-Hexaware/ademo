using System.Collections.Generic;
using EApp.BusinessServices.Interfaces;
using EApp.BusinessEntities.Entities;
using EApp.Contracts.DTO;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace EApp.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductsService _ProductsService;
        private readonly IMapper _mapper;
        public ProductsController(IProductsService ProductsService,IMapper mapper)
        {
            _ProductsService = ProductsService;
            _mapper = mapper;
        }

        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<Products>> Get()
        {
            var ProductsDTOs = _mapper.Map<IEnumerable<ProductsDto>>(_ProductsService.GetAll());
            return Ok(ProductsDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<Products> GetById(string id)
        {
            var ProductsDTO = _mapper.Map<ProductsDto>(_ProductsService.Get(id));
            return Ok(ProductsDTO);
        }

        [HttpPost]
        public ActionResult<Products> Save(Products Products)
        {
            var ProductsDTOs = _mapper.Map<ProductsDto>(_ProductsService.Save(Products));
            return Ok(ProductsDTOs);
        }

        [HttpPut("{id}")]
        public ActionResult<Products> Update([FromRoute] string id, Products Products)
        {
            var ProductsDTOs = _mapper.Map<ProductsDto>(_ProductsService.Update(id, Products));
            return Ok(ProductsDTOs);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete([FromRoute] string id)
        {
            bool res = _mapper.Map<bool>(_ProductsService.Delete(id));
            if(res== false) return null;
            return Ok(res);

        }


    }
}
