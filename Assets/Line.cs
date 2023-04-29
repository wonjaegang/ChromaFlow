using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public GameObject UpperEnd;
    public GameObject MiddleLine;
    public GameObject DownEnd;
    public GameObject Arrow;

    public float[] Pos;
    public float width;
    public float length;
    public Color LineColor;
    public int LayerOrder;

    public void SetLine()
    {
        SetScale();
        SetLocation();
        SetLineColor();
        SetOrder();
    }

    public void SetLineColor()
    {
        UpperEnd.GetComponent<SpriteRenderer>().color = LineColor;
        MiddleLine.GetComponent<SpriteRenderer>().color = LineColor;
        DownEnd.GetComponent<SpriteRenderer>().color = LineColor;
    }

    public void SetLocation()
    {
        MiddleLine.GetComponent<Transform>().position = new Vector3(Pos[0], Pos[1], 0);
        MiddleLine.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, Pos[2]);

        float endX = -Mathf.Sin(Pos[2] * Mathf.Deg2Rad) * length / 2;
        float endY = Mathf.Cos(Pos[2] * Mathf.Deg2Rad) * length / 2;
        UpperEnd.GetComponent<Transform>().position = new Vector3(Pos[0] + endX, Pos[1] + endY, 0);
        UpperEnd.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, Pos[2]);
        DownEnd.GetComponent<Transform>().position = new Vector3(Pos[0] - endX, Pos[1] - endY, 0);
        DownEnd.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, Pos[2]);
    }

    public void SetScale()
    {
        UpperEnd.GetComponent<Transform>().localScale = new Vector3(width, width, 0);
        MiddleLine.GetComponent<Transform>().localScale = new Vector3(width, length, 0);
        DownEnd.GetComponent<Transform>().localScale = new Vector3(width, width, 0);
    }

    public void SetOrder()
    {
        UpperEnd.GetComponent<SpriteRenderer>().sortingOrder = LayerOrder;
        MiddleLine.GetComponent<SpriteRenderer>().sortingOrder = LayerOrder;
        DownEnd.GetComponent<SpriteRenderer>().sortingOrder = LayerOrder;
    }

    public void SetStyle(string style, Color color)
    {
        if (style == "Arrow")
        {
            Arrow.SetActive(true);
            Arrow.GetComponent<Transform>().position = new Vector3(Pos[0], Pos[1], 0);
            Arrow.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, Pos[2]);
            Arrow.GetComponent<SpriteRenderer>().color = color;
            Arrow.GetComponent<Transform>().localScale = new Vector3((float)(width * 0.7), width, 0);
            Arrow.GetComponent<SpriteRenderer>().sortingOrder = LayerOrder;
        }
    }
}
