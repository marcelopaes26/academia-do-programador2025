using System;

public class Atividade01
{

    public static string MostrarMenu()
    {

        Console.WriteLine("----------- MENU -----------");
        Console.WriteLine("1. VERIFICAR TRIÂNGULO");
        Console.WriteLine("2. SAIR DO PROGRAMA");
        Console.WriteLine("----------------------------");

        Console.Write("Digite sua opção: ");
        string opcao = Console.ReadLine();

        return opcao;
    }

    public static double ValidaEntrada(string entrada)
    {
        double valor;
        bool valido;

        do
        {         
            Console.Write(entrada);
            valido = double.TryParse(Console.ReadLine().Replace(".",","), out valor);

            if(!valido || valor <= 0)
            {
                Console.WriteLine("Entrada inválida. Digite um número válido e positivo!");
            }


        } while (!valido || valor <= 0);

        return valor;

    }

    public static void ValidaTriangulo()
    {
        double x = ValidaEntrada("Digite o 1º lado: ");
        double y = ValidaEntrada("Digite o 2º lado: ");
        double z = ValidaEntrada("Digite o 3º lado: ");

        if ((x + y > z) && (y + z > x) && (x + z > y))
        {
            ValidaTipoTriangulo(x, y, z);
        }
        else
        {
            Console.WriteLine("Triângulo inválido!");
        }


    }

    public static void ValidaTipoTriangulo(double x, double y, double z)
    {
        if ((x == y) && (y == z))
        {
            Console.WriteLine("Triângulo Equilátero!");
        }
        else if ((x == y) || (y == z) || (x == z))
        {
            Console.WriteLine("Triângulo Isósceles!");
        }
        else
        {
            Console.WriteLine("Triângulo Escaleno!");
        }
    }

    public static void Main(string[] args)
    {

        int opcao = 0;

        while (opcao != 2)
        {

            // Converter entrada string para inteiro
            if (int.TryParse(MostrarMenu(), out opcao))
            {
                switch (opcao)
                {
                    case 1:
                        ValidaTriangulo();
                        break;
                    case 2:
                        Console.WriteLine("Saindo do programa... Até logo!");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente!");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida. Digite um número!");
            }

        }

    }

}