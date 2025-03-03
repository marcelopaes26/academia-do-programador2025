using System;

public class Atividade02
{

    private static Random rnd = new Random();

    public static int JogarDado()
    {
        int valorDado = rnd.Next(1, 7);
        Console.WriteLine($"Número do dado: {valorDado}");
        if (valorDado == 6)
        {
            Console.WriteLine("Jogando dado extra...");
            valorDado += JogarDado();
        }
        return valorDado;
    }

    public static int EventosEspeciais(int posicao)
    {
        List<int> avanco = new List<int> {5, 10, 15};
        List<int> recuo = new List<int> {7, 13, 20};

        if (avanco.Contains(posicao))
        {
            posicao += 3;
            Console.WriteLine("Avançou 3 casas!");
        }
        else if (recuo.Contains(posicao))
        {
            posicao -= 2;
            Console.WriteLine("Recuou 2 casas!");
        }
        return posicao;
    }

    public static void Main(string[] args)
    {
        int jogador = 0, computador = 0, rodada = 1;
        const int tamanhoPista = 30;

        do
        {
            Console.WriteLine($"------- RODADA {rodada} -------");
            Console.WriteLine("Turno do jogador");
            while (true)
            {
                Console.WriteLine("Aperte Enter para jogar o dado...");
                var entrada = Console.ReadKey(intercept: true);

                if (entrada.Key == ConsoleKey.Enter)
                {
                    break;
                }
                Console.WriteLine("Tecla inválida. Tente novamente!");
            }
            jogador += JogarDado();
            jogador = EventosEspeciais(jogador);
            Console.WriteLine($"Posição do jogador: {jogador}");
            Console.WriteLine();
            Console.WriteLine("Turno do computador");
            computador += JogarDado();
            computador = EventosEspeciais(computador);
            Console.WriteLine($"Posição do computador: {computador}");
            Console.WriteLine();
            rodada++;

        } while ((jogador < tamanhoPista) && (computador < tamanhoPista));

        if (jogador > computador)
        {
            Console.WriteLine($"O jogador foi campeão!\nResultado final:\nJogador = {jogador}\nComputador = {computador}");
        }
        else if (computador > jogador)
        {
            Console.WriteLine($"O computador foi campeão!\nResultado final:\nComputador = {computador}\nJogador = {jogador}");
        }
        else
        {
            Console.WriteLine($"O jogo terminou empatado!\nResultado final:\nJogador = {jogador}\nComputador = {computador}");
        }

    }
}
