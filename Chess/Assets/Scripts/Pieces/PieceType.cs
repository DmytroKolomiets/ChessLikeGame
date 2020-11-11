using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PieceType : MonoBehaviour
{
    [SerializeField] private Sprite whiteSprite;
    [SerializeField] private Sprite blackSprite;
    public abstract void GetPossibleMoves(Cell[,] board, Vector2Int coordinates, bool isWhite);
    public abstract Vector2Int ToStart(bool isWhite);
}
