using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : PieceType
{
    public override void GetPossibleMoves(Cell[,] board, Piece piece)
    {
        board.GetBishoplMoves(piece);
        board.GetRookMoves(piece);
    }
    public override Vector2Int ToStart(bool isWhite)
    {
        if (isWhite)
        {
            return new Vector2Int(3, 0);
        }
        else
        {
            return new Vector2Int(3, 7);
        }
    }
}