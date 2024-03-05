using Microsoft.AspNetCore.Mvc;
using WebApiFuncionario.Models;
using WebApiFuncionario.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiFuncionario.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FuncionarioController : ControllerBase
{
    private readonly FuncionarioService _funcionarioService;

    public FuncionarioController(FuncionarioService funcionarioService)
    {
        _funcionarioService = funcionarioService;
    }

    // GET: api/<FuncionarioController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var funcionarios = await _funcionarioService.GetFuncionarios();
        if (funcionarios != null)
        {
            return Ok(funcionarios);

        }
        return BadRequest();
    }

    // GET api/<FuncionarioController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetId(int id)
    {
        var funcionarioId = await _funcionarioService.GetFuncionariosById(id);
        return Ok(funcionarioId);


    }

    // POST api/<FuncionarioController>
    [HttpPost]
    public async Task<IActionResult> Create(Funcionario funcionario)
    {

        await _funcionarioService.CreateFuncionario(funcionario);
        return Ok("Funcionario cadastrado");
    }


    // PUT api/<FuncionarioController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFuncionario(int id, Funcionario funcionario)
    {
        try
        {
            if (id == funcionario.Id)
            {
                await _funcionarioService.UpdateFuncionario(funcionario);
                return Ok(funcionario);
            }
            else
            {
                return NotFound("Não atualizado");
            }
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    // DELETE api/<FuncionarioController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (id != 0)
        {
            await _funcionarioService.DeleteFuncionario(id);
            return Ok("Funcionario deletado!");

        }
        else
        {
            return NotFound("Id não existe");
        }


    }

    [HttpPut("Inativa funcionario")]
    public async Task<IActionResult> Inativa(int id)
    {

        await _funcionarioService.InativaFuncionario(id);
        return Ok("Funcionario inativado");

    }
}
