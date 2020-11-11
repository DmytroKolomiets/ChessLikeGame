using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class Piece : MonoBehaviour
{

    [SerializeField] protected Board board;
    [SerializeField] private bool isWhite;
    [SerializeField] private PieceType pieceType;
    public bool IsWhite { get; private set; }
    private Cell currentCell;
    public Vector2Int Coordinates { get; private set; }
    private void Awake()
    {
        IsWhite = isWhite;
    }
    public void Move(Cell cell)
    {
        currentCell?.TakeOutPiece();
        currentCell = cell;
        currentCell.PlacePiece(this);
        Coordinates = cell.Index;
        transform.position = cell.transform.position;
    }
    public virtual void GetPossibleMoves()
    {
        pieceType.GetPossibleMoves(board.Cells, Coordinates, IsWhite);
    }
    public void Upgrade()
    {

    }
    public virtual void ToStart()
    {
        Coordinates = pieceType.ToStart(IsWhite);
        Move(board.Cells[Coordinates.x, Coordinates.y]);
    }
}
