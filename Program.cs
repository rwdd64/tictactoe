using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha
{
    class Program
    {
        static void Main ()
        {
            int[,] board = {
                { 0, 0, 0 }, 
                { 0, 0, 0 },
                { 0, 0, 0 }
            };
            bool finished = false;
            int jogadorAtual = 1;
            int escolhaPlayer = 0;
            int winner = 0;
            
            while(escolhaPlayer != 1 && escolhaPlayer != 2)
            {
                getPlayer();
            }

            jogadorAtual = escolhaPlayer;

            Console.Clear();

            while (!finished)
            {
                int jogadaX;
                int jogadaY;

                if (jogadorAtual==1)
                {
                    Console.WriteLine("Jogador atual: X");
                }
                else
                {
                    Console.WriteLine("Jogador atual: Bolinha");
                }

                printBoard();
                pegarJogada();

                // board[jogadaX - 1, jogadaY - 1] -> espaço selecionado
                while (board[jogadaX - 1, jogadaY - 1] != 0)
                {
                    Console.WriteLine("Esse espaço já foi preenchido!");
                    pegarJogada();
                }

                board[jogadaX - 1, jogadaY - 1] = jogadorAtual;

                
                if (checkWin() != 0)
                {
                    winner = checkWin();
                } else
                {
                    Console.Clear();
                    changePlayer();
                }

                void pegarJogada()
                {
                    Console.Write("Em qual linha você quer colocar? ");
                    jogadaX = int.Parse(Console.ReadLine());
                    Console.Write("Em qual coluna você quer colocar? ");
                    jogadaY = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("Vencedor: {0}", winner);

            int checkWin()
            {
                int nulos = 0;
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        if (board[i, j] == 0)
                        {
                            nulos++;
                        }
                    }
                }

                if (nulos == 0)
                {
                    finished = true;
                }
                    /*

                     |X| | | -> 0,0
                     |X| | | -> 1,0
                     |X| | | -> 2,0

                    CHECANDO AS LINHAS
                    0,0
                    0,1
                    0,2

                    1,0
                    1,1
                    1,2

                    2,0
                    2,1
                    2,2

                    CHECANDO AS COLUNAS
                    0,0
                    1,0
                    2,0

                    0,1
                    1,1
                    2,1

                    0,2
                    1,2
                    2,2

                    CHECANDO AS DIAGONAIS
                    0,0
                    1,1
                    2,2

                    0,2
                    1,1
                    2,0
                    */

                    //Checando as linhas
                    for (int i=0; i<board.GetLength(0); i++)
                {
                    if (board[i,0] != 0 && (board[i, 0] == board[i, 1] && board[i,0] == board[i, 2]))
                    {
                        finished = true;
                        return board[i, 0];
                    }
                }

                //Checando as colunas
                for (int i = 0; i < board.GetLength(1); i++)
                {
                    if (board[0, i] != 0 && (board[0, i] == board[1, i] && board[0, i] == board[2, i]))
                    {
                        finished = true;
                        return board[0, i];
                    }
                }

                //Checando as diagonais
                
                if ((board[0, 0] != 0 && board[0,2] != 0) &&
                    (board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2] ||
                    board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0]))
                {
                    finished = true;
                    return board[0, 0];
                }

                return 0;
            }

            void getPlayer()
            {
                Console.WriteLine("Qual jogador inicia?");
                Console.WriteLine("1. X");
                Console.WriteLine("2. Bolinha");
                Console.Write("Sua escolha: ");

                escolhaPlayer = int.Parse(Console.ReadLine());
            }

            void changePlayer()
            {
                if (jogadorAtual == 1)
                {
                    jogadorAtual = 2;
                }
                else
                {
                    jogadorAtual = 1;
                }
            }

            void printBoard()
            {
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    Console.WriteLine("-------");
                    Console.Write("|");
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        int currentTile = board[i, j];
                        switch (currentTile)
                        {
                            case 0:
                                Console.Write(" ");
                                break;
                            case 1:
                                Console.Write("X");
                                break;
                            case 2:
                                Console.Write("O");
                                break;
                        }
                        Console.Write("|");
                    }
                    Console.Write("\n");
                }
                Console.WriteLine("-------");
            }
        }
    }
}
