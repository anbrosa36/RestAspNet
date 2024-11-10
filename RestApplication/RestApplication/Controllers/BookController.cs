using Microsoft.AspNetCore.Mvc;
using RestApplication.Business;
using RestApplication.Data.VO;
using RestApplication.Hypermedia.Filters;
using RestApplication.Model;

namespace RestApplication.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BookController : ControllerBase
    {
        private IBookBusiness _bookBusiness;

        public BookController(IBookBusiness bookBusiness)
        {
            _bookBusiness = bookBusiness;
        }

        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_bookBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetById(int id)
        {
            var book = _bookBusiness.FindById(id);
            if (book == null) return NotFound();
            
            return Ok(book);
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Create([FromBody] BookVO book)
        {
            if (book == null) return BadRequest();
            return Ok(_bookBusiness.Create(book));
        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Update([FromBody] BookVO book)
        {
            if (book == null) return BadRequest();
            return Ok(_bookBusiness.Update(book));
            
        }

        [HttpDelete("{id}")]
        public IActionResult  Delete(int id)
        {
            _bookBusiness.Delete(id);
            return NoContent();
        }
    }
}
