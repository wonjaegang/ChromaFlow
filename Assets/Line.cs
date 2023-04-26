using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public GameObject UpperEnd;
    public GameObject MiddleLine;
    public GameObject DownEnd;

    public float[] Pos;
    public float width;
    public float length;
    public Color color;
    public string style;
    
    public void SetLine()
    {
        SetStyle();
        SetScale();
        SetLocation();
        SetLineColor();
    }

    public void SetLineColor()
    {
        UpperEnd.GetComponent<SpriteRenderer>().color = color;
        MiddleLine.GetComponent<SpriteRenderer>().color = color;
        DownEnd.GetComponent<SpriteRenderer>().color = color;
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

    public void SetStyle()
    {
        switch (style)
        {
            case "ac":
                break;

            case "nl":
                break;

            case "nr":
                break;

            case "al":
                break;

            case "ar":
                break;

            default:
                break;
        }
    }
}
