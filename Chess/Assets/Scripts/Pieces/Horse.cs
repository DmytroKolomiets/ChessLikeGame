using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : PieceType
{
    public override void GetPossibleMoves(Cell[,] board, Piece piece)
    {
        board.GetHorseMoves(piece);
    }
    public override Vector2Int ToStart(bool isWhite)
    {
        return new Vector2Int();
    }
}
