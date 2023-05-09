using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
/*
    보드 입출력 관리 클래스
 */
{
    // 문제 관련 데이터
    public List<List<string>> Data;
    public string[] ColorCombination;

    // 오브젝트
    public GameObject Marker;
    public GameObject Line;

    // 스크린 변수 - 월드포인트 기준
    public float BoardSideMargin;
    public float MarkerOffset;
    public float VerticalLineY;
    public float VerticalLineLength;
    public float VerticalLineWidth;
    public float MarkerSize;
    public float HorizentalLineWidth;

    private float CameraWidth;
    private float CameraHeight;

    private void GetCameraSize()
    {
        Vector3 CameraSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        CameraWidth = CameraSize.x;
        CameraHeight = CameraSize.y;
    }
    private Color GetColorFromHTML(string HTMLCode)
    {
        ColorUtility.TryParseHtmlString(HTMLCode, out Color color);
        return color;
    }

    private void GenerateMarker(float X, float Y, float scale, Color color, int LayerOrder)
    {
        GameObject NewMarker = Instantiate(Marker, this.transform);
        NewMarker.transform.position = new Vector3(X, Y, 0);
        NewMarker.transform.localScale = new Vector3(scale, scale, 0);
        NewMarker.GetComponent<SpriteRenderer>().color = color;
        NewMarker.GetComponent<SpriteRenderer>().sortingOrder = LayerOrder;
    }


    public void DrawBoard()
    {
        GetCameraSize();
        Color BackGroundColor = GetColorFromHTML(ColorCombination[^1]);
        Camera.main.backgroundColor = BackGroundColor;

        int VerticalLineNum = Data[0].Count;
        float VerticalLineInterval = (CameraWidth - BoardSideMargin) * 2 / (VerticalLineNum - 1);
        for (int column = 0; column < VerticalLineNum; column++)
        {
            float Pos_x = -CameraWidth + BoardSideMargin + VerticalLineInterval * column;

            // 수직선 생성
            GameObject NewLineObject = Instantiate(Line, this.transform);
            Line NewLine = NewLineObject.GetComponent<Line>();
            NewLine.Pos = new float[3] { Pos_x, VerticalLineY, 0 };
            NewLine.width = VerticalLineWidth;
            NewLine.length = VerticalLineLength;
            NewLine.LineColor = GetColorFromHTML(ColorCombination[^2]);
            NewLine.LayerOrder = 0;
            NewLine.SetLine();


            // 입/출력 Marker 생성
            float MarkerY = VerticalLineY + VerticalLineLength / 2 + MarkerOffset;
            foreach (int gain in new int[2] {1, -1})
            {
                // 데이터에서 마커의 행 위치/값(색) 확인
                int MarkerRow = (Data.Count - 1) * (1 - gain) / 2;
                int DataValue = int.Parse(Data[MarkerRow][column]);
                if (DataValue == 0) continue;
                Color MarkerColor = GetColorFromHTML(ColorCombination[DataValue - 1]);

                // 마커 생성
                GenerateMarker(Pos_x, gain * MarkerY, MarkerSize, MarkerColor, 3);
            }

            // 기타 Object 생성
            int ExtraObjNum = Data.Count - 2;
            float ExtraObjNumInterval = VerticalLineLength / (ExtraObjNum + 1);
            for (int row = 0; row < ExtraObjNum; row++)
            {
                float Pos_y = VerticalLineLength / 2 - ExtraObjNumInterval * (row + 1);

                string DataValue = Data[row + 1][column];
                if (DataValue == "") continue;

                int ColorIndex = (int)char.GetNumericValue(DataValue[^1]);
                switch (DataValue.Substring(0, 2))
                {
                    case "ac":
                        Color acColor = GetColorFromHTML(ColorCombination[ColorIndex - 1]);
                        GenerateMarker(Pos_x, Pos_y, HorizentalLineWidth, acColor, 1);
                        break;

                    case "nr":
                        GameObject nrLineObject = Instantiate(Line, this.transform);
                        Line nrLine = nrLineObject.GetComponent<Line>();
                        nrLine.Pos = new float[3] { Pos_x + VerticalLineInterval / 2, Pos_y, -90 };
                        nrLine.width = HorizentalLineWidth;
                        nrLine.length = VerticalLineInterval;
                        nrLine.LineColor = GetColorFromHTML(ColorCombination[^2]);
                        nrLine.LayerOrder = 1;
                        nrLine.SetLine();

                        if (ColorIndex > 1)
                        {
                            Color nrMarkerColor = GetColorFromHTML(ColorCombination[ColorIndex - 1]);
                            float nrMarkerX = Pos_x + VerticalLineInterval / 2;
                            GenerateMarker(nrMarkerX, Pos_y, HorizentalLineWidth, nrMarkerColor, 2);
                        }
                        break;

                    case "cr":
                        GameObject crLineObject = Instantiate(Line, this.transform);
                        Line crLine = crLineObject.GetComponent<Line>();
                        crLine.Pos = new float[3] { Pos_x + VerticalLineInterval / 2, Pos_y, -90 };
                        crLine.width = HorizentalLineWidth;
                        crLine.length = VerticalLineInterval;
                        crLine.LineColor = GetColorFromHTML(ColorCombination[ColorIndex - 1]);
                        crLine.LayerOrder = 1;
                        crLine.SetLine();
                        break;

                    case "al":
                        GameObject alLineObject = Instantiate(Line, this.transform);
                        Line alLine = alLineObject.GetComponent<Line>();
                        alLine.Pos = new float[3] { Pos_x - VerticalLineInterval / 2, Pos_y, 90 };
                        alLine.width = HorizentalLineWidth;
                        alLine.length = VerticalLineInterval;
                        alLine.LineColor = GetColorFromHTML(ColorCombination[^2]);
                        alLine.LayerOrder = 1;
                        alLine.SetLine();
                        alLine.SetStyle("Arrow", GetColorFromHTML(ColorCombination[^1]));
                        break;

                    case "ar":
                        GameObject arLineObject = Instantiate(Line, this.transform);
                        Line arLine = arLineObject.GetComponent<Line>();
                        arLine.Pos = new float[3] { Pos_x + VerticalLineInterval / 2, Pos_y, -90 };
                        arLine.width = HorizentalLineWidth;
                        arLine.length = VerticalLineInterval;
                        arLine.LineColor = GetColorFromHTML(ColorCombination[^2]);
                        arLine.LayerOrder = 1;
                        arLine.SetLine();
                        arLine.SetStyle("Arrow", GetColorFromHTML(ColorCombination[^1]));
                        break;

                    default:
                        break;
                }
            }   
        }
    }
}
