using FuncionariosRestAPI.Data;
using FuncionariosRestAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FuncionariosRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly IAccessLayer accessLayer;

        public FuncionariosController(IAccessLayer accessLayer)
        {
            this.accessLayer = accessLayer;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IEnumerable<Funcionario>> GetAsync()
        {
            return await accessLayer.ReadAsync();
        }

        [HttpGet("{id:int}", Name = "GetFuncionario")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Funcionario>> GetById(int id)
        {
            var funcionario = await accessLayer.GetByIdAsync(id);
            if (funcionario == null)
            {
                return NotFound($"O recurso solicitado para o ID: {id} não foi encontrado!");
            }
            return Ok(funcionario);
        }

        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public async Task<ActionResult<Funcionario>> Post([FromBody] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                await accessLayer.CreateAsync(funcionario);
                return CreatedAtRoute("GetFuncionario", new { id = funcionario.ID }, funcionario);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put(int id, [FromBody] Funcionario funcionario)
        {
            funcionario.ID = id;
            if (ModelState.IsValid)
            {
                await accessLayer.UpdateAsync(funcionario);
                return NoContent();
            }
            return NotFound($"O recurso solicitado para o ID: {id} não foi encontrado!");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleted = await accessLayer.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound($"O recurso solicitado para o ID {id} não foi encontrado!");
            }

            return NoContent();
        }
    }
}