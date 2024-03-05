using WebApiFuncionario.Models;


namespace WebApiFuncionario.Service;

public interface IFuncionarioService
{
    public Task<List<Funcionario>> GetFuncionarios();
    public Task CreateFuncionario(Funcionario novoFuncionario);
    public Task<Funcionario> GetFuncionariosById(int id);
    public Task UpdateFuncionario(Funcionario editFuncionario);
    public Task DeleteFuncionario(int id);
    public Task InativaFuncionario(int id);
}
