using Connect4;

namespace MiniMaxAlgoritm;

public class MiniMax : IMiniMax
{
    public int FindBestMove(GameState gameState, int depth)
    {
        // If it's player 1s turn we want to maximise the score,
        // if it's player -1s turn we want to minimise the score
        int bestScore = int.MinValue;
        if (gameState.CurrentPlayer == -1)
        {
            bestScore = int.MaxValue;
        }

        int bestMove = -1;

        foreach (int move in gameState.GetValidMoves())
        {
            gameState.ApplyMove(move);
            int score = MiniMaxRecursive(gameState, depth - 1);
            gameState.UndoLastMove();

            if (gameState.CurrentPlayer == 1)
            {
                if (score > bestScore)
                {
                    bestScore = score;
                    bestMove = move;
                }
            }
            else
            {
                if (score < bestScore)
                {
                    bestScore = score;
                    bestMove = move;
                }
            }
        }

        return bestMove;
    }

    private int MiniMaxRecursive(GameState gameState, int depth)
    {
        if (depth <= 0 || gameState.IsTerminal())
        {
            int score = gameState.CalculateScore();
            return score + (Math.Sign(score) * depth);
        }

        List<int> validMoves = gameState.GetValidMoves();

        if ( gameState.CurrentPlayer == 1)
        {
            int maxScore = int.MinValue;

            foreach (int move in validMoves)
            {
                gameState.ApplyMove(move);
                int score = MiniMaxRecursive(gameState, depth - 1);
                gameState.UndoLastMove();

                maxScore = Math.Max(maxScore, score);
            }
            return maxScore;
        }
        else
        {
            int minScore = int.MaxValue;

            foreach (int move in validMoves)
            {
                gameState.ApplyMove(move);
                int score = MiniMaxRecursive(gameState, depth - 1);
                gameState.UndoLastMove();

                minScore = Math.Min(minScore, score);
            }
            return minScore;
        }
    }
}
