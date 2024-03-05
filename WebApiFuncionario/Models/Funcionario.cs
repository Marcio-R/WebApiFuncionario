using System.ComponentModel.DataAnnotations;
using WebApiFuncionario.Enums;

namespace WebApiFuncionario.Models;

public class Funcionario
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DepartamentoEnum Departamento { get; set; }
    public bool Ativo { get; set; }
    public TurnoEnum Turno { get; set; }
    public DateTime DataDeCriacao { get; set; } = DateTime.Now.ToLocalTime();
    public DateTime DataDeAlteracao { get; set; } = DateTime.Now.ToLocalTime();

    public Funcionario()
    {
    }

    public Funcionario(int id, string nome, string sobrenome, DepartamentoEnum departamento, bool ativo, TurnoEnum turno, DateTime dataDeCriacao, DateTime dataDeAlteracao)
    {
        Id = id;
        Nome = nome;
        Sobrenome = sobrenome;
        Departamento = departamento;
        Ativo = ativo;
        Turno = turno;
        DataDeCriacao = dataDeCriacao;
        DataDeAlteracao = dataDeAlteracao;
    }
}
