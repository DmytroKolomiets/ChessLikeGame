using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;

public class Piece : MonoBehaviour
{

    [SerializeField] protected Board board;
    [SerializeField] private Image image;
    [SerializeField] private bool isWhite;
    [SerializeField] private PieceType pieceType;
    public int MoveCount { get; private set; }
    public bool IsWhite { get; private set; }
    private Cell currentCell;
    public Vector2Int Coordinates { get; private set; }
    private void Awake()
    {
        IsWhite = isWhite;
        image.sprite = pieceType.GetImage();
        if (isWhite)
        {
            image.color = new Color(0.7f, 0.8f, 0.3f);
        }
        else
        {
            image.color = new Color(0.3f, 0.3f, 1f);
        }
    }
    public bool IsPieceTypePawn()
    {
        return pieceType is Pawn;
    }
    public void Move(Cell cell)
    {
        currentCell?.TakeOutPiece();
        currentCell = cell;
        currentCell.PlacePiece(this);
        Coordinates = cell.Index;
        transform.position = cell.transform.position;        
        MoveCount++;
        ExternalRules.Instance.HandleUnPassant();
        ExternalRules.Instance.TrySetpreviosPawn(this);
        ExternalRules.Instance.TryQueenUpgrade();
    }
    public void GetPossibleMoves()
    {
        pieceType.GetPossibleMoves(board.Cells, this);
    }
    public void Upgrade()
    {
        pieceType = pieceType.GetUpgrade();
        image.sprite = pieceType.GetImage();
    }
    public void UpgradeTo(PieceType pieceType)
    {
        this.pieceType = pieceType.GetUpgrade();
        image.sprite = pieceType.GetImage();
    }
    public void ToStart()
    {
        Coordinates = pieceType.ToStart(IsWhite);
        Move(board.Cells[Coordinates.x, Coordinates.y]);
        MoveCount = 0;
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
