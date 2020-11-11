using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MoveExtention
{
    public static void GetBishoplMoves(this Cell[,] board, Vector2Int coordinates)
    {
        // up right
        for (int i = 1; i < board.GetLength(0); i++)
        {
            if (coordinates.x + i >= board.GetLength(0) || coordinates.y + i >= board.GetLength(0))
                break;
            board[coordinates.x + i, coordinates.y + i].AllowMove();
            if (board[coordinates.x + i, coordinates.y + i].PlacedPiece)
                break;
        }
        // down left
        for (int i = 1; i < board.GetLength(0); i++)
        {
            if (coordinates.x - i < 0 || coordinates.y - i < 0)
                break;
            board[coordinates.x - i, coordinates.y - i].AllowMove();
            if (board[coordinates.x - i, coordinates.y - i].PlacedPiece)
                break;
        }
        // down right
        for (int i = 1; i < board.GetLength(0); i++)
        {
            if (coordinates.x + i >= board.GetLength(0) || coordinates.y - i < 0)
                break;
            board[coordinates.x + i, coordinates.y - i].AllowMove();
            if (board[coordinates.x + i, coordinates.y - i].PlacedPiece)
                break;
        }
        // up lef
        for (int i = 1; i < board.GetLength(0); i++)
        {
            if (coordinates.x - i < 0 || coordinates.y + i >= board.GetLength(0))
                break;
            board[coordinates.x - i, coordinates.y + i].AllowMove();
            if (board[coordinates.x - i, coordinates.y + i].PlacedPiece)
                break;
        }
    }
    public static void GetRoolMoves(this Cell[,] board, Vector2Int coordinates)
    {
        // rigjt
        for (int i = 1; i < board.GetLength(0); i++)
        {
            if (coordinates.x + i >= board.GetLength(0))
                break;
            board[coordinates.x + i, coordinates.y].AllowMove();
            if (board[coordinates.x + i, coordinates.y].PlacedPiece)
                break;
        }
        // left
        for (int i = 1; i < board.GetLength(0); i++)
        {
            if (coordinates.x - i < 0)
                break;
            board[coordinates.x - i, coordinates.y].AllowMove();
            if (board[coordinates.x - i, coordinates.y].PlacedPiece)
                break;
        }
        // up 
        for (int i = 1; i < board.GetLength(0); i++)
        {
            if (coordinates.y + i >= board.GetLength(0))
                break;
            board[coordinates.x, coordinates.y + i].AllowMove();
            if (board[coordinates.x, coordinates.y + i].PlacedPiece)
                break;
        }
        // down
        for (int i = 1; i < board.GetLength(0); i++)
        {
            if (coordinates.y - i < 0)
                break;
            board[coordinates.x, coordinates.y - i].AllowMove();
            if (board[coordinates.x, coordinates.y - i].PlacedPiece)
                break;
        }
    }
}
