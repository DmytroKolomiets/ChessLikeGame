using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MoveExtention
{
    public static void GetBishoplMoves(this Cell[,] board, Piece piece)
    {
        // up right
        for (int i = 1; i < board.GetLength(0); i++)
        {
            if (piece.Coordinates.x + i >= board.GetLength(0) || piece.Coordinates.y + i >= board.GetLength(0))
                break;
            board[piece.Coordinates.x + i, piece.Coordinates.y + i].AllowMove();
            if (board[piece.Coordinates.x + i, piece.Coordinates.y + i].PlacedPiece)
                break;
        }
        // down left
        for (int i = 1; i < board.GetLength(0); i++)
        {
            if (piece.Coordinates.x - i < 0 || piece.Coordinates.y - i < 0)
                break;
            board[piece.Coordinates.x - i, piece.Coordinates.y - i].AllowMove();
            if (board[piece.Coordinates.x - i, piece.Coordinates.y - i].PlacedPiece)
                break;
        }
        // down right
        for (int i = 1; i < board.GetLength(0); i++)
        {
            if (piece.Coordinates.x + i >= board.GetLength(0) || piece.Coordinates.y - i < 0)
                break;
            board[piece.Coordinates.x + i, piece.Coordinates.y - i].AllowMove();
            if (board[piece.Coordinates.x + i, piece.Coordinates.y - i].PlacedPiece)
                break;
        }
        // up lef
        for (int i = 1; i < board.GetLength(0); i++)
        {
            if (piece.Coordinates.x - i < 0 || piece.Coordinates.y + i >= board.GetLength(0))
                break;
            board[piece.Coordinates.x - i, piece.Coordinates.y + i].AllowMove();
            if (board[piece.Coordinates.x - i, piece.Coordinates.y + i].PlacedPiece)
                break;
        }
    }
    public static void GetRookMoves(this Cell[,] board, Piece piece)
    {
        // rigjt
        for (int i = 1; i < board.GetLength(0); i++)
        {
            if (piece.Coordinates.x + i >= board.GetLength(0))
                break;
            board[piece.Coordinates.x + i, piece.Coordinates.y].AllowMove();
            if (board[piece.Coordinates.x + i, piece.Coordinates.y].PlacedPiece)
                break;
        }
        // left
        for (int i = 1; i < board.GetLength(0); i++)
        {
            if (piece.Coordinates.x - i < 0)
                break;
            board[piece.Coordinates.x - i, piece.Coordinates.y].AllowMove();
            if (board[piece.Coordinates.x - i, piece.Coordinates.y].PlacedPiece)
                break;
        }
        // up 
        for (int i = 1; i < board.GetLength(0); i++)
        {
            if (piece.Coordinates.y + i >= board.GetLength(0))
                break;
            board[piece.Coordinates.x, piece.Coordinates.y + i].AllowMove();
            if (board[piece.Coordinates.x, piece.Coordinates.y + i].PlacedPiece)
                break;
        }
        // down
        for (int i = 1; i < board.GetLength(0); i++)
        {
            if (piece.Coordinates.y - i < 0)
                break;
            board[piece.Coordinates.x, piece.Coordinates.y - i].AllowMove();
            if (board[piece.Coordinates.x, piece.Coordinates.y - i].PlacedPiece)
                break;
        }
    }
    public static void GetPawnMoves(this Cell[,] board, Piece piece)
    {
        int loopCount = piece.MoveCount == 0 ? 3 : 2;
        if (ExternalRules.Instance.IsUnpassantAlowed())
        {
            var previosPawnPosition = ExternalRules.Instance.TryReturnPreviosPawnPosition();
            if (piece.IsWhite)
            {
                board[previosPawnPosition.x, piece.Coordinates.y + 1].AllowMove();
            }
            else
            {
                board[previosPawnPosition.x, piece.Coordinates.y - 1].AllowMove();
            }
        }
        if (piece.IsWhite)
        {
            // up
            for (int i = 1; i < loopCount; i++)
            {
                if (piece.Coordinates.y + i >= board.GetLength(0))
                    break;
                if (board[piece.Coordinates.x, piece.Coordinates.y + i].PlacedPiece)
                    break;
                board[piece.Coordinates.x, piece.Coordinates.y + i].AllowMove();
            }

            // up right
            for (int i = 1; i < 2; i++)
            {
                if (piece.Coordinates.x + i >= board.GetLength(0) || piece.Coordinates.y + i >= board.GetLength(0))
                    break;
                if (board[piece.Coordinates.x + i, piece.Coordinates.y + i].PlacedPiece)
                    board[piece.Coordinates.x + i, piece.Coordinates.y + i].AllowMove();
            }
            // up lef
            for (int i = 1; i < 2; i++)
            {
                if (piece.Coordinates.x - i < 0 || piece.Coordinates.y + i >= board.GetLength(0))
                    break;

                if (board[piece.Coordinates.x - i, piece.Coordinates.y + i].PlacedPiece)
                    board[piece.Coordinates.x - i, piece.Coordinates.y + i].AllowMove();
            }
        }
        else
        {
            //down
            for (int i = 1; i < loopCount; i++)
            {
                if (piece.Coordinates.y - i < 0)
                    break;
                if (board[piece.Coordinates.x, piece.Coordinates.y - i].PlacedPiece)
                    break;
                board[piece.Coordinates.x, piece.Coordinates.y - i].AllowMove();
            }
            // down right
            for (int i = 1; i < 2; i++)
            {
                if (piece.Coordinates.x + i >= board.GetLength(0) || piece.Coordinates.y - i < 0)
                    break;
                if (board[piece.Coordinates.x + i, piece.Coordinates.y - i].PlacedPiece)
                    board[piece.Coordinates.x + i, piece.Coordinates.y - i].AllowMove();
            }
            // down left
            for (int i = 1; i < 2; i++)
            {
                if (piece.Coordinates.x - i < 0 || piece.Coordinates.y - i < 0)
                    break;
                if (board[piece.Coordinates.x - i, piece.Coordinates.y - i].PlacedPiece)
                    board[piece.Coordinates.x - i, piece.Coordinates.y - i].AllowMove();
            }
        }
    }
    public static void GetHorseMoves(this Cell[,] board, Piece piece)
    {
        // up
        for (int i = 1; i < 3; i++)
        {
            if (piece.Coordinates.y + 2 >= board.GetLength(0))
                break;
            if (piece.Coordinates.x + 1 < board.GetLength(0))
            {
                board[piece.Coordinates.x + 1, piece.Coordinates.y + 2].AllowMove();
            }
            if (piece.Coordinates.x - 1 >= 0)
            {
                board[piece.Coordinates.x - 1, piece.Coordinates.y + 2].AllowMove();
            }
        }
        // down
        for (int i = 1; i < 3; i++)
        {
            if (piece.Coordinates.y - 2 < 0)
                break;
            if (piece.Coordinates.x + 1 < board.GetLength(0))
            {
                board[piece.Coordinates.x + 1, piece.Coordinates.y - 2].AllowMove();
            }
            if (piece.Coordinates.x - 1 >= 0)
            {
                board[piece.Coordinates.x - 1, piece.Coordinates.y - 2].AllowMove();
            }
        }
        // rigth 
        for (int i = 1; i < 3; i++)
        {
            if (piece.Coordinates.x + 2 >= board.GetLength(0))
                break;
            if (piece.Coordinates.y + 1 < board.GetLength(0))
            {
                board[piece.Coordinates.x + 2, piece.Coordinates.y + 1].AllowMove();
            }
            if (piece.Coordinates.y - 1 >= 0)
            {
                board[piece.Coordinates.x + 2, piece.Coordinates.y - 1].AllowMove();
            }
        }
        // left 
        for (int i = 1; i < 3; i++)
        {
            if (piece.Coordinates.x - 2 < 0)
                break;
            if (piece.Coordinates.y + 1 < board.GetLength(0))
            {
                board[piece.Coordinates.x - 2, piece.Coordinates.y + 1].AllowMove();
            }
            if (piece.Coordinates.y - 1 >= 0)
            {
                board[piece.Coordinates.x - 2, piece.Coordinates.y - 1].AllowMove();
            }
        }
    }
    public static void GetKingMoves(this Cell[,] board, Piece piece)
    {
        // up right
        for (int i = 1; i < 2; i++)
        {
            if (piece.Coordinates.x + i >= board.GetLength(0) || piece.Coordinates.y + i >= board.GetLength(0))
                break;
            board[piece.Coordinates.x + i, piece.Coordinates.y + i].AllowMove();
            if (board[piece.Coordinates.x + i, piece.Coordinates.y + i].PlacedPiece)
                break;
        }
        // down left
        for (int i = 1; i < 2; i++)
        {
            if (piece.Coordinates.x - i < 0 || piece.Coordinates.y - i < 0)
                break;
            board[piece.Coordinates.x - i, piece.Coordinates.y - i].AllowMove();
            if (board[piece.Coordinates.x - i, piece.Coordinates.y - i].PlacedPiece)
                break;
        }
        // down right
        for (int i = 1; i < 2; i++)
        {
            if (piece.Coordinates.x + i >= board.GetLength(0) || piece.Coordinates.y - i < 0)
                break;
            board[piece.Coordinates.x + i, piece.Coordinates.y - i].AllowMove();
            if (board[piece.Coordinates.x + i, piece.Coordinates.y - i].PlacedPiece)
                break;
        }
        // up lef
        for (int i = 1; i < 2; i++)
        {
            if (piece.Coordinates.x - i < 0 || piece.Coordinates.y + i >= board.GetLength(0))
                break;
            board[piece.Coordinates.x - i, piece.Coordinates.y + i].AllowMove();
            if (board[piece.Coordinates.x - i, piece.Coordinates.y + i].PlacedPiece)
                break;
        }

        // rigjt
        for (int i = 1; i < 2; i++)
        {
            if (piece.Coordinates.x + i >= board.GetLength(0))
                break;
            board[piece.Coordinates.x + i, piece.Coordinates.y].AllowMove();
            if (board[piece.Coordinates.x + i, piece.Coordinates.y].PlacedPiece)
                break;
        }
        // left
        for (int i = 1; i < 2; i++)
        {
            if (piece.Coordinates.x - i < 0)
                break;
            board[piece.Coordinates.x - i, piece.Coordinates.y].AllowMove();
            if (board[piece.Coordinates.x - i, piece.Coordinates.y].PlacedPiece)
                break;
        }
        // up 
        for (int i = 1; i < 2; i++)
        {
            if (piece.Coordinates.y + i >= board.GetLength(0))
                break;
            board[piece.Coordinates.x, piece.Coordinates.y + i].AllowMove();
            if (board[piece.Coordinates.x, piece.Coordinates.y + i].PlacedPiece)
                break;
        }
        // down
        for (int i = 1; i < 2; i++)
        {
            if (piece.Coordinates.y - i < 0)
                break;
            board[piece.Coordinates.x, piece.Coordinates.y - i].AllowMove();
            if (board[piece.Coordinates.x, piece.Coordinates.y - i].PlacedPiece)
                break;
        }
    }
}
