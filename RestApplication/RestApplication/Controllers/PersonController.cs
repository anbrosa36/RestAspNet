using Microsoft.AspNetCore.Mvc;
using RestApplication.Model;
using RestApplication.Business;
using RestApplication.Data.VO;
using RestApplication.Hypermedia.Filters;

namespace RestApplication.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {
       
        private readonly ILogger<PersonController> _logger;
        private IPersonBusiness _personBusiness;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;
            _personBusiness= personBusiness;
        }

        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {

            return Ok(_personBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetById(int id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null) return NotFound();

            return Ok(person);
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Create([FromBody] PersonVO person) 
        {
            if (person == null) return BadRequest();
            return Ok(_personBusiness.Create(person));    
        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Update([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();
            return Ok(_personBusiness.Update(person));
        }

        [HttpDelete("{id}")]        
        public IActionResult Excluir(int id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}