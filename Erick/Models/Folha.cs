using Microsoft.AspNetCore.SignalR;


public class Folha
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Nome { get; set; } = String.Empty;
    public string CPF {get; set;} = String.Empty;
    public int Mes { get; set; }
    public  int Ano { get; set; }
    public  double horasTrabalhadas { get; set; }
    public  double ValorHora { get; set; }
    public  double ValorBruto { get; set; }
    public  double ImpostoRenda { get; set; }
    public  double inss { get; set; }
    public  double fgts { get; set; }
    public  double SalarioLiquido { get; set; }

}