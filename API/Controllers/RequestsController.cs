using API.Authentication;
using API.Dtos;
using API.Models;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestsRepository requestsRepository;
        private readonly IMapper mapper;

        public RequestsController(IRequestsRepository requestsRepository, IMapper mapper)
        {
            this.requestsRepository = requestsRepository;
            this.mapper = mapper;
        }

        // GET: api/<RequestsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestReadDto>>> GetAllRequestsAsync()
        {
            try
            {
                var request = await requestsRepository.GetAllAsync();
                var mappedmodel = mapper.Map<IEnumerable<RequestReadDto>>(request);
                return Ok(mappedmodel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = ex.Message });
            }
        }

        // GET api/<RequestsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestReadDto>> GetRequestById(int id)
        {
            try
            {
                var request = await requestsRepository.GetRequestAsync(id);
                return Ok(request);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = ex.Message });
            }
        }

        // POST api/<RequestsController>
        [HttpPost]
        public async Task<ActionResult> PostRequest(RequestCreateDto requestCreate)
        {
            try
            {
                var mappedmodel = mapper.Map<Request>(requestCreate);
                await requestsRepository.CreateRequestAsync(mappedmodel);
                await requestsRepository.SaveAsync();
                var createdReadModel = mapper.Map<RequestReadDto>(mappedmodel);
                return CreatedAtRoute(nameof(GetRequestById), new { createdReadModel.Id }, createdReadModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = ex.Message });
            }
        }

        // PUT api/<RequestsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] RequestCreateDto requestCreate)
        {
            try
            {
                var requestFromRepo = await requestsRepository.GetRequestAsync(id);
                if (requestFromRepo == null)
                {
                    return NotFound();
                }
                var mappeedModel = mapper.Map(requestCreate, requestFromRepo);
                await requestsRepository.SaveAsync();
                return Ok(mappeedModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = ex.Message });
            }
        }

        // DELETE api/<RequestsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var request = await requestsRepository.GetRequestAsync(id);
                if (request != null)
                {
                    await requestsRepository.RemoveRequestAsync(id);
                    await requestsRepository.SaveAsync();
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = ex.Message });
            }
        }
    }
}