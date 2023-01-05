using System.Collections.Generic;
using demoapp.BusinessServices.Interfaces;
using demoapp.BusinessEntities.Entities;
using demoapp.Contracts.DTO;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace demoapp.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdController : ControllerBase
    {
        IProdService _ProdService;
        private readonly IMapper _mapper;
        public ProdController(IProdService ProdService,IMapper mapper)
        {
            _ProdService = ProdService;
            _mapper = mapper;
        }

        // GET: api/Prod
        [HttpGet]
        public ActionResult<IEnumerable<Prod>> Get()
        {
            var ProdDTOs = _mapper.Map<IEnumerable<ProdDto>>(_ProdService.GetAll());
            return Ok(ProdDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<Prod> GetById(string id)
        {
            var ProdDTO = _mapper.Map<ProdDto>(_ProdService.Get(id));
            return Ok(ProdDTO);
        }

        [HttpPost]
        public ActionResult<Prod> Save(Prod Prod)
        {
            var ProdDTOs = _mapper.Map<ProdDto>(_ProdService.Save(Prod));
            return Ok(ProdDTOs);
        }

        [HttpPut("{id}")]
        public ActionResult<Prod> Update([FromRoute] string id, Prod Prod)
        {
            var ProdDTOs = _mapper.Map<ProdDto>(_ProdService.Update(id, Prod));
            return Ok(ProdDTOs);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete([FromRoute] string id)
        {
            bool res = _mapper.Map<bool>(_ProdService.Delete(id));
            if(res== false) return null;
            return Ok(res);

        }


    }
}
