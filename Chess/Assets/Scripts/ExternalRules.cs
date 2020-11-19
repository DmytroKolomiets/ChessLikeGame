using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalRules : MonoBehaviour
{
    public static ExternalRules Instance { get; private set; }
    private Piece previosPawn;
    private Piece currentPawn;
    [SerializeField] private PieceType Queen;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    public void HandleUnPassant()
    {
        if (!previosPawn || !currentPawn)
            return;
        if (previosPawn.Coordinates.x == currentPawn.Coordinates.x)
        {
            if (previosPawn.MoveCount != 1)
                return;
            if (currentPawn.IsWhite &&
                previosPawn.Coordinates.y + 1 == currentPawn.Coordinates.y
                && previosPawn.Coordinates.x == currentPawn.Coordinates.x)
            {
                EnPassant();
            }
            else if (currentPawn.IsWhite == false &&
                previosPawn.Coordinates.y - 1 == currentPawn.Coordinates.y
                && previosPawn.Coordinates.x == currentPawn.Coordinates.x)
            {
                EnPassant();
            }
        }
    }
    public bool IsUnpassantAlowed()
    {
        if (!previosPawn)
            return false;
        if (previosPawn.MoveCount != 1)
            return false;
        if (previosPawn.Coordinates.x - 1 == currentPawn.Coordinates.x
                && previosPawn.Coordinates.y == currentPawn.Coordinates.y
                || previosPawn.Coordinates.x + 1 == currentPawn.Coordinates.x
                && previosPawn.Coordinates.y == currentPawn.Coordinates.y)
        {
            return true;
        }
        return false;
    }
    public void TrySetpreviosPawn(Piece piece)
    {
        if (piece.IsPieceTypePawn())
        {
            previosPawn = piece;
        }
        else
            previosPawn = null;
    }
    public void TrySetCurrentPawn(Piece piece)
    {
        if (piece.IsPieceTypePawn())
        {
            currentPawn = piece;
        }
        else
            currentPawn = null;
    }
    public Vector2Int TryReturnPreviosPawnPosition()
    {
        if (previosPawn)
        {
            return previosPawn.Coordinates;
        }
        return new Vector2Int();
    }
    public void TryQueenUpgrade()
    {
        if (!previosPawn)
            return;
        if(previosPawn.IsWhite && previosPawn.Coordinates.y == 7)
        {
            previosPawn.UpgradeTo(Queen);
        }
        else if (!previosPawn.IsWhite && previosPawn.Coordinates.y == 0)
        {
            previosPawn.UpgradeTo(Queen);
        }
        
    }
    private void EnPassant()
    {
        Destroy(previosPawn.gameObject);
        currentPawn.Upgrade();
    }
}
