using AutoMapper;
using BoxTI.Challenge.CovidTracking.Models.Dtos;
using BoxTI.Challenge.CovidTracking.Models.Entities;
using BoxTI.Challenge.CovidTracking.Models.ViewModel;
using BoxTI.Challenge.CovidTracking.Services.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	public class RegionController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IRegionRepository _regionRepository;

		public RegionController(IMapper mapper, IRegionRepository regionRepository)
		{
			_mapper = mapper;
			_regionRepository = regionRepository;
		}

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var model = await _regionRepository.GetAll();
                var results = _mapper.Map<RegionViewModel[]>(model); // Add o IEnumerable quando o mapeamento receber como parametro uma lista
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Query failed {ex.Message}");
            }
        }

        [HttpPost("getById")]
        public async Task<IActionResult> GetById(GetIdDto dto)
        {
            try
            {
                var model = await _regionRepository.GetById(dto.Id);
                var results = _mapper.Map<RegionViewModel>(model);
                return Ok(results);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Query failed");
            }
        }

        [HttpPost("getByCountryName")]
        public async Task<IActionResult> GetByCountry(GetByNameDto dto)
        {
            try
            {
                var model = await _regionRepository.GetByCountryName(dto.Name);
                var result = _mapper.Map<RegionViewModel>(model);
                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Query failed");
            }
        }

        [HttpPost("post")]
        public async Task<IActionResult> Post(RegionDto model)
        {
            try
            {
                var results = _mapper.Map<Region>(model);
                _regionRepository.Add(results);

                if (await _regionRepository.SaveChangesAsync())
                {
                    return Created($"/api/region/{results.Id}", _mapper.Map<RegionViewModel>(model));
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Query failed: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpPut("put")]
        public async Task<IActionResult> Put(RegionDto model)
        {
            try
            {
                var region = await _regionRepository.GetById(model.Id);

                _mapper.Map(model, region);

                if (region == null)
                    return NotFound();

                _regionRepository.Update(region);

                if (await _regionRepository.SaveChangesAsync())
                {
                    return Created($"/api/region/{model.Id}", _mapper.Map<RegionViewModel>(model));
                }
            return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Query failed" + ex);
            }

        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(GetIdDto dto)
        {
            try
            {
                var model = await _regionRepository.GetById(dto.Id);

                if (model == null)
                    return NotFound();

                _regionRepository.Delete(model);

                if (await _regionRepository.SaveChangesAsync())
                {
                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex + "Query failed");
            }
        }
    }
}
