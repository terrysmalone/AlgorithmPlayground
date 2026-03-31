using Connect4;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniMaxAlgoritm;

internal class Comparison
{
    public static void Main(string[] args)
    {
        int[,] board = new int[6, 7];

        GameState gameState = new GameState();
        gameState.SetGameState(board, 1);

        // We shouldn't have to clone it but lets be safe
        GameState abGameState = gameState.Clone();

        MiniMax minimax = new MiniMax();
        int bestMove = minimax.FindBestMove(gameState, 4);
        Console.WriteLine("MiniMax)");
        Console.WriteLine($"Best move: {bestMove} - Nodes visited: {minimax.GetNodesVisited()}");

        AlphaBetaMiniMax alphaBetaMiniMax = new AlphaBetaMiniMax();
        int bestMoveAB = alphaBetaMiniMax.FindBestMove(abGameState, 4);
        Console.WriteLine("AlphaBetaMiniMax)");
        Console.WriteLine($"Best move: {bestMoveAB} - Nodes visited: {alphaBetaMiniMax.GetNodesVisited()}");
    }
}
