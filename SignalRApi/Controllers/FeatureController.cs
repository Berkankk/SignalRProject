using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;
        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _mapper.Map<List<ResultFeatureDto>>(_featureService.TGetListAll());
            return Ok(values);

        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto featureDto)
        {
            _featureService.TAdd(new Feature()
            {
                Description1 = featureDto.Description1,
                Description2 = featureDto.Description2,
                Description3 = featureDto.Description3,
                Title1 = featureDto.Title1,
                Title2 = featureDto.Title2,
                Title3 = featureDto.Title3,
            });
            return Ok("Başarılı bir şekilde oluşturuldu");
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto featureDto)
        {

            _featureService.TUpdate(new Feature()
            {
                Description1 = featureDto.Description1,
                Description2 = featureDto.Description2,
                Description3 = featureDto.Description3,
                Title1 = featureDto.Title1,
                Title2 = featureDto.Title2,
                Title3 = featureDto.Title3,
                FeatureID = featureDto.FeatureID
            });
            return Ok("Başarılı bir şekilde güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var value = _featureService.TGetById(id);
            _featureService.TDelete(value);
            return Ok("Başarılı bir şekilde silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetFeature(int id)
        {
            var value = _featureService.TGetById(id);
            return Ok(value);
        }

    }
}
