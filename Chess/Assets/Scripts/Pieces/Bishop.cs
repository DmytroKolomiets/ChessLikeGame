using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : PieceType
{
    public override void GetPossibleMoves(Cell[,] board, Vector2Int coordinates, bool isWhite)
    {
        board.GetBishoplMoves(coordinates);
    }
    public override Vector2Int ToStart(bool isWhite)
    {
        if (isWhite)
        {
            return new Vector2Int(2, 0);
        }
        else
        {
            return new Vector2Int(2, 7);
        }
    }
}
