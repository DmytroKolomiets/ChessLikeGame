using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : PieceType
{
    private static int whitePawnCount = -1;
    private static int blackPawnCount = -1;
    public override void GetPossibleMoves(Cell[,] board, Piece piece)
    {
        board.GetPawnMoves(piece);
    }
    public override Vector2Int ToStart(bool isWhite)
    {
        if (isWhite)
        {
            whitePawnCount++;
            if (whitePawnCount > 7)
            {
                return new Vector2Int(0 + (whitePawnCount % 8), 1);
            }
            return new Vector2Int(0 + whitePawnCount, 0);
        }
        else
        {
            blackPawnCount++;
            if (blackPawnCount > 7)
            {
                return new Vector2Int(0 + (blackPawnCount % 8) , 6);
            }
            return new Vector2Int(0 + blackPawnCount, 7);
        }
    }
}
