using Connect4;
using System.Collections.Generic;
using MiniMaxAlgoritm;
using NUnit.Framework;

namespace MiniMaxAlgorithmTests;

public abstract class MiniMaxTestBase
{
    protected abstract IMiniMax CreateMiniMax();

    #region Win in 1

    [Test]
    public void TestTerminalMove_Player1_HorizontalWin_Depth1()
    {
        GameState boardState = new GameState();
        boardState.SetGameStateFromPlay(new List<int> { 0, 0, 1, 1, 2, 2 });

        IMiniMax minimax = CreateMiniMax();
        int bestMove = minimax.FindBestMove(boardState, 1);

        Assert.AreEqual(3, bestMove);
    }

    [Test]
    public void TestTerminalMove_Player1_VerticalWin_Depth1()
    {
        GameState boardState = new GameState();

        int[,] board = new int[,]
        {
            { 0,  0,  0, 0, 0, 0, 0 },
            { 0,  0,  0, 0, 0, 0, 0 },
            { 0,  0,  0, 0, 0, 0, 0 },
            { 1,  0,  0, 0, 0, 0, 0 },
            { 1, -1,  0, 0, 0, 0, 0 },
            { 1, -1, -1, 0, 0, 0, 0 }
        };

        boardState.SetGameState(board, 1);

        IMiniMax minimax = CreateMiniMax();
        int bestMove = minimax.FindBestMove(boardState, 1);

        Assert.AreEqual(0, bestMove);
    }

    [Test]
    public void TestTerminalMove_Player1_DiagonalDownRightWinNextMove_Depth1()
    {
        GameState boardState = new GameState();

        int[,] board = new int[,]
        {
            {  0,  0,  0, 0, 0, 0, 0 },
            {  1,  0,  0, 0, 0, 0, 0 },
            {  1,  0,  0, 0, 0, 0, 0 },
            { -1,  1,  0, 0, 0, 0, 0 },
            { -1, -1,  1, 0, 0, 0, 0 },
            {  1, -1, -1, 0, 0, 0, 0 }
        };

        boardState.SetGameState(board, 1);

        IMiniMax minimax = CreateMiniMax();
        int bestMove = minimax.FindBestMove(boardState, 1);

        Assert.AreEqual(3, bestMove);
    }

    [Test]
    public void TestTerminalMove_Player1_DiagonalUpRightWinNextMove_Depth1()
    {
        GameState boardState = new GameState();

        int[,] board = new int[,]
        {
            { 0, 0, 0,  0,  0,  0, 0 },
            { 0, 0, 0,  0,  0,  0, 0 },
            { 0, 0, 0,  0,  0,  1, 0 },
            { 0, 0, 0,  0,  1, -1, 0 },
            { 0, 0, 0,  1, -1, -1, 0 },
            { 0, 0, 0, -1,  1, -1, 0 }
        };

        boardState.SetGameState(board, 1);

        IMiniMax minimax = CreateMiniMax();
        int bestMove = minimax.FindBestMove(boardState, 1);

        Assert.AreEqual(2, bestMove);
    }

    [Test]
    public void TestTerminalMove_Player2_HorizontalWin_Depth1()
    {
        GameState boardState = new GameState();
        boardState.SetGameStateFromPlay(new List<int> { 0, 1, 0, 2, 1, 3, 2 });

        IMiniMax minimax = CreateMiniMax();
        int bestMove = minimax.FindBestMove(boardState, 1);

        Assert.AreEqual(4, bestMove);
    }

    [Test]
    public void TestTerminalMove_Player2_VerticalWin_Depth1()
    {
        GameState boardState = new GameState();

        int[,] board = new int[,]
        {
            { 0, 0, 0, 0,  0, 0, 0 },
            { 0, 0, 0, 0,  0, 0, 0 },
            { 0, 0, 0, 0,  0, 0, 0 },
            { 0, 0, 0, 0, -1, 0, 0 },
            { 0, 0, 0, 1, -1, 0, 0 },
            { 0, 0, 1, 1, -1, 0, 0 }
        };

        boardState.SetGameState(board, -1);

        IMiniMax minimax = CreateMiniMax();
        int bestMove = minimax.FindBestMove(boardState, 0);

        Assert.AreEqual(4, bestMove);
    }

    #endregion

    #region Block in 2

    [Test]
    public void TestTerminalMove_Player1_BlockHorizontalWin_Depth2()
    {
        GameState boardState = new GameState();
        boardState.SetGameStateFromPlay(new List<int> { 0, 1, 0, 2, 1, 3 });

        IMiniMax minimax = CreateMiniMax();
        int bestMove = minimax.FindBestMove(boardState, 2);

        Assert.AreEqual(4, bestMove);
    }

