using Connect4;
using System.Collections.Generic;
using MiniMaxAlgoritm;
using NUnit.Framework;

namespace MiniMaxAlgorithmTests;

[TestFixture(false, false, TestName = "AlphaBeta")]
[TestFixture(true, false, TestName = "AlphaBeta_MoveOrdering")]
[TestFixture(false, true, TestName = "AlphaBeta_TransPosition")]
[TestFixture(true, true, TestName = "AlphaBeta_MoveOrdering_TransPosition")]
public class AlphaBetaMiniMaxTests : MiniMaxTestBase
{
    private readonly bool _applyMoveOrdering;
    private readonly bool _applyTranspositionTable;

    public AlphaBetaMiniMaxTests(bool applyMoveOrdering, bool applyTranspositionTale)
    {
        _applyMoveOrdering = applyMoveOrdering;
        _applyTranspositionTable =applyTranspositionTale;
    }

    protected override IMiniMax CreateMiniMax()
    {
        AlphaBetaMiniMax minimax = new AlphaBetaMiniMax();
        minimax.ApplyMoveOrdering = _applyMoveOrdering;
        minimax.ApplyTranspositionTable = _applyTranspositionTable;

        return minimax;
    }
}
