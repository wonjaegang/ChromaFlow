using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public List<List<string>> Data;
    public GameObject Marker;
    public GameObject VerticalLine;

    public float InputMarkerY;
    public float BoardSideMargin;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DrawBoard()
    {
        int VerticalLineNum = Data[0].Count;
        for (int column = 0; column < VerticalLineNum; column++)
        {
            float Pos_x = 0;
            
            int HorizontalObjNum = Data.Count;
            for (int row = 0; row < HorizontalObjNum; row++)
            {
                float Pos_y = 0;
            }


        }
    }
}
