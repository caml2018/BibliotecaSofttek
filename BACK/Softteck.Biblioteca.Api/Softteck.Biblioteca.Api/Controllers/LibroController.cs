using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Softtek.Biblioteca.Application.Commands.AutorCommand;
using Softtek.Biblioteca.Application.Commands.ConfiguracionCommand;
using Softtek.Biblioteca.Application.Commands.LibroCommand;
using Softtek.Biblioteca.Application.Queries.AutorQueries;
using Softtek.Biblioteca.Application.Queries.ConfiguracionQueries;
using Softtek.Biblioteca.Application.Queries.LibroQueries;
using Softtek.Biblioteca.Domain.Entities;
using Softtek.Biblioteca.Domain.Entities.DTOs;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Softtek.Biblioteca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroWrite _libroWrite;
        private readonly ILibroQuery _libroQuery;
        private readonly IMapper _mapper;
        private readonly IConfiguracionWrite _configuracionWrite;
        private readonly IConfiguracionQuery _congiguracionQuery;

        public LibroController(ILibroWrite libroWrite,
            ILibroQuery libroQuery,
            IMapper mapper,
            IConfiguracionWrite configuracionWrite,
            IConfiguracionQuery configuracionQuery
            )
        {
            _libroWrite = libroWrite;
            _libroQuery = libroQuery;
            _mapper = mapper;
            _configuracionWrite= configuracionWrite;
            _congiguracionQuery= configuracionQuery;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(new { exito = 1, mensaje = "Success", data = await _libroQuery.GetAll()} );
        }
        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(new { exito = 1, mensaje = "Success", data = _libroQuery.Get(id)});
        }

        [HttpGet]
        [Route("GetAllmaximoDeLibros")]
        public async Task<IActionResult> GetAllmaximoDeLibros()
        {
            return Ok(new { exito = 1, mensaje = "Success", data = _congiguracionQuery.GetAll()});
        }



        [HttpPost]
        [Route("maximoDeLibros")]
        public async Task<IActionResult> maximoDeLibros(Configuracion configuracion )
        {
            return Ok(new { exito = 1, mensaje = "Success", data = _configuracionWrite.add(configuracion) });
        }

        [HttpPost]
        public async Task<IActionResult> Add(LibroDto libroDto)
        {
            try
            {
                var auxLibro = _mapper.Map<Libro>(libroDto);
                var response = await _libroWrite.add(auxLibro);
                return Ok(new { exito = 1, mensaje = "Success", data = response} );
            }
            catch (System.Exception ex)
            {
                return Ok(new { exito = 0, mensaje = "Error", data = ex.Message });
            }
        }
    }
}
