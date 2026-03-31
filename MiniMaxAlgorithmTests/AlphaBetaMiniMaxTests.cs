using Connect4;
using System.Collections.Generic;
using MiniMaxAlgoritm;
using NUnit.Framework;

namespace MiniMaxAlgorithmTests;

public class AlphaBetaMiniMaxTests : MiniMaxTestBase
{
    protected override IMiniMax CreateMiniMax() => new MiniMax();
}
