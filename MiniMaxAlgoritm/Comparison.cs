using Connect4;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniMaxAlgoritm;

internal class Comparison
{
    public static void Main(string[] args)
    {
        int depth = 5;

        int[,] board = new int[6, 7];

        GameState gameState = new GameState();
        gameState.SetGameState(board, 1);

        // We shouldn't have to clone it but lets be safe
        GameState abGameState = gameState.Clone();

        MiniMax minimax = new MiniMax();
        int bestMove = minimax.FindBestMove(gameState, depth);
        Console.WriteLine($"MiniMax - Best move: {bestMove} - Nodes visited: {minimax.GetNodesVisited()}");

        AlphaBetaMiniMax(gameState.Clone(), depth, applyMoveOrdering: false, "AlphaBetaMiniMax");
        AlphaBetaMiniMax(gameState.Clone(), depth, applyMoveOrdering: true, "AlphaBetaMiniMax with move ordering");

    }

    private static void AlphaBetaMiniMax(GameState gameState, int depth, bool applyMoveOrdering, string title)
    {
        AlphaBetaMiniMax alphaBetaMiniMax = new AlphaBetaMiniMax();
        alphaBetaMiniMax.ApplyMoveOrdering = applyMoveOrdering;
        int bestMove = alphaBetaMiniMax.FindBestMove(gameState, depth);
        Console.WriteLine($"{title} - Best move: {bestMove} - Nodes visited: {alphaBetaMiniMax.GetNodesVisited()}");
    }
}
