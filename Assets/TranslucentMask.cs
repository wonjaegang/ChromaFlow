using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TranslucentMask : MonoBehaviour
{
    public void SetMaskColor(Color UpperColor, Color MiddleColor, Color LowerColor)
    {
        transform.GetChild(0).GetComponent<Image>().color = UpperColor;
        transform.GetChild(1).GetComponent<Image>().color = MiddleColor;
        transform.GetChild(2).GetComponent<Image>().color = LowerColor;
    }
}
