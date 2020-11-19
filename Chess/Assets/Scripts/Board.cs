using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    [SerializeField] private Transform board;
    [SerializeField] private RectTransform cellTransform;
    private Vector2Int BoradSize = new Vector2Int(8, 8);
    public Cell[,] Cells { get; private set; }
    [SerializeField] private Cell cell;

    private void Start()
    {
        CreatBoard();
    }
    private void CreatBoard()
    {
        Cells = new Cell[BoradSize.x, BoradSize.y];
        for (int x = 0; x < BoradSize.x; x++)
        {
            for (int y = 0; y < BoradSize.y; y++)
            {
                Cells[x, y] = Instantiate(cell, board);
                Cells[x, y].GetComponent<RectTransform>().localPosition =
                    new Vector3(x * cellTransform.rect.width + cellTransform.rect.width / 2f,
                    y * cellTransform.rect.width + cellTransform.rect.width, 0);
                Cells[x, y].transform.parent = board;
                Cells[x, y].SetIndex(x, y);
                Cells[x, y].SetStartColor(GetCellColor(y, x));
            }
        }
    }
    private Color GetCellColor(int x, int y)
    {
        if ((x + y) % 2 == 0)
        {
            return Color.black;
        }
        else
        {
            return Color.white;           
        }
    }
}
