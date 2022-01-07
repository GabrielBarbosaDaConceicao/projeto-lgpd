using System;
namespace LGPD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Pessoa pessoa = new Pessoa();
            Console.WriteLine("Digite o seu CPF:");
            pessoa.Cpf = Console.ReadLine();

            Console.WriteLine("Quer que seus dados sejam privados: sim/não");
            pessoa.DadosPrivados = pessoa.EhDadosPrivados(Console.ReadLine());

            pessoa.Imprimir();

        }

        class Pessoa
        {
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
                    Console.WriteLine($"CPF: {CpfMascarado(Cpf)} \nDados Privados: {RetonoDadosPrivados(DadosPrivados)} ");
                }
                else
                {
                    Console.WriteLine("------------------Dados não Privados---------------------------");
                    Console.WriteLine($"CPF: {CpfFormatado(Cpf)} \ndados privados: {RetonoDadosPrivados(DadosPrivados)}");
                }

            }

        }
    }
}