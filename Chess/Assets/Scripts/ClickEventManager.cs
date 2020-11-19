using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEventManager : MonoBehaviour
{
    [SerializeField] private MovePieces movePieces;
    public void HandleClick(Cell cell)
    {
        if (movePieces.pieceToMove)
        {
            if (cell.IsMoveAllowed)
            {
                movePieces.MovePiece(cell);
            }
            movePieces.pieceToMove = null;
            Cell.Unselect();

        }
        else if(cell.PlacedPiece)
        {
            movePieces.pieceToMove = cell.PlacedPiece;
            ExternalRules.Instance.TrySetCurrentPawn(cell.PlacedPiece);
            movePieces.pieceToMove.GetPossibleMoves();
        }
        else
        {
            Cell.Unselect();
        }
    }
}
