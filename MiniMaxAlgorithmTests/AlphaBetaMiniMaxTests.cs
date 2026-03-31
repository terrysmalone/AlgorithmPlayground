using Connect4;
using System.Collections.Generic;
using MiniMaxAlgoritm;
using NUnit.Framework;

namespace MiniMaxAlgorithmTests;

[TestFixture(false)]
[TestFixture(true)]
public class AlphaBetaMiniMaxTests : MiniMaxTestBase
{
    private readonly bool _applyMoveOrdering;

    public AlphaBetaMiniMaxTests(bool applyMoveOrdering)
    {
        _applyMoveOrdering = applyMoveOrdering;
    }

    protected override IMiniMax CreateMiniMax() =>
        new AlphaBetaMiniMax { ApplyMoveOrdering = _applyMoveOrdering };
}
