using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
public class MovePieces : MonoBehaviour
{
    [SerializeField] private  Board board;
    public Piece pieceToMove;
    [SerializeField] Vector2Int CellForPlace;
    [SerializeField] private Piece[] AllPiece;

    private void Start()
    {
        foreach (var item in AllPiece)
        {
            item.ToStart();
        }
    }
    private void MovePiece()
    {
        pieceToMove.Move(board.Cells[CellForPlace.x, CellForPlace.y]);
    }
    public void MovePiece(Cell cell)
    {
        pieceToMove.Move(cell);
    }
}
