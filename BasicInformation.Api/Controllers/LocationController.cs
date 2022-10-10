using BasicInformation.Application.Features;
using BasicInformation.Application.InputModel;
using BasicInformation.Application.Mapper.Location;
using BasicInformation.Application.Responses.Base;
using BasicInformation.Application.Validator;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BasicInformation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet]
        //[Route("[action]")]
        //public async Task<IActionResult> GetAll()
        //{
        //    var locations = await _mediator.Send(new GetAllLocation.Query());
        //    return Ok(locations);
        //}

        [HttpPost]
        [Route("[action]/{Id}")]
        public async Task<IActionResult> Update(long Id, LocationInputModel input)
        {
            var command = LocationMapper.Mapper.Map<UpdateLocation.Command>(input);
            command.Id = Id;
            var locations = await _mediator.Send(command);
            return Ok(locations);
        }
 
        [HttpPost]
        [Route("[action]/{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var locations = await _mediator.Send(new DeleteLocation.Command() { Id = Id });
            return Ok(locations);
        }

        [NonAction]
        private async Task<IActionResult> AddLocation(LocationInputModel input)
        {
            var validation = new BaseLocationInputModelValidator().Validate(input);

            if (!validation.IsValid)
                return BadRequest(new HasError(validation));

            var addCommand = LocationMapper.Mapper.Map<AddLocation.Command>(input);
            var response = await _mediator.Send(addCommand);
            return Ok(response);
        }
 
        // 1 => استان	  
        #region Province
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddProvince(/*long OrganizationId,*/ BaseLocationInputModel input)
        {
            var model = LocationModelMapper.Mapper.Map<LocationInputModel>(input);
            model.ParentId = 0; // is default

            return Ok(await AddLocation(model));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllProvince()
        {
            var locations = await _mediator.Send(new GetAllProvince.Query());
            return Ok(locations);
        }
        #endregion

        // 2 => شهرستان	  
        #region County
        [HttpPost]
        [Route("[action]/{ProvinceId}")]
        public async Task<IActionResult> AddCounty(long ProvinceId, BaseLocationInputModel input)
        {
            var model = LocationModelMapper.Mapper.Map<LocationInputModel>(input);
            model.ParentId = ProvinceId;

            return Ok(await AddLocation(model));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllCounty()
        {
            var locations = await _mediator.Send(new GetAllCounty.Query());
            return Ok(locations);
        }
        #endregion

        // 3 => بخش	  
        #region District
        [HttpPost]
        [Route("[action]/{CountyId}")]
        public async Task<IActionResult> AddDistrict(long CountyId, BaseLocationInputModel input)
        {
            var model = LocationModelMapper.Mapper.Map<LocationInputModel>(input);
            model.ParentId = CountyId;

            return Ok(await AddLocation(model));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllDistrict()
        {
            var locations = await _mediator.Send(new GetAllDistrict.Query());
            return Ok(locations);
        }
        #endregion

        // 4 => دهستان	  
        #region RuralDistrict
        [HttpPost]
        [Route("[action]/{DistrictId}")]
        public async Task<IActionResult> AddRuralDistrict(long DistrictId, BaseLocationInputModel input)
        {
            var model = LocationModelMapper.Mapper.Map<LocationInputModel>(input);
            model.ParentId = DistrictId;

            return Ok(await AddLocation(model));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllRuralDistrict()
        {
            var locations = await _mediator.Send(new GetAllRuralDistrict.Query());
            return Ok(locations);
        }
        #endregion

        // 5 => شهر	  
        #region City
        [HttpPost]
        [Route("[action]/{DistrictId}")]
        public async Task<IActionResult> AddCity(long DistrictId, BaseLocationInputModel input)
        {
            var model = LocationModelMapper.Mapper.Map<LocationInputModel>(input);
            model.ParentId = DistrictId;

            return Ok(await AddLocation(model));
        }

        [HttpGet]
        [Route("[action]/{ProvinceId}")]
        public async Task<IActionResult> GetAllCity(long ProvinceId)
        {
            var locations = await _mediator.Send(new GetAllCity.Query() { ProvinceId = ProvinceId });
            return Ok(locations);
        }
        #endregion

        // 6 => روستا-آبادی	  
        #region Village
        [HttpPost]
        [Route("[action]/{RuralDistrictsId}")]
        public async Task<IActionResult> AddVillage(long RuralDistrictsId, BaseLocationInputModel input)
        {
            var model = LocationModelMapper.Mapper.Map<LocationInputModel>(input);
            model.ParentId = RuralDistrictsId;

            return Ok(await AddLocation(model));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllVillage()
        {
            var locations = await _mediator.Send(new GetAllVillage.Query());
            return Ok(locations);
        }
        #endregion

    }
}