using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _estimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService estimonialService, IMapper mapper)
        {
            _estimonialService = estimonialService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _mapper.Map<List<ResultTestimonialDto>>(_estimonialService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            _estimonialService.TAdd(new Testimonial()
            {
                Comment = createTestimonialDto.Comment,
                ImageUrl = createTestimonialDto.ImageUrl,
                Name = createTestimonialDto.Name,
                Status = createTestimonialDto.Status,
                Title = createTestimonialDto.Title
            });
            return Ok("Başarılı bir şekilde oluşturuldu");
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonial)
        {
            _estimonialService.TUpdate(new Testimonial()
            {
                TestimonialID = updateTestimonial.TestimonialID,
                Comment = updateTestimonial.Comment,
                ImageUrl = updateTestimonial.ImageUrl,
                Name = updateTestimonial.Name,
                Status = updateTestimonial.Status,
                Title = updateTestimonial.Title
               
            });
            return Ok("Başarılı bir şekilde güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _estimonialService.TGetById(id);
            _estimonialService.TDelete(value);
            return Ok("Başarılı bir şekilde silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _estimonialService.TGetById(id);
            return Ok(value);
        }

    }
}
