using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public List<List<string>> Data;
    public GameObject Marker;
    public GameObject VerticalLine;

    // 월드포인트 기준
    public float BoardSideMargin;
    public float MarkerOffset;
    public float VerticalLineY;
    private readonly float VerticalLineLength = 5.0f;

    private float CameraWidth;
    private float CameraHeight;

    private void GetCameraSize()
    {
        Vector3 CameraSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        CameraWidth = CameraSize.x;
        CameraHeight = CameraSize.y;
    }

    public void DrawBoard()
    {
        GetCameraSize();

        int VerticalLineNum = Data[0].Count;
        for (int column = 0; column < VerticalLineNum; column++)
        {

            Debug.Log(CameraWidth);
            float Pos_x = -CameraWidth + BoardSideMargin +
                          (CameraWidth - BoardSideMargin) * 2 / (VerticalLineNum - 1) * column;

            // VerticalLine 생성
            GameObject NewVerticalLine = Instantiate(VerticalLine, this.transform);
            NewVerticalLine.transform.position = new Vector3(Pos_x,
                                                             VerticalLineY,
                                                             0);
            // Marker 생성
            float MarkerY = VerticalLineY + VerticalLineLength / 2 + MarkerOffset;
            GameObject NewMarkerIn = Instantiate(Marker, this.transform);
            NewMarkerIn.transform.position = new Vector3(Pos_x, MarkerY, 0);

            GameObject NewMarkerOut = Instantiate(Marker, this.transform);
            NewMarkerOut.transform.position = new Vector3(Pos_x, -MarkerY, 0);

            // 기타 Object 생성
            int HorizontalObjNum = Data.Count;
            for (int row = 0; row < HorizontalObjNum; row++)
            {
                float Pos_y = 0;
            }
            

        }
    }
}