    [Test]
    public void TestTerminalMove_Player1_BlockVerticalWin_Depth2()
    {
        GameState boardState = new GameState();

        int[,] board = new int[,]
        {
            { 0, 0, 0,  0, 0, 0, 0 },
            { 0, 0, 0,  0, 0, 0, 0 },
            { 0, 0, 0,  0, 0, 0, 0 },
            { 0, 0, 0, -1, 0, 0, 0 },
            { 0, 0, 1, -1, 0, 0, 0 },
            { 0, 1, 1, -1, 0, 0, 0 }
        };

        boardState.SetGameState(board, 1);

        IMiniMax minimax = CreateMiniMax();
        int bestMove = minimax.FindBestMove(boardState, 2);

        Assert.AreEqual(3, bestMove);
    }

    [Test]
    public void TestTerminalMove_Player2_BlockVerticalWin_Depth2()
    {
        GameState boardState = new GameState();

        int[,] board = new int[,]
        {
            { 0, 0, 0,  0,  0, 0, 0 },
            { 0, 0, 0,  0,  0, 0, 0 },
            { 0, 0, 0,  0,  0, 0, 0 },
            { 0, 0, 0,  0,  0, 1, 0 },
            { 0, 0, 0,  0, -1, 1, 0 },
            { 0, 0, 0, -1, -1, 1, 0 }
        };

        boardState.SetGameState(board, -1);

        IMiniMax minimax = CreateMiniMax();
        int bestMove = minimax.FindBestMove(boardState, 2);

        Assert.AreEqual(5, bestMove);
    }

    [Test]
    public void TestTerminalMove_Player2_BlockHorizontalWin_Depth2()
    {
        GameState boardState = new GameState();
        boardState.SetGameStateFromPlay(new List<int> { 6, 5, 6, 5, 6 });

        IMiniMax minimax = CreateMiniMax();
        int bestMove = minimax.FindBestMove(boardState, 2);

        Assert.AreEqual(6, bestMove);
    }

    [Test]
    public void TestTerminalMove_Player1_BlockDiagonalWin_Depth2()
    {
        GameState boardState = new GameState();

        int[,] board = new int[,]
        {
            {  0,  0,  0,  0,  0, 0, 0 },
            {  0,  0,  1,  0,  0, 0, 0 },
            {  0,  0, -1,  0,  0, 0, 0 },
            {  0,  1, -1, -1,  0, 0, 0 },
            { -1,  1,  1,  1, -1, 0, 0 },
            {  1, -1, -1,  1, -1, 0, 0 }
        };

        boardState.SetGameState(board, 1);

        IMiniMax minimax = CreateMiniMax();
        int bestMove = minimax.FindBestMove(boardState, 2);

        Assert.AreEqual(5, bestMove);
    }

    [Test]
    public void TestTerminalMove_Player2_BlockHorizontalWin_MiddleGap_Depth2()
    {
        GameState boardState = new GameState();

        int[,] board = new int[,]
        {
            { 0,  0, 0, 0,  0, 0, 0 },
            { 0,  0, 0, 0,  0, 0, 0 },
            { 0,  0, 0, 0,  0, 0, 0 },
            { 0,  0, 0, 0,  0, 0, 0 },
            { 0, -1, 0, 0,  0, 0, 0 },
            { 1,  1, 0, 1, -1, 0, 0 }
        };

        boardState.SetGameState(board, -1);

        IMiniMax minimax = CreateMiniMax();
        int bestMove = minimax.FindBestMove(boardState, 2);

        Assert.AreEqual(2, bestMove);
    }

    #endregion

    #region win in 3

    [Test]
    public void TestTerminalMove_Player1_ForcedHorizontalWin_Depth3()
    {
        GameState boardState = new GameState();

        int[,] board = new int[,]
        {
            {  0,  0,  0, 0,  0, 0,  0 },
            {  0,  0,  0, 0,  0, 0,  0 },
            { -1, -1, -1, 0,  0, 0,  0 },
            {  1,  1,  1, 0,  0, 0,  0 },
            {  1,  1,  1, 0, -1, 0, -1 },
            {  1, -1,  1, 0, -1, 0, -1 }
        };

        boardState.SetGameState(board, 1);

        IMiniMax minimax = CreateMiniMax();
        int bestMove = minimax.FindBestMove(boardState, 3);

        Assert.AreEqual(3, bestMove);
    }

    #endregion

    [Test]
    public void Chooses_Faster_Win_Over_Slower_Win()
    {
        int[,] board = new int[,]
        {
            {  0,  0,  0, 0,  0, 0,  0 },
            { -1,  0, -1, 0,  0, 0,  0 },
            { -1, -1, -1, 0,  0, 0,  0 },
            {  1,  1,  1, 0,  0, 1,  0 },
            {  1,  1,  1, 0, -1, 1, -1 },
            {  1, -1,  1, 0, -1, 1, -1 }
        };

        GameState boardState = new GameState();
        boardState.SetGameState(board, 1);

        IMiniMax minimax = CreateMiniMax();
        int bestMove = minimax.FindBestMove(boardState, 3);

        Assert.AreEqual(5, bestMove);
    }
}