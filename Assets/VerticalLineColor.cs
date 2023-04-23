using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalLineColor : MonoBehaviour
{
    public GameObject UpperEnd;
    public GameObject MiddleLine;
    public GameObject DownEnd;

    public void SetVerticalLineColor(Color color)
    {
        UpperEnd.GetComponent<SpriteRenderer>().color = color;
        MiddleLine.GetComponent<SpriteRenderer>().color = color;
        DownEnd.GetComponent<SpriteRenderer>().color = color;
    }
}
