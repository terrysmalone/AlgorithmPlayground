using Connect4;

namespace MiniMaxAlgoritm;

internal class Comparison
{
    public static void Main(string[] args)
    {
        int depth = 7;

        int[,] board = new int[6, 7];

        GameState gameState = new GameState();
        gameState.SetGameState(board, 1);

        MiniMax minimax = new MiniMax();
        int bestMove = minimax.FindBestMove(gameState, depth);
        Console.WriteLine($"Best move: {bestMove} - Nodes visited: {minimax.GetNodesVisited()} - MiniMax");

        RunAlphaBetaMiniMax(gameState.Clone(), depth, moveOrdering: false, transpositionTable: false, "AlphaBeta");
        RunAlphaBetaMiniMax(gameState.Clone(), depth, moveOrdering: true,  transpositionTable: false, "AlphaBeta + MoveOrdering");
        RunAlphaBetaMiniMax(gameState.Clone(), depth, moveOrdering: false, transpositionTable: true,  "AlphaBeta + TranspositionTable");
        RunAlphaBetaMiniMax(gameState.Clone(), depth, moveOrdering: true,  transpositionTable: true,  "AlphaBeta + MoveOrdering + TranspositionTable");
    }

    private static void RunAlphaBetaMiniMax(GameState gameState, int depth, bool moveOrdering, bool transpositionTable, string title)
    {
        AlphaBetaMiniMax alphaBeta = new AlphaBetaMiniMax();
        alphaBeta.ApplyMoveOrdering = moveOrdering;
        alphaBeta.ApplyTranspositionTable = transpositionTable;

        int bestMove = alphaBeta.FindBestMove(gameState, depth);
        Console.WriteLine($"Best move: {bestMove} - Nodes visited: {alphaBeta.GetNodesVisited()} - {title}");
    }
}
