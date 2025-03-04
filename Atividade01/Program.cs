using System;

public class Atividade01
{

    // Função para mostrar um menu interativo com o usuário
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

    // Função para validar a entrada de dados garantindo que esta entrada seja um número
    public static double ValidaEntrada(string entrada)
    {
        double valor;
        bool valido;

        do
        {         
            Console.Write(entrada);
            // Utilizando o método TryParse para converter a entrada string em valor do tipo double (real)
            // E o Replace para garantir caso o usuário digite "." seja substiuído por "," 
            valido = double.TryParse(Console.ReadLine().Replace(".",","), out valor);

            if(!valido || valor <= 0)
            {
                Console.WriteLine("Entrada inválida. Digite um número válido e positivo!");
            }

        // Condição do loop para garantir que a entrada seja válida ou um número positivo
        // Ou seja enquanto o usuário não digitar uma entrada válida ou um número positivo
        // Continuará solicitando a entrada para o usuário
        } while (!valido || valor <= 0);

        return valor;

    }

    // Função para validar um triângulo de acordo com o enunciado
    public static void ValidaTriangulo()
    {
        // Cria as variáves x, y e z e chama a função ValidaEntrada para cada uma passando um texto como parâmetro
        double x = ValidaEntrada("Digite o 1º lado: ");
        double y = ValidaEntrada("Digite o 2º lado: ");
        double z = ValidaEntrada("Digite o 3º lado: ");

        // Compara se a soma de quaisquer dos lados é maior que o terceiro lado
        // para garantir que seja um triângulo válido
        if ((x + y > z) && (y + z > x) && (x + z > y))
        {
            // Chama a função ValidaTipoTriangulo e passa as variáveis x, y e x como parâmetros
            ValidaTipoTriangulo(x, y, z);
        }
        else
        {
            Console.WriteLine("Triângulo inválido!");
        }


    }

    // Função para validar qual tipo do triângulo (Equilátero, Isósceles ou Escaleno)
    public static void ValidaTipoTriangulo(double x, double y, double z)
    {
        // Verifica se todos os lados são iguais
        if ((x == y) && (y == z))
        {
            Console.WriteLine("Triângulo Equilátero!");
        }
        // Verifica se pelo menos dois lados são iguais
        else if ((x == y) || (y == z) || (x == z))
        {
            Console.WriteLine("Triângulo Isósceles!");
        }
        // Caso se todos os lados forem diferentes
        else
        {
            Console.WriteLine("Triângulo Escaleno!");
        }
    }

    // Ponto de entrada da aplicação C#
    public static void Main(string[] args)
    {

        int opcao = 0;

        // Condição para que o loop continue ativo até o usuário digitar 2
        while (opcao != 2)
        {

            // Converter entrada string para inteiro, parecido com a função ValidaEntrada()
            // para garantir que o usuário não digite texto
            if (int.TryParse(MostrarMenu(), out opcao))
            {
                switch (opcao)
                {
                    case 1:
                        // Caso o usuário digite 1 chama a função ValidaTriangulo()
                        ValidaTriangulo();
                        break;
                    case 2:
                        // Caso o usuário digite 2 encerra o loop
                        Console.WriteLine("Saindo do programa... Até logo!");
                        break;
                    default:
                        // Caso o usuário digite qualquer número diferente de 1 ou 2
                        Console.WriteLine("Opção inválida. Tente novamente!");
                        break;
                }
            }
            // Se o usuário digitar texto
            else
            {
                Console.WriteLine("Entrada inválida. Digite um número!");
            }

        }

    }

}