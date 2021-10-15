using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Projeto1.Controllers.Models;
using Projeto1.Controllers.Models.Date;
using Projeto1.Controllers.Models.Date.CidadeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Projeto1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CidadeController : ControllerBase
    {
        
        private CidadeContext _context;
        private IMapper _mapper;
        public CidadeController(CidadeContext context, IMapper mapper)
        {
           
            _context = context;
            _mapper = mapper;
        }
        
        [HttpPost]
        public IActionResult AdicionaCidade([FromBody] CreateCidadeDtos cidadeDto)
        {



            Cidade cidade = _mapper.Map<Cidade>(cidadeDto);
            _context.Cidade.Add(cidade);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaCidadePorId), new { id = cidade.Id }, cidade);
  
        }

        [HttpGet]
        public IActionResult RecuperaCidades()
        {
            var cidadeDto = _mapper.Map<List<Cidade>, List<ReadCidadeDtos>>(_context.Cidade.ToList());
            return Ok(cidadeDto);
        }

        [HttpGet("{Id}")]
        public IActionResult RecuperaCidadePorId(int id)
        {
            Cidade cidade = _context.Cidade.FirstOrDefault(cidade => cidade.Id == id);
            if (cidade != null)
            {
                ReadCidadeDtos cidadeDto = _mapper.Map<ReadCidadeDtos>(cidade);

                return Ok(cidadeDto);
            }
            return NotFound();
        }

        [HttpPut("{Id}")]
        public IActionResult AtualizaCidade(int id, [FromBody] UpdateCidadeDtos cidadeDto)
        {
            Cidade cidade = _context.Cidade.FirstOrDefault(cidade => cidade.Id == id);
            if (cidade == null)
            {
                return NotFound();
            }

            _mapper.Map(cidadeDto, cidade);

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeletaCidade(int id)
        {
            Cidade cidade = _context.Cidade.FirstOrDefault(cidade => cidade.Id == id);
            if (cidade == null)
            {
                return NotFound();
            }
            _context.Remove(cidade);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
