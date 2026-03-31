using Connect4;

namespace MiniMaxAlgoritm;

public interface IMiniMax
{
    public int FindBestMove(GameState board, int depth);

    public int GetNodesVisited();
}
