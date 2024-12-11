using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaAplicacaoMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        // Lista de tarefas fictícia
        private static List<TarefaViewModel> tarefas = new List<TarefaViewModel>
        {
            new TarefaViewModel
            {
                Id = 1,
                Titulo = "Tarefa 1",
                Categoria = "Trabalho",
                Descricao = "Descrição da tarefa 1",
                DataCriacao = DateTime.Now,
                DataExpiracao = DateTime.Now.AddDays(2),
                Prioridade = TipoPrioridadeEnum.Alta,
                Status = TipoStatusEnum.Pendente,
                FotoTarefa = null
            }
        };

        // GET: api/tarefas
        [HttpGet]
        public ActionResult<IEnumerable<TarefaViewModel>> GetTarefas()
        {
            return Ok(tarefas);
        }

        // GET: api/tarefas/5
        [HttpGet("{id}")]
        public ActionResult<TarefaViewModel> GetTarefa(int id)
        {
            var tarefa = tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa == null)
            {
                return NotFound();
            }
            return Ok(tarefa);
        }

        // POST: api/tarefas
        [HttpPost]
        public ActionResult<TarefaViewModel> PostTarefa([FromBody] TarefaViewModel tarefa)
        {
            if (tarefa == null)
            {
                return BadRequest();
            }

            tarefa.Id = tarefas.Max(t => t.Id) + 1; // Gerar Id único
            tarefas.Add(tarefa);

            return CreatedAtAction(nameof(GetTarefa), new { id = tarefa.Id }, tarefa);
        }

        // PUT: api/tarefas/5
        [HttpPut("{id}")]
        public ActionResult PutTarefa(int id, [FromBody] TarefaViewModel tarefa)
        {
            var tarefaExistente = tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefaExistente == null)
            {
                return NotFound();
            }

            tarefaExistente.Titulo = tarefa.Titulo;
            tarefaExistente.Categoria = tarefa.Categoria;
            tarefaExistente.Descricao = tarefa.Descricao;
            tarefaExistente.DataCriacao = tarefa.DataCriacao;
            tarefaExistente.DataExpiracao = tarefa.DataExpiracao;
            tarefaExistente.Prioridade = tarefa.Prioridade;
            tarefaExistente.Status = tarefa.Status;
            tarefaExistente.FotoTarefa = tarefa.FotoTarefa;

            return NoContent();
        }

        // DELETE: api/tarefas/5
        [HttpDelete("{id}")]
        public ActionResult DeleteTarefa(int id)
        {
            var tarefa = tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa == null)
            {
                return NotFound();
            }

            tarefas.Remove(tarefa);

            return NoContent();
        }
    }
}
