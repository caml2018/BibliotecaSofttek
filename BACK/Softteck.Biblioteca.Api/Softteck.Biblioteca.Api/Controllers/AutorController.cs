using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Softtek.Biblioteca.Application.Commands.AutorCommand;
using Softtek.Biblioteca.Application.Queries.AutorQueries;
using Softtek.Biblioteca.Application.Queries.LibroQueries;
using Softtek.Biblioteca.Domain.Entities;
using Softtek.Biblioteca.Domain.Entities.DTOs;
using System.Threading.Tasks;

namespace Softtek.Biblioteca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorWrite _autorWrite;
        private readonly IAutorQuery _autorQuery;
        private readonly IMapper _mapper;

        public AutorController(IAutorWrite autorWrite, IAutorQuery autorQuery, IMapper mapper)
        {
            _autorWrite = autorWrite;
            _autorQuery = autorQuery;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(new { exito = 1, mensaje = "Success", data = await _autorQuery.GetAll() });
        }
        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(new { exito = 1, mensaje = "Success", data = _autorQuery.Get(id)});
        }
        [HttpPost]
        public IActionResult Add(AutorDto autorDto)
        {
            try
            {
                return Ok(new { exito = 1, mensaje = "Success", data = _autorWrite.add(_mapper.Map<Autor>(autorDto)) });
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
            
        }
    }
}
