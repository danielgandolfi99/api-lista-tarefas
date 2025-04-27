using Microsoft.AspNetCore.Mvc;
using ListaTarefasApi.Data;
using ListaTarefasApi.Models;

namespace ListaTarefasApi.Controllers
{
    [ApiController]
    [Route("tarefas")]
    public class TarefasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TarefasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ListaTarefas()
        {
            var tarefas = await _context.ListaTarefas();
            return Ok(tarefas);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionaTarefa([FromBody] Tarefa tarefa)
        {
            await _context.AdicionaTarefa(tarefa.titulo, tarefa.descricao);
            return Ok(new { mensagem = "Tarefa adicionada com sucesso!" });
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> EditaTarefa(int id, [FromBody] Tarefa tarefa)
        {
            await _context.EditaTarefa(id, tarefa.titulo, tarefa.descricao);
            return Ok(new { mensagem = "Tarefa atualizada com sucesso!" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTarefa(int id)
        {
            await _context.RemoveTarefa(id);
            return Ok(new { mensagem = "Tarefa removida com sucesso!" });
        }

        [HttpPatch("{id}/concluir")]
        public async Task<IActionResult> ConcluiTarefa(int id)
        {
            await _context.ConcluiTarefa(id);
            return Ok(new { mensagem = "Tarefa concluída com sucesso!" });
        }

    }
}
