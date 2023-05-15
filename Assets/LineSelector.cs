using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LineSelector : MonoBehaviour
{
    public GameObject ScrollView;
    public Scrollbar scrollbar;
    public TranslucentMask mask;

    public Dictionary<string, int> AvailableLine;
    public string[] ColorCombination;
    public Sprite circle;
    public Sprite square;
    public Sprite triangle;

    // ���õ� ������
    private int SelectedIndex = 0;
    public string SeletedLineStyle;

    // ��ġ ����
    private bool isSwipeMode = false;
    private float startTouchY;
    private float endTouchY;
    private float swipeTime = 0.2f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateInput();
    }

    private Color GetColorFromHTML(string HTMLCode)
    {
        ColorUtility.TryParseHtmlString(HTMLCode, out Color color);
        return color;
    }

    private void GenerateLine(string style)
    {     
        // Line ������Ʈ ����
        GameObject newLine = new("newLine");
        RectTransform newLineRectTrans = newLine.AddComponent<RectTransform>();
        newLineRectTrans.transform.SetParent(this.transform);
        newLineRectTrans.anchoredPosition = new Vector2(0f, 0f); // setting position, will be on center
        newLineRectTrans.anchorMin = Vector2.zero;
        newLineRectTrans.anchorMax = Vector2.one;
        newLineRectTrans.localScale = Vector3.one;
        newLineRectTrans.sizeDelta = new Vector2(0, ScrollView.GetComponent<RectTransform>().rect.height / 3); // custom size

        // �ش� ���� ���� �Ǻ�
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

        // ��������Ʈ���� ���� ���� ����
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

        // �ѻ�� ���� �� ǥ��
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
            CountText.text = "��";
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
        GenerateLine("Empty");

        scrollbar.value = 1f;
    }

    private void UpdateInput()
    {
        // ���� Swipe�� �������̸� ��ġ �Ұ�
        if (isSwipeMode == true) return;

        #if UNITY_EDITOR
        // ���콺 ���� ��ư�� ������ �� 1ȸ
        if (Input.GetMouseButtonDown(0))
        {
            // ��ġ ���� ���� (Swipe ���� ����)
            startTouchY = Input.mousePosition.y;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // ��ġ ���� ���� (Swipe ���� ����)
            endTouchY = Input.mousePosition.y;

            UpdateSwipe();
        }
        #endif

        #if UNITY_ANDROID
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // ��ġ ���� ���� (Swipe ���� ����)
                startTouchY = touch.position.y;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                // ��ġ ���� ���� (Swipe ���� ����)
                endTouchY = touch.position.y;

                UpdateSwipe();
            }
        }
        #endif
    }

    private void UpdateSwipe()
    {
        // Swipe ����
        bool isUpper = startTouchY < endTouchY ? false : true;

        // �̵� ������ ������ ��
        if (isUpper)
        {
            // ���� �������� ���� ���̸� ����
            if (SelectedIndex == 0) return;

            // �������� �̵��� ���� ���� �ε��� 1 ����
            SelectedIndex--;
        }
        // �̵� ������ �Ʒ����� ��
        else
        {
            // ���� �������� �Ʒ��� ���̸� ����
            if (SelectedIndex == AvailableLine.Count - 1) return;

            // �Ʒ��� �̵��� ���� ���� �������� 1 ����
            SelectedIndex++;
        }

        // currentIndex��° �������� Swipe�ؼ� �̵�
        StartCoroutine(OnSwipeOneStep(SelectedIndex));
    }

    //�������� �� �� ������ �ѱ�� Swipe ȿ�� ���
    private IEnumerator OnSwipeOneStep(int index)
    {
        float start = scrollbar.value;
        float end = 1 - 1f / (AvailableLine.Count + 2f - 3f) * index;
        float current = 0;
        float percent = 0;
        isSwipeMode = true;

        Color backColor = GetColorFromHTML(ColorCombination[^1]);
        backColor.a = 0f;

        Color backColor1 = backColor;
        backColor1.a = 0.5f;
        mask.SetMaskColor(backColor1, backColor1, backColor1);
        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / swipeTime;

            scrollbar.value = Mathf.Lerp(start, end, percent);

            yield return null;
        }
        mask.SetMaskColor(backColor1, backColor, backColor1);


        isSwipeMode = false;
    }
}