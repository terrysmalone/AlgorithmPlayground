using Connect4;
using System.Collections.Generic;
using MiniMaxAlgoritm;
using NUnit.Framework;

namespace MiniMaxAlgorithmTests;

public class MiniMaxTests
{
    [Test]
    public void TestTerminalMove_Player1_HorizontalWinNextMove()
    {
        GameState boardState = new GameState();

        // Player 1 can win in one move with 3
        boardState.SetGameStateFromPlay(new List<int> { 0, 0, 1, 1, 2, 2 });

        MiniMax minimax = new MiniMax();
        int bestMove = minimax.FindBestMove(boardState, 0);

        Assert.AreEqual(3, bestMove);
    }

    [Test]
    public void TestTerminalMove_Player2_HorizontalWinNextMove()
    {
        GameState boardState = new GameState();

        // Player 2 can win in one move with 4
        boardState.SetGameStateFromPlay(new List<int> { 0, 1, 0, 2, 1, 3, 2 });

        MiniMax minimax = new MiniMax();
        int bestMove = minimax.FindBestMove(boardState, 0);

        Assert.AreEqual(4, bestMove);
    }

    [Test]
    public void TestTerminalMove_Player1_BlockhorizontalWinNextMove()
    {
        GameState boardState = new GameState();

        // Player 1 can block a win next move move with 4
        boardState.SetGameStateFromPlay(new List<int> { 0, 1, 0, 2, 1, 3 });

        MiniMax minimax = new MiniMax();
        int bestMove = minimax.FindBestMove(boardState, 1);

        Assert.AreEqual(4, bestMove);
    }

    [Test]
    public void TestTerminalMove_Player2_BlockHorizontalWinNextMove()
    {
        GameState boardState = new GameState();

        // Player 1 can block a win next move move with 6
        boardState.SetGameStateFromPlay(new List<int> { 6, 5, 6, 5, 6 });

        MiniMax minimax = new MiniMax();
        int bestMove = minimax.FindBestMove(boardState, 1);

        Assert.AreEqual(6, bestMove);
    }

    [Test]
    public void TestTerminalMove_Player1_ForcedHorizontalWinIn2()
    {
        GameState boardState = new GameState();

        // Player 1 has a win with 3, 3, 3
        int[,] board = new int[,]
        {
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { 2, 2, 2, 0, 0, 0, 0 },
            { 1, 1, 1, 0, 0, 0, 0 },
            { 1, 1, 1, 0, 2, 0, 2 },
            { 1, 2, 1, 0, 2, 0, 2 }
        };

        boardState.SetGameState(board, 1);

        MiniMax minimax = new MiniMax();

        int bestMove = minimax.FindBestMove(boardState, 2);
        Assert.AreEqual(3, bestMove);
    }
}
