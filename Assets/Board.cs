using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
/*
    ���� ����� ���� Ŭ����
 */
{
    public List<List<string>> Data;
    public string[] ColorCombination;

    public GameObject Marker;
    public GameObject VerticalLine;

    // ��������Ʈ ����
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
    private Color GetColorFromHTML(string HTMLCode)
    {
        Color color;
        ColorUtility.TryParseHtmlString(HTMLCode, out color);
        return color;
    }

    public void DrawBoard()
    {
        GetCameraSize();
        Color BackGroundColor = GetColorFromHTML(ColorCombination[7]);
        Camera.main.backgroundColor = BackGroundColor;

        int VerticalLineNum = Data[0].Count;
        for (int column = 0; column < VerticalLineNum; column++)
        {
            float Pos_x = -CameraWidth + BoardSideMargin +
                          (CameraWidth - BoardSideMargin) * 2 / (VerticalLineNum - 1) * column;

            // VerticalLine ����
            GameObject NewVerticalLine = Instantiate(VerticalLine, this.transform);
            NewVerticalLine.transform.position = new Vector3(Pos_x, VerticalLineY, 0);
            Color VerticalLineColor = GetColorFromHTML(ColorCombination[6]);
            NewVerticalLine.GetComponent<VerticalLineColor>().SetVerticalLineColor(VerticalLineColor);

            // ��/��� Marker ����
            float MarkerY = VerticalLineY + VerticalLineLength / 2 + MarkerOffset;
            foreach (int gain in new int[2] {1, -1})
            {
                // �����Ϳ��� ��Ŀ�� �� ��ġ/��(��) Ȯ��
                int MarkerRow = (Data.Count - 1) * (1 - gain) / 2;
                int DataValue = int.Parse(Data[MarkerRow][column]);
                Color MarkerColor = GetColorFromHTML(ColorCombination[DataValue]);

                // ��Ŀ ����, ��ġ �� �� �ο�
                GameObject NewMarker = Instantiate(Marker, this.transform);
                NewMarker.transform.position = new Vector3(Pos_x, gain * MarkerY, 0);
                NewMarker.GetComponent<SpriteRenderer>().color = MarkerColor;
            }            


            // ��Ÿ Object ����
            int HorizontalObjNum = Data.Count;
            for (int row = 0; row < HorizontalObjNum; row++)
            {
                float Pos_y = 0;
            }
            

        }
    }
}
