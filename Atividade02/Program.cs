using System;

public class Atividade02
{

    // Cria um objeto Random para gerar números aleatórios
    private static Random rnd = new Random();

    //Função para jogar o dado a cada rodada
    public static int JogarDado()
    {
        // Cria a variável valorDado atribuindo o valor da instância rnd utilizando o método Next
        // passando os parâmetros 1 e 7 para gerar números aleatórios de 1 a 6
        int valorDado = rnd.Next(1, 7);
        Console.WriteLine($"Número do dado: {valorDado}");

        // Verifica se o número do dado é 6 para o jogador ou computador ter uma rodada extra
        if (valorDado == 6)
        {
            Console.WriteLine("Jogando dado extra...");
            // Se o valor do dado for 6 é chamada a função JogarDado() de forma recursiva 
            // e somado ao valor do dado inicial
            valorDado += JogarDado();
        }
        return valorDado;
    }

    // Funçao para os eventos especiais (avanço e recuo)
    public static int EventosEspeciais(int posicao)
    {
        // Cria duas listas (avanco e recuo) para adicionar seus respectivos valores condicionais
        List<int> avanco = new List<int> {5, 10, 15};
        List<int> recuo = new List<int> {7, 13, 20};

        // Utiliza o método Contains para validar se a lista contém o valor em que está a posição
        if (avanco.Contains(posicao))
        {
            // Se a posição estiver na 5, 10 ou 15 é somado + 3 a ela
            posicao += 3;
            Console.WriteLine("Avançou 3 casas!");
        }
        // Utiliza o método Contains para validar se a lista contém o valor em que está a posição
        else if (recuo.Contains(posicao))
        {
            // Se a posição estiver na 7, 13 ou 20 é subtraído - 2 a ela
            posicao -= 2;
            Console.WriteLine("Recuou 2 casas!");
        }
        return posicao;
    }

    public static void Main(string[] args)
    {
        int jogador = 0, computador = 0, rodada = 1;
        
        // Cria uma constante do tipo inteiro com o valor fixo 30
        const int tamanhoPista = 30;

        do
        {
            Console.WriteLine($"------- RODADA {rodada} -------");
            Console.WriteLine("Turno do jogador");
            while (true)
            {
                Console.WriteLine("Aperte Enter para jogar o dado...");
                // Utilizado o método ReadKey para capturar a tecla que o usuário digitar 
                var entrada = Console.ReadKey(intercept: true);

                // Se a tecla for Enter o loop é interrompido e avança para o próximo bloco de código
                if (entrada.Key == ConsoleKey.Enter)
                {
                    break;
                }
                Console.WriteLine("Tecla inválida. Tente novamente!");
            }
            // O valor retornado da função JogarDado() é somado ao valor atual do jogador
            jogador += JogarDado();
            // o valor atual do jogador é passado como parâmetro na função EventosEspeciais() e atribuído a ele mesmo
            jogador = EventosEspeciais(jogador);
            Console.WriteLine($"Posição do jogador: {jogador}");
            Console.WriteLine();
            Console.WriteLine("Turno do computador");
            // O valor retornado da função JogarDado() é somado ao valor atual do computador
            computador += JogarDado();
            // o valor atual do computador é passado como parâmetro na função EventosEspeciais() e atribuído a ele mesmo
            computador = EventosEspeciais(computador);
            Console.WriteLine($"Posição do computador: {computador}");
            Console.WriteLine();
            // Incrementa o número de rodadas
            rodada++;

        // Condição para continuar o loop até o jogador ou computador ter o valor maior que tamanhoPista, que é 30
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
