using Connect4;

namespace MiniMaxAlgoritm;

internal class Comparison
{
    public static void Main(string[] args)
    {
        int depth = 8;

        int[,] emptyBoard = new int[6, 7];
        GameState emptyBoardgameState = new GameState();
        emptyBoardgameState.SetGameState(emptyBoard, 1);

        DoFullRun(emptyBoardgameState, depth, "Empty Board");

        int[,] complexBoard = new int[6, 7]
        {
            {  0,  0,  0,  0,  0,  0,  0 },
            {  0,  0,  0,  0,  0,  0,  0 },
            {  0,  0, -1,  1,  0,  0,  0 },
            {  0,  1,  1, -1,  0,  0,  0 },
            {  0, -1, -1,  1,  1,  0,  0 },
            {  1,  1, -1, -1,  1, -1,  0 }
        };

        GameState complexBoardgameState = new GameState();
        complexBoardgameState.SetGameState(complexBoard, 1);

        DoFullRun(complexBoardgameState, depth, "Complex Board");
    }

    private static void DoFullRun(GameState gameState, int depth, string title)
    {
        Console.WriteLine(title);
        MiniMax minimax = new MiniMax();
        int bestMove = minimax.FindBestMove(gameState, depth);
        Console.WriteLine($"Best move: {bestMove} - Nodes visited: {minimax.GetNodesVisited()} - MiniMax");

        RunAlphaBetaMiniMax(gameState.Clone(), depth, iterativeDeepening: false, moveOrdering: false, transpositionTable: false, "AlphaBeta");
        RunAlphaBetaMiniMax(gameState.Clone(), depth, iterativeDeepening: false, moveOrdering: true, transpositionTable: false, "AlphaBeta + MoveOrdering");
        RunAlphaBetaMiniMax(gameState.Clone(), depth, iterativeDeepening: false, moveOrdering: false, transpositionTable: true, "AlphaBeta + TranspositionTable");
        RunAlphaBetaMiniMax(gameState.Clone(), depth, iterativeDeepening: false, moveOrdering: true, transpositionTable: true, "AlphaBeta + MoveOrdering + TranspositionTable");

        RunAlphaBetaMiniMax(gameState.Clone(), depth, iterativeDeepening: true, moveOrdering: false, transpositionTable: false, "AlphaBeta with iterative deepening");
        RunAlphaBetaMiniMax(gameState.Clone(), depth, iterativeDeepening: true, moveOrdering: true, transpositionTable: false, "AlphaBeta with iterative + MoveOrdering");
        RunAlphaBetaMiniMax(gameState.Clone(), depth, iterativeDeepening: true, moveOrdering: false, transpositionTable: true, "AlphaBeta with iterative + TranspositionTable");
        RunAlphaBetaMiniMax(gameState.Clone(), depth, iterativeDeepening: true, moveOrdering: true, transpositionTable: true, "AlphaBeta with iterative + MoveOrdering + TranspositionTable");

    }

    private static void RunAlphaBetaMiniMax(GameState gameState, int depth, bool iterativeDeepening, bool moveOrdering, bool transpositionTable, string title)
    {
        AlphaBetaMiniMax alphaBeta = new AlphaBetaMiniMax();
        alphaBeta.ApplyMoveOrdering = moveOrdering;
        alphaBeta.ApplyTranspositionTable = transpositionTable;
        alphaBeta.ApplyIterativeDeepening = iterativeDeepening;

        int bestMove = alphaBeta.FindBestMove(gameState, depth);
        Console.WriteLine($"Best move: {bestMove} - Nodes visited: {alphaBeta.GetNodesVisited()} - {title}");
    }
}
