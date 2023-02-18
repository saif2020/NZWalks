using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("Regions")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRegionsAsync()
        {
            var regions = await regionRepository.GetAllAsync();

            // return DTO regions

            //var regionsDTO = new List<Models.DTO.Region>();
            //regions.ToList().ForEach(region =>
            //{
            //    var regionDTO = new Models.DTO.Region()
            //    {
            //        Id = region.Id,
            //        Name = region.Name,
            //        Code = region.Code,
            //        Area = region.Area,
            //        Lat = region.Lat,
            //        Long = region.Long,
            //        Population = region.Population
            //    };
            //    regionsDTO.Add(regionDTO); 

            //});
            var regionsDTO = mapper.Map<List<Models.DTO.Region>>(regions);
            return Ok(regionsDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await regionRepository.GetAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            var regionDTO = mapper.Map<Models.DTO.Region>(region);
            return Ok(regionDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(Models.DTO.AddRegionRequest addRegionRequest)
        {
            // convert DTO to Domain model
            var region = new Region()
            {
                Name = addRegionRequest.Name,
                Code = addRegionRequest.Code,
                Lat = addRegionRequest.Lat,
                Long = addRegionRequest.Long,
                Area = addRegionRequest.Area,
                Population = addRegionRequest.Population
            };
            //request respository
            region = await regionRepository.AddAsync(region);
            //convert Domain model to dto
            var regionDTO = new Models.DTO.Region()
            {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code,
                Lat = region.Lat,
                Long = region.Long,
                Area = region.Area,
                Population = region.Population
            };
            return CreatedAtAction(nameof(GetRegionAsync), new { Id = regionDTO.Id }, regionDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            bool success = await regionRepository.DeleteAsync(id);
            return success ? Ok(): NotFound();
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateRegionRequest updateRegionRequest)
        {
            var region = new Region()
            {
                Name = updateRegionRequest.Name,
                Code = updateRegionRequest.Code,
                Lat = updateRegionRequest.Lat,
                Long = updateRegionRequest.Long,
                Area = updateRegionRequest.Area,
                Population = updateRegionRequest.Population
            };
            var updatedRegion = await regionRepository.UpdateAsync(id, region);
            if (updatedRegion == null)
            {
                return NotFound();
            }
            var regionDTO = new Models.DTO.Region()
            {
                Id = updatedRegion.Id,
                Name = updatedRegion.Name,
                Code = updatedRegion.Code,
                Lat = updatedRegion.Lat,
                Long = updatedRegion.Long,
                Area = updatedRegion.Area,
                Population = updatedRegion.Population
            };
            return Ok(regionDTO);
        }
    }
}
