using AutoMapper;
using BoxTI.Challenge.CovidTracking.Models.Dtos;
using BoxTI.Challenge.CovidTracking.Models.Entities;
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
    public class CovidController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly ICovidRepository _covidRepository;

		public CovidController(IMapper mapper, ICovidRepository covidRepository)
		{
			_mapper = mapper;
			_covidRepository = covidRepository;
		}

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var model = await _covidRepository.GetAll();
                var results = _mapper.Map<CovidDto[]>(model);
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
                var model = await _covidRepository.GetById(dto.Id);
                var results = _mapper.Map<CovidDto>(model);
                return Ok(results);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Query failed");
            }
        }

        [HttpPost("country")]
        public async Task<IActionResult> GetByCountryName(GetIdDto dto)
        {
            try
            {
                var model = await _covidRepository.GetById(dto.Id);
                var results = _mapper.Map<CovidDto>(model);
                return Ok(results);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Query failed");
            }
        }

        [HttpPost("post")]
        public async Task<IActionResult> Post(CovidDto model)
        {
            try
            {
                var results = _mapper.Map<Covid>(model);
                _covidRepository.Add(results);

                if (await _covidRepository.SaveChangesAsync())
                {
                    return Created($"/api/country/{results.Id}", _mapper.Map<CovidDto>(model));
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Query failed: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpPut("put")]
        public async Task<IActionResult> Put(CovidDto model)
        {
            try
            {
                var covid = await _covidRepository.GetById(model.Id);

                _mapper.Map(model, covid);

                if (covid == null)
                    return NotFound();

                _covidRepository.Update(covid);

                if (await _covidRepository.SaveChangesAsync())
                {
                    return Created($"/api/covid/{model.Id}", _mapper.Map<CountryDto>(model));
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
                var model = await _covidRepository.GetById(dto.Id);

                if (model == null)
                    return NotFound();

                _covidRepository.Delete(model);

                if (await _covidRepository.SaveChangesAsync())
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
