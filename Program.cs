const decimal Preco1H = 20;
const decimal PrecoHPequena = 10;
const decimal PrecoHGrande = 20;
const decimal PrecoDPequeno = 50;
const decimal PrecoDGrande = 80;
const double AddValet = 0.2;
const decimal PrecoLPequeno = 50;
const decimal PrecoLGrande = 100;

const int TempoD = 5 * 60;
const int TempoT = 5;
const int MaxTempoP = 12 * 60;

int tempoP;
string tamanho;
bool valet, lavagem;

decimal Estacionamentoparcial = 0;
decimal Valetparcial = 0;
decimal Lavagemparcial = 0;
decimal total = 0;

Console.WriteLine("--- Estacionamento ---\n");

Console.Write("Tamanho do veículo (P/G).....: ");
tamanho = Console.ReadLine()!.Trim().Substring(0, 1).ToUpper();

if (tamanho != "P" && tamanho != "G")
{
    Console.WriteLine("Tamanho inválido.");
    return;
}

Console.Write("Tempo de permanência (min)...: ");
tempoP = Convert.ToInt32(Console.ReadLine());

if (tempoP <= 0 || tempoP > MaxTempoP)
{
    Console.WriteLine("Tempo de permanência inválido.");
    return;
}

Console.Write("Serviço de valet (S/N).......: ");
valet = Console.ReadLine()!.Trim().Substring(0, 1).ToUpper() == "S";

Console.Write("Serviço de lavagem (S/N).....: ");
lavagem = Console.ReadLine()!.Trim().Substring(0, 1).ToUpper() == "S";

if (tempoP >= TempoD)
{
    if (tamanho == "P")
    {
        Estacionamentoparcial = PrecoDPequeno;
    }
    else
    {
        Estacionamentoparcial = PrecoDGrande;
    }
}
else
{
    int horasP = (int)(tempoP / 60);
    int minutosRestantes = tempoP % 60;

    if (minutosRestantes > TempoT)
    {
        horasP++;
    }

    Estacionamentoparcial = Preco1H;
    int horasAdicionais = horasP- 1;

    if (horasAdicionais > 0)
    {
        if (tamanho == "P")
        {
            Estacionamentoparcial += horasAdicionais * PrecoHPequena;
        }
        else
        {
            Estacionamentoparcial += horasAdicionais * PrecoHGrande;
        }
    }
}

if (valet)
{
    Valetparcial = Estacionamentoparcial * Convert.ToDecimal(AddValet);
}

if (lavagem)
{
    if (tamanho == "P")
    {
       Lavagemparcial += PrecoLPequeno;
    }
    else
    {
        Lavagemparcial+= PrecoLGrande;
    }
}

total = Estacionamentoparcial + Valetparcial + Lavagemparcial;

Console.WriteLine($"\nEstacionamento..: {Estacionamentoparcial,14:C}");
Console.WriteLine($"Valet...........: {Valetparcial,14:C}");
Console.WriteLine($"Lavagem.........: {Lavagemparcial,14:C}");
Console.WriteLine("--------------------------------");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"Total...........: {total,14:C}");
Console.ResetColor();
