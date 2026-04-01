using Connect4;

namespace MiniMaxAlgoritm;

public class AlphaBetaMiniMax : IMiniMax
{
    private int _nodesVisited = 0;
    private readonly Dictionary<ulong, TranspositionEntry> _transpositionTable = new();

    public bool ApplyMoveOrdering { get; set; }
    public bool ApplyTranspositionTable { get; set; }

    public int FindBestMove(GameState gameState, int depth)
    {
        _nodesVisited = 0;
        _transpositionTable.Clear();

        // If it's player 1s turn we want to maximise the score,
        // if it's player -1s turn we want to minimise the score
        int bestScore = int.MinValue;
        if (gameState.CurrentPlayer == -1)
        {
            bestScore = int.MaxValue;
        }

        int alpha = int.MinValue;
        int beta = int.MaxValue;

        int bestMove = -1;

        List<int> moves = gameState.GetValidMoves();

        if (ApplyMoveOrdering)
        {
            OrderMoves(moves);
        }

        foreach (int move in moves)
        {
            // Make the move, recursively evaluate the game state, then undo the move
            gameState.ApplyMove(move);
            int score = MiniMaxRecursive(gameState, depth - 1, alpha, beta);
            gameState.UndoLastMove();


            // If it's player 1, we want the highest score, if it's player -1, we want the lowest score
            if ((gameState.CurrentPlayer == 1 && score > bestScore)
                || (gameState.CurrentPlayer == -1 && score < bestScore))
            {
                bestScore = score;
                bestMove = move;
            }

            // Update alpha or beta so we can prune at the root
            if (gameState.CurrentPlayer == 1)
            {
                alpha = Math.Max(alpha, bestScore);
            }
            else
            {
                beta = Math.Min(beta, bestScore);
            }
        }

        return bestMove;
    }

    private int MiniMaxRecursive(GameState gameState, int depth, int alpha, int beta)
    {
        int originalAlpha = alpha;
        int originalBeta = beta;

        // Transposition table lookup
        ulong hash = 0;
        if (ApplyTranspositionTable)
        {
            hash = gameState.GetHash();
            if (_transpositionTable.TryGetValue(hash, out TranspositionEntry entry) && entry.Depth >= depth)
            {
                if (entry.Type == EntryType.Exact)
                {
                    return entry.Score;
                }
                if (entry.Type == EntryType.LowerBound)
                {
                    alpha = Math.Max(alpha, entry.Score);
                }
                else if (entry.Type == EntryType.UpperBound)
                {
                    beta = Math.Min(beta, entry.Score);
                }

                // The refined window still allows a cutoff
                if (beta <= alpha)
                {
                    return entry.Score;
                }
            }
        }

        // Do this after doing the transposition table look up because we only want to measure the evaluated nodes
        _nodesVisited++;

        // If we've hit the depth limit or the game is over, return the score
        if (depth <= 0 || gameState.IsTerminal())
        {
            int score = gameState.CalculateScore();
            return score + (Math.Sign(score) * depth);
        }

        List<int> moves = gameState.GetValidMoves();

        if (ApplyMoveOrdering)
        {
            OrderMoves(moves);
        }

        int bestScore;

        if (gameState.CurrentPlayer == 1)
        {
            bestScore = int.MinValue;

            foreach (int move in moves)
            {
                // Make the move, recursively evaluate the game state, then undo the move
                gameState.ApplyMove(move);
                int score = MiniMaxRecursive(gameState, depth - 1, alpha, beta);
                gameState.UndoLastMove();

                // The best score is the maximum of all attempts so far
                bestScore = Math.Max(bestScore, score);

                // If the best score is higher than alpha update alpha
                alpha = Math.Max(alpha, bestScore);

                // If beta is less than or equal to alpha stop evaluating this branch
                if (beta <= alpha)
                {
                    break;
                }
            }
        }
        else
        {
            bestScore = int.MaxValue;
                
            foreach (int move in moves)
            {
                // Make the move, recursively evaluate the game state, then undo the move
                gameState.ApplyMove(move);
                int score = MiniMaxRecursive(gameState, depth - 1, alpha, beta);
                gameState.UndoLastMove();

                // The best score is the minimum of all attempts so far
                bestScore = Math.Min(bestScore, score);

                // If the best score is lower than beta update beta
                beta = Math.Min(beta, bestScore);

                // If beta is less than or equal to alpha stop evaluating this branch
                if (beta <= alpha)
                {
                    break;
                }
            }
        }

        // Store the result, classifying the score relative to the original window
        if (ApplyTranspositionTable)
        {
            EntryType entryType;

            if (bestScore <= originalAlpha)
            {
                // failed low - couldn't beat alpha
                entryType = EntryType.UpperBound;
            }
            else if (bestScore >= originalBeta)
            {
                // failed high - caused beta cutoff
                entryType = EntryType.LowerBound;  
            }
            else
            {
                // within the window
                entryType = EntryType.Exact; 
            }

            // Only overwrite if the new entry searched deeper
            if (!_transpositionTable.TryGetValue(hash, out TranspositionEntry existing) || depth >= existing.Depth)
            {
                _transpositionTable[hash] = new TranspositionEntry(bestScore, depth, entryType);
            }
        }

        return bestScore;        
    }

    // Very basic move ordering that prioritises being closer to the middle column
    private void OrderMoves(List<int> moves)
    {        
        moves.Sort((a, b) =>
        {
            int middle = 3;
            int distanceA = Math.Abs(a - middle);
            int distanceB = Math.Abs(b - middle);
            return distanceA.CompareTo(distanceB);
        });
    }

    public int GetNodesVisited()
    {
        return _nodesVisited;
    }
}