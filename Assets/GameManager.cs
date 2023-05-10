using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
/*
    �ΰ��� �� ��ü ���μ��� ���� Ŭ����
 */
{
    public List<List<string>> BoardData;
    public string[] ColorCombination;
    public Dictionary<string, int> AvailableLine;
    public Board newBoard;
    public LineSelector newLineSelector;

    // Start is called before the first frame update
    void Start()
    {
        BoardData = new()
        {
            new List<string>() {   "0",   "1",   "2",   "3" },
            new List<string>() { "nr5", "nl5", "nr0", "nl0" },
            new List<string>() { "ar0",    "", "ac3",  "ac3"},            
            new List<string>() {    "", "al0", "cr4", "cl4" },
            new List<string>() {   "3",   "2",   "0",   "1" }
        };

        //BoardData = new()
        //{
        //    new List<string>() { "0", "1", "2" },
        //    new List<string>() { "nr5", "nl5", "" },
        //    new List<string>() { "ar0", "", "ac3", },
        //    new List<string>() { "", "al0", "", },
        //    new List<string>() { "3", "2", "0" }
        //};

        ColorCombination = new string[8]{ "#197278",  // ��Ŀ 1
                                          "#83a8a6",  // ��Ŀ 2
                                          "#ae9d96",  // ��Ŀ 3
                                          "#d99185",  // ��Ŀ 4
                                          "#c44536",  // ��Ŀ 5
                                          "#772e25",  // ��Ŀ 6
                                          "#283d3b",  // ������
                                          "#edddd4"}; // ���

        AvailableLine = new Dictionary<string, int>() { { "Normal", -1 }, { "Arrow", 1 }, { "Color1", 8 }, };  // -1�̸� ����


        newBoard.Data = BoardData;
        newBoard.ColorCombination = ColorCombination;        
        newBoard.DrawBoard();

        newLineSelector.AvailableLine = AvailableLine;
        newLineSelector.ColorCombination = ColorCombination;
        newLineSelector.SetScrollContent();
    }

    // Update is called once per frame
    void Update()
    {

    }
 
}
