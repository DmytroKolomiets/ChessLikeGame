using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : PieceType
{
    public override void GetPossibleMoves(Cell[,] board, Piece piece)
    {
        board.GetKingMoves(piece);
    }

    public override Vector2Int ToStart(bool isWhite)
    {
        if (isWhite)
        {
           return new Vector2Int(4, 0);
        }
        else
        {
            return new Vector2Int(4, 7);
        }
    }
}
