using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PieceType : MonoBehaviour
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private PieceType nextUpgrade;

    public PieceType GetUpgrade()
    {
        return nextUpgrade;
    }
    public Sprite GetImage()
    {
        return sprite;
    }
    public abstract void GetPossibleMoves(Cell[,] board, Piece piece);
    public abstract Vector2Int ToStart(bool isWhite);
}
