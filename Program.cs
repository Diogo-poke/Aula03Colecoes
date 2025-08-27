using System;
using Aula02RH.Models;
using Aula03Colecoes.Models;
using Aula03Colecoes.Models.Enuns;
namespace Aula03Colecoes
{
    public class Program
    {
        static List<Funcionario> lista = new List<Funcionario>();


        static void Main(string[] args)
        {
            CriarLista();
            ObterPorId();
            AdicionarFuncionario();
            ObterPorIdDigitado();
             ObterPorSalario();
           
        }

        public static void ObterPorId()
         {
               lista = lista.FindAll(x => x.Id == 1);
                ExibirLista();

         }

         public static void ObterPorIdDigitado()
         {
            Console.WriteLine("Digite o id: ");
            int id = int.Parse(Console.ReadLine());
            Funcionario fBusca = lista.Find(x => x.Id == id);
          
          if (fBusca == null)
            Console.WriteLine("Não encontrado");
            else
            Console.WriteLine($"Funcionario encontrado: {fBusca.Nome}");
         }

         public static void ObterPorSalario()
         {
            Console.WriteLine("Digite o valor minimo: ");
            decimal salario = decimal.Parse(Console.ReadLine());
            lista = lista.FindAll(x => x.Salario >= salario);
            ExibirLista();
         }

        public static void AdicionarFuncionario()
        {
            Funcionario f = new Funcionario();

            Console.WriteLine("Digite o nome: ");
            f.Nome = Console.ReadLine();

            Console.WriteLine("Digite o salário: ");
            f.Salario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Digite a data de admissão: ");
            f.DataAdmissao = DateTime.Parse(Console.ReadLine());

            if(string.IsNullOrEmpty(f.Nome))
            {
                Console.WriteLine("O nome deve ser preenchido");
                return;
            } 
            else if(f.Salario == 0)
            {
             Console.WriteLine("Valor do salario não pode ser 0");
             return;
            }
            else 
            {
                lista.Add(f);
                ExibirLista();
            }
        }
        
                // Atividade 1

      public static void ObterPorNome()
      {
       
    Console.WriteLine("Digite o nome do funcionário: ");
    string nome = Console.ReadLine();

    var funcionario = lista.FirstOrDefault(f => f.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

    if (funcionario != null)
        Console.WriteLine($"Encontrado: {funcionario.Id} - {funcionario.Nome} - Salário: {funcionario.Salario}");
    else
        Console.WriteLine($"Funcionário '{nome}' não encontrado!");
   
      }

      public static void ObterFuncionariosRecentes()
      {
         Funcionario f = new Funcionario();
         lista.RemoveAll(f = f.Id < 4);

      var listaOrdenada = lista.OrderByDescending(f => f.Salario).ToList();

        ExibirLista(listaOrdenada);
      }

      public static void ObterEstatisticas()
        {
        int quantidade = Funcionario.Count;

         decimal somaSalarios = Funcionario.Sum(f => f.Salario);

        Console.WriteLine($"Quantidade de funcionários: {quantidade}");
        Console.WriteLine($"Somatório dos salários: {somaSalarios}");

        }
        public static void ValidarSalarioAdmissao()
    {
     if (f.Salario == 0)
    {
        Console.WriteLine(" O salário não pode ser 0.");
        return false;
    }

    if (f.DataAdmissao < DateTime.Now.Date)
    {
        Console.WriteLine(" A data de admissão não pode ser anterior à data atual.");
        return false;
    }

    return true; 
 }
        
    public static bool ValidarNome(Funcionario f)
{
    if (string.IsNullOrEmpty(f.Nome) || f.Nome.Length < 2)
    {
        Console.WriteLine(" O nome deve ter pelo menos 2 caracteres.");
        return false;
    }
    return true;
}
public static void ObterPorTipo()
{
    Console.WriteLine("Digite o tipo do funcionário (número): ");
    foreach (var tipo in Enum.GetValues(typeof(TipoFuncionarioEnum)))
    {
        Console.WriteLine($"{(int)tipo} - {tipo}");
    }

    if (!int.TryParse(Console.ReadLine(), out int valor))
    {
        Console.WriteLine("Valor inválido. Digite um número.");
        return;
    }

    var listaFiltrada = lista
        .Where(f => (int)f.TipoFuncionario == valor)
        .ToList();

    if (listaFiltrada.Count == 0)
    {
        Console.WriteLine("Nenhum funcionário encontrado para esse tipo.");
    }
    else
    {
        Console.WriteLine("Funcionários encontrados:");
        foreach (var f in listaFiltrada)
        {
            Console.WriteLine($"{f.Id} - {f.Nome} - {f.TipoFuncionario}");
        }
    }
}


          public static void ExibirLista()
          {
            string dados = "";
            for(int i = 0; i < lista.Count; i++)
            {
        dados += "==================\n";
        dados += string.Format("Id : {0} \n", lista[i].Id);
        dados += string.Format("Nome : {0} \n", lista[i].Nome);
        dados += string.Format("Cpf : {0} \n", lista[i].Cpf);
        dados += string.Format("Adimissão : {0:dd/MM/YYYY} \n", lista[i].DataAdmissao);
        dados += string.Format("Salario : {0:c2} \n", lista[i].Salario);
        dados += string.Format("Tipo : {0} \n", lista[i].TipoFuncionario);
        dados += "==================\n";
            }
          Console.WriteLine(dados);
          }

         public static void CriarLista()
        {
            Funcionario f1 = new Funcionario();
            f1.Id = 1;
            f1.Nome = "Neymar";
            f1.Cpf = "12345678910";
            f1.DataAdmissao = DateTime.Parse("01/01/2000");
            f1.Salario = 100.000M;
            f1.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f1);

            Funcionario f2 = new Funcionario();
            f2.Id = 2;
            f2.Nome = "Cristiano Ronaldo";
            f2.Cpf = "01987654321";
            f2.DataAdmissao = DateTime.Parse("30/06/2002");
            f2.Salario = 150.000M;
            f2.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f2);

            Funcionario f3 = new Funcionario();
            f3.Id = 3;
            f3.Nome = "Messi";
            f3.Cpf = "135792468";
            f3.DataAdmissao = DateTime.Parse("01/11/2003");
            f3.Salario = 70.000M;
            f3.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f3);

            Funcionario f4 = new Funcionario();
            f4.Id = 4;
            f4.Nome = "Mbappe";
            f4.Cpf = "246813579";
            f4.DataAdmissao = DateTime.Parse("15/09/2005");
            f4.Salario = 80.000M;
            f4.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f4);

            Funcionario f5 = new Funcionario();
            f5.Id = 5;
            f5.Nome = "Lewa";
            f5.Cpf = "246813579";
            f5.DataAdmissao = DateTime.Parse("20/10/1998");
            f5.Salario = 90.000M;
            f5.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f5);

            Funcionario f6 = new Funcionario();
            f6.Id = 6;
            f6.Nome = "Roger Guedes";
            f6.Cpf = "246813579";
        }
   
    }
}
