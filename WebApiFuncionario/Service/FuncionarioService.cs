using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using WebApiFuncionario.Data;
using WebApiFuncionario.Models;

namespace WebApiFuncionario.Service;


public class FuncionarioService : IFuncionarioService
{

    private readonly WebApiFuncionarioContext _context;

    public FuncionarioService(WebApiFuncionarioContext context)
    {
        _context = context;
    }

    public async Task CreateFuncionario(Funcionario novoFuncionario)
    {
        try
        {
            await _context.Funcionario.AddAsync(novoFuncionario);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task DeleteFuncionario(int id)
    {
        try
        {

            var obj = await _context.Funcionario.FindAsync(id);
            if (!string.IsNullOrEmpty(obj.ToString()))
            {
                _context.Funcionario.Remove(obj);
                await _context.SaveChangesAsync();
            }
            

        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<List<Funcionario>> GetFuncionarios()
    {
        try
        {
            return await _context.Funcionario.ToListAsync();

        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<Funcionario> GetFuncionariosById(int id)
    {
        try
        {
            var funcionarioId = await _context.Funcionario.FindAsync(id);
            return funcionarioId;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task InativaFuncionario(int id)
    {
        try
        {
            Funcionario funcionario = await _context.Funcionario.FirstOrDefaultAsync(f => f.Id == id);
            funcionario.Ativo = false;
            funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();

            _context.Funcionario.Update(funcionario);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task UpdateFuncionario(Funcionario editFuncionario)
    {
        try
        {
            bool funcionario = await _context.Funcionario.AsNoTracking().AnyAsync(fun => fun.Id == editFuncionario.Id);
            if (funcionario == true)
            {
                _context.Update(editFuncionario);
                await _context.SaveChangesAsync();
            }

        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }


}
