using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToe
{
    public static List<List<int>> GenerateBoard()
    {
        // 1. Create empty board
        List<List<int>> board = new List<List<int>>();
        for(int r = 0; r < 3; r++)
        {
            List<int> row = new List<int>();
            for(int c = 0; c < 3; c++) row.Add(0);
            board.Add(row);
        }

        // 2. Play
        int turn = 1;
        while(!IsBoardFull(board) && !CheckWin(board)) // No han ganado y se puede jugar...
        {
            int r = Random.Range(0, 3);
            int c = Random.Range(0, 3);
            while (board[r][c] != 0)
            {
                r = Random.Range(0, 3);
                c = Random.Range(0, 3);
            }
            //Debug.Log("[" + r + "]" + "[" + c + "]=" + turn);
            board[r][c] = turn;
            if (turn == 1) turn = 2;
            else turn = 1;
        }
        return board;
    }

    public static bool IsBoardFull(List<List<int>> board)
    {
        foreach(List<int> row in board)
            if (row[0] == 0 || row[1] == 0 || row[2] == 0) return false;
        return true;
    }

    public static bool CheckWin(List<List<int>> b)
    {
        if (b[0][0] != 0 && b[0][0] == b[0][1] && b[0][1] == b[0][2]) return true;
        if (b[1][0] != 0 && b[1][0] == b[1][1] && b[1][1] == b[1][2]) return true;
        if (b[2][0] != 0 && b[2][0] == b[2][1] && b[2][1] == b[2][2]) return true;

        if (b[0][0] != 0 && b[0][0] == b[1][0] && b[1][0] == b[2][0]) return true;
        if (b[0][1] != 0 && b[0][1] == b[1][1] && b[1][1] == b[2][1]) return true;
        if (b[0][2] != 0 && b[0][2] == b[1][2] && b[1][2] == b[2][2]) return true;

        if (b[0][0] != 0 && b[0][0] == b[1][1] && b[1][1] == b[2][2]) return true;
        if (b[0][2] != 0 && b[0][2] == b[1][1] && b[1][1] == b[2][0]) return true;

        return false;
    }
}
