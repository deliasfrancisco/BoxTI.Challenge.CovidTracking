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
	public class CountryController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly ICountryRepository _countryRepository;

		public CountryController(IMapper mapper, ICountryRepository countryRepository)
		{
			_mapper = mapper;
			_countryRepository = countryRepository;
		}

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var model = await _countryRepository.GetAll(); // Lista de array
                var results = _mapper.Map<CountryDto[]>(model); // Add o IEnumerable quando o mapeamento receber como parametro uma lista
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
                var model = await _countryRepository.GetById(dto.Id);
                var results = _mapper.Map<CountryDto>(model);
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
                var model = await _countryRepository.GetByCountryName(dto.Name);
                var result = _mapper.Map<CountryDto>(model);
                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Query failed");
            }
        }

        [HttpPost("post")]
        public async Task<IActionResult> Post(CountryDto model)
        {
            try
            {
                var results = _mapper.Map<Country>(model);
                _countryRepository.Add(results);

                if (await _countryRepository.SaveChangesAsync())
                {
                    return Created($"/api/country/{results.Id}", _mapper.Map<CountryDto>(model));
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Query failed: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpPut("put")]
        public async Task<IActionResult> Put(CountryDto model)
        {
            try
            {
                var country = await _countryRepository.GetById(model.Id);

                _mapper.Map(model, country);

                if (country == null)
                    return NotFound();

                _countryRepository.Update(country);

                if (await _countryRepository.SaveChangesAsync())
                {
                    return Created($"/api/country/{model.Id}", _mapper.Map<CountryDto>(model));
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
                var model = await _countryRepository.GetById(dto.Id);

                if (model == null)
                    return NotFound();

                _countryRepository.Delete(model);

                if (await _countryRepository.SaveChangesAsync())
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
