using System.Text.Json.Serialization;

namespace WebApiFuncionario.Enums;
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DepartamentoEnum
{
    Rh,
    Financeiro,
    Compras,
    Atendimento,
    Zeladoria
}
