using System;
using System.Globalization;
namespace LGPD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            Pessoa pessoa = new Pessoa();

            Console.Write("Nome: ");
            pessoa.Nome = Console.ReadLine();
            pessoa.Nome = textInfo.ToTitleCase(pessoa.Nome);

            Console.WriteLine("Digite o seu CPF:");
            pessoa.Cpf = Console.ReadLine();

            Console.WriteLine("Quer que seus dados sejam privados: sim/não");
            pessoa.DadosPrivados = pessoa.EhDadosPrivados(Console.ReadLine());

            pessoa.Imprimir();

        }

        class Pessoa
        {
            public string Nome; 
            public string Cpf;
            public bool DadosPrivados;

            // Esse metodo quebra o Cpf em 3 partes e substitui 2 partes por "*";
            private string CpfMascarado(string Cpf)
            {
                string[] CpfMascarado = Cpf.Split('.', ' ', ',', '/', '-', ';');
                return Cpf.Replace(CpfMascarado[0], "***").Replace(CpfMascarado[2], "***").Replace(' ', '.').Replace('/', '.').Replace(',', '.').Replace('-', '.').Replace(';', '.');

            }
            private string CpfFormatado(string Cpf)
            {
                string[] CpfFormatado = Cpf.Split('.', ' ', ',', '/', '-', '*', ';');
                return Cpf.Replace(' ', '.').Replace('/', '.').Replace(',', '.').Replace('-', '.').Replace('*', '.').Replace(';', '.');
            }

            public bool EhDadosPrivados(string DadosPrivados)
            {
                if (DadosPrivados.Equals("sim"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public string RetonoDadosPrivados(bool DadosPrivados)
            {
                if (DadosPrivados.Equals(true))
                {
                    return "sim";
                }
                else
                {
                    return "não";
                }
            }

            public void Imprimir()
            {
                if (DadosPrivados)
                {
                    Console.WriteLine("------------------Dados Privados-------------------------------");
                    Console.WriteLine($"Nome: {Nome} \nCPF: {CpfMascarado(Cpf)} \nDados Privados: {RetonoDadosPrivados(DadosPrivados)} ");
                }
                else
                {
                    Console.WriteLine("------------------Dados não Privados---------------------------");
                    Console.WriteLine($"Nome: {Nome} \nCPF: {CpfFormatado(Cpf)} \ndados privados: {RetonoDadosPrivados(DadosPrivados)}");
                }

            }

        }
    }
}