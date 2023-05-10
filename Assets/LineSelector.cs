using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LineSelector : MonoBehaviour
{
    public GameObject ScrollView;
    public Dictionary<string, int> AvailableLine;
    public string[] ColorCombination;
    public Sprite circle;
    public Sprite square;
    public Sprite triangle;

    // 선택된 데이터
    private int SelectedIndex;
    public string SeletedLineStyle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private Color GetColorFromHTML(string HTMLCode)
    {
        ColorUtility.TryParseHtmlString(HTMLCode, out Color color);
        return color;
    }

    private void GenerateLine(string style)
    {     
        // Line 오브젝트 생성
        GameObject newLine = new("newLine");
        RectTransform newLineRectTrans = newLine.AddComponent<RectTransform>();
        newLineRectTrans.transform.SetParent(this.transform);
        newLineRectTrans.anchoredPosition = new Vector2(0f, 0f); // setting position, will be on center
        newLineRectTrans.anchorMin = Vector2.zero;
        newLineRectTrans.anchorMax = Vector2.one;
        newLineRectTrans.localScale = Vector3.one;
        newLineRectTrans.sizeDelta = new Vector2(0, ScrollView.GetComponent<RectTransform>().rect.height / 3); // custom size

        // 해당 라인 정보 판별
        Color LineColor;
        bool isArrow;

        switch (style)
        {
            case "Normal":
                LineColor = GetColorFromHTML(ColorCombination[^2]);
                isArrow = false;
                break;

            case "Arrow":
                LineColor = GetColorFromHTML(ColorCombination[^2]);
                isArrow = true;
                    break;

            case "Color1":
                LineColor = GetColorFromHTML(ColorCombination[0]);
                isArrow = false;
                break;

            case "Color2":
                LineColor = GetColorFromHTML(ColorCombination[1]);
                isArrow = false;
                break;

            case "Color3":
                LineColor = GetColorFromHTML(ColorCombination[2]);
                isArrow = false;
                break;

            case "Color4":
                LineColor = GetColorFromHTML(ColorCombination[3]);
                isArrow = false;
                break;

            case "Color5":
                LineColor = GetColorFromHTML(ColorCombination[4]);
                isArrow = false;
                break;

            case "Color6":
                LineColor = GetColorFromHTML(ColorCombination[5]);
                isArrow = false;
                break;

            case "Empty":
                return;

            default:
                LineColor = new Color(1f, 1f, 1f);
                isArrow = true;
                break;
        }        

        // 스프라이트들을 통해 라인 생성
        GameObject LeftEnd = new("LeftEnd");
        RectTransform LeftEndRectTrans = LeftEnd.AddComponent<RectTransform>();
        LeftEndRectTrans.transform.SetParent(newLine.transform); // setting parent
        LeftEndRectTrans.anchoredPosition = new Vector2(0f, 0f); // setting position, will be on center
        LeftEndRectTrans.anchorMin = new Vector2(0.1f, 0.2f);
        LeftEndRectTrans.anchorMax = new Vector2(0.3f, 0.8f);
        LeftEndRectTrans.localScale = Vector3.one;
        LeftEndRectTrans.sizeDelta = new Vector2(0, 0); // custom size
        Image LeftEndImage = LeftEnd.AddComponent<Image>();
        LeftEndImage.sprite = circle;
        LeftEndImage.color = LineColor;
        LeftEndImage.transform.SetParent(newLine.transform);
        LeftEndImage.preserveAspect = true;


        GameObject MiddleLine = new("MiddleLine");
        RectTransform MiddleLineRectTrans = MiddleLine.AddComponent<RectTransform>();
        MiddleLineRectTrans.transform.SetParent(newLine.transform); // setting parent
        MiddleLineRectTrans.anchoredPosition = new Vector2(0f, 0f); // setting position, will be on center
        MiddleLineRectTrans.anchorMin = new Vector2(0.2f, 0.2f);
        MiddleLineRectTrans.anchorMax = new Vector2(0.6f, 0.8f);
        MiddleLineRectTrans.localScale = Vector3.one;
        MiddleLineRectTrans.sizeDelta = new Vector2(0, 0); // custom size
        Image MiddleLineImage = MiddleLine.AddComponent<Image>();
        MiddleLineImage.sprite = square;
        MiddleLineImage.color = LineColor;
        MiddleLineImage.transform.SetParent(newLine.transform);

        GameObject RightEnd = new("RighrEnd");
        RectTransform RightEndRectTrans = RightEnd.AddComponent<RectTransform>();
        RightEndRectTrans.transform.SetParent(newLine.transform); // setting parent
        RightEndRectTrans.anchoredPosition = new Vector2(0f, 0f); // setting position, will be on center
        RightEndRectTrans.anchorMin = new Vector2(0.5f, 0.2f);
        RightEndRectTrans.anchorMax = new Vector2(0.7f, 0.8f);
        RightEndRectTrans.localScale = Vector3.one;
        RightEndRectTrans.sizeDelta = new Vector2(0, 0); // custom size
        Image RightEndImage = RightEnd.AddComponent<Image>();
        RightEndImage.sprite = circle;
        RightEndImage.color = LineColor;
        RightEndImage.transform.SetParent(newLine.transform);
        RightEndImage.preserveAspect = true;
        
        if (isArrow)
        {
            GameObject Arrow = new("Arrow");
            RectTransform ArrowRectTrans = Arrow.AddComponent<RectTransform>();
            ArrowRectTrans.transform.SetParent(newLine.transform); // setting parent
            ArrowRectTrans.anchoredPosition = new Vector2(0f, 0f); // setting position, will be on center
            ArrowRectTrans.anchorMin = new Vector2(0.3f, 0.25f);
            ArrowRectTrans.anchorMax = new Vector2(0.5f, 0.75f);
            ArrowRectTrans.rotation = Quaternion.Euler(0, 0, -90);
            ArrowRectTrans.localScale = Vector3.one;
            ArrowRectTrans.sizeDelta = new Vector2(0, 0); // custom size
            Image RighrEndImage = Arrow.AddComponent<Image>();
            RighrEndImage.sprite = triangle;
            RighrEndImage.color = GetColorFromHTML(ColorCombination[^1]);
            RighrEndImage.transform.SetParent(newLine.transform);
            RighrEndImage.preserveAspect = true;
        }

        // 총사용 가능 수 표시
        GameObject Count = new("Count");
        RectTransform CountRectTrans = Count.AddComponent<RectTransform>();
        CountRectTrans.transform.SetParent(newLine.transform); // setting parent
        CountRectTrans.anchoredPosition = new Vector2(0f, 0f); // setting position, will be on center
        CountRectTrans.anchorMin = new Vector2(0.7f, 0.2f);
        CountRectTrans.anchorMax = new Vector2(1f, 0.8f);
        CountRectTrans.localScale = Vector3.one;
        CountRectTrans.sizeDelta = new Vector2(0, 0); // custom size
        TextMeshProUGUI CountText = Count.AddComponent<TextMeshProUGUI>();
        int TotalAvailableCount = AvailableLine[style];
        if (TotalAvailableCount != -1)
        {
            CountText.text = TotalAvailableCount.ToString() + " / " + TotalAvailableCount.ToString();
        }
        else
        {
            CountText.text = "∞";
        }
        CountText.color = GetColorFromHTML(ColorCombination[^2]);
        CountText.enableAutoSizing = true;
        CountText.fontSizeMin = 0f;
        CountText.alignment = TextAlignmentOptions.Center;
    }

    public void SetScrollContent()
    {
        GenerateLine("Empty");

        foreach (string style in AvailableLine.Keys)
        {
            GenerateLine(style);
        }
            
    }
}
