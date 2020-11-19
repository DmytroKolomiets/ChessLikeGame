using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Cell : MonoBehaviour, IPointerClickHandler
{
    public Piece PlacedPiece { get; private set; }
    [SerializeField] private Image image;
    private Color startColor;
    public static Action Unselect { get; private set; }
    public Vector2Int Index { get; private set; }
    public bool IsMoveAllowed { get; private set; }
    [SerializeField] private ClickEventManager clickManager;
    private void Start()
    {
        Unselect += ToStartState;
    }
    public void SetStartColor(Color color)
    {
        image.color = color;
        startColor = color;
    }
    public void PlacePiece(Piece piece) 
    {
        if(PlacedPiece != null)
        {
            PlacedPiece.Destroy();
            piece.Upgrade();
        }
        PlacedPiece = piece;
    }
    public void TakeOutPiece() 
    {
        PlacedPiece = null;
    }
    public bool IsTaken()
    {
        return PlacedPiece; 
    }
    public void SetIndex(int x, int y)
    {
        Index = new Vector2Int(x, y);
    }
    public void AllowMove()
    {
        image.color = Color.red;
        IsMoveAllowed = true;
    }
    private void ToStartState()
    {
        image.color = startColor;
        IsMoveAllowed = false;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        clickManager.HandleClick(this);
    }
}
