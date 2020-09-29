using TimeFutebol.Models;
using TimeFutebol.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        private TimeRepository _repository;
        public TimeController() {
            _repository = new TimeRepository();
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(_repository.ListarTodosTimes());
        }
      
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
           
        {
            var timeTitulos = _repository.BuscarTimePorId(id);
            if (timeTitulos == null) {
                return NotFound();
            }
            return Ok(timeTitulos);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Time timao)
        {
         
            _repository.InserirTime(timao);
            return Ok("Time criado com sucesso!");
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, Time timao) {
            if (string.IsNullOrEmpty(timao.nome))
            {
                return BadRequest("Nome do Time está em branco, favor preencher!");
            }


            return Ok("Categoria encontrada");
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id) {
            if (id>0)
            {
                return Ok("Categoria deletada com sucesso!");
            }
            return BadRequest("HAHA, o que já foi cadastrado nunca será deletado");
        }



    }

    
}
