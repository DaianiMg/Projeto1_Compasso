using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Projeto1.Controllers.Models;
using Projeto1.Controllers.Models.Date;
using Projeto1.Controllers.Models.Date.CidadeDtos;
using Projeto1.Controllers.Models.Date.ClienteDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Projeto1.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
       
        private CidadeContext _context;
        private IMapper _mapper;
        public ClienteController(CidadeContext context, IMapper mapper )
        {
            
            _context = context;
            _mapper = mapper;
           
        }
        
        [HttpPost]
        public async Task< IActionResult>  AdicionaCliente([FromBody] CreateClienteDtos clienteDto)
        {
            Cliente cliente = _mapper.Map<Cliente>(clienteDto);
            var httpClient = new HttpClient();
            var url = await httpClient.GetStringAsync("http://viacep.com.br/ws/" + clienteDto.Cep + "/json");

            var teste = JsonConvert.DeserializeObject<CepResponse>(url);

            //if (url.IsSuccessStatusCode)
            //{

            if (!string.IsNullOrEmpty(teste.logradouro))
            {
                cliente.Logradouro = teste.logradouro;
            }
            if (!string.IsNullOrEmpty(teste.logradouro))
            {
                cliente.Bairro = teste.bairro;
            }

            Cidade cidade = _context.Cidade.FirstOrDefault(cidade => cidade.Nome == teste.localidade && cidade.Estado == teste.uf);
            
         

            if (cidade != null)
            {
                cliente.CidadeId = cidade.Id;
                _context.Cliente.Add(cliente);
                _context.SaveChanges();
                return CreatedAtAction(nameof(RecuperaClientePorId), new { Id = cliente.Id }, cliente);


            }

            return NotFound();

            //Cliente cliente = _mapper.Map<Cliente>(clienteDto);
        }

        [HttpGet]
        public IActionResult RecuperaCliente()
        {
            var clienteDto = _mapper.Map<List<Cliente>, List<ReadClienteDtos>>(_context.Cliente.ToList());
            return Ok(clienteDto);
        }
        

        [HttpGet("{Id}")]
        public IActionResult RecuperaClientePorId(int id)
        {
            Cliente cliente = _context.Cliente.FirstOrDefault(cliente => cliente.Id == id);
            if (cliente != null)
            {
                //cliente.Cidade = _context.Cidade.FirstOrDefault(c => c.Id == cliente.CidadeId);
                ReadClienteDtos clienteDto = _mapper.Map<ReadClienteDtos>(cliente);

                return Ok(clienteDto);
            }
            return NotFound();
        }

        [HttpPut("{Id}")]
        public IActionResult AtualizaCliente(int id, [FromBody] UpdateClienteDtos clienteDto)
        {
            Cliente cliente = _context.Cliente.FirstOrDefault(cliente => cliente.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            _mapper.Map(clienteDto, cliente);

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeletaCliente(int id)
        {
            Cliente cliente = _context.Cliente.FirstOrDefault(cliente => cliente.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            _context.Remove(cliente);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
