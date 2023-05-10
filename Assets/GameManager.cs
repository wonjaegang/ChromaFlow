using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
/*
    인게임 내 전체 프로세스 관리 클래스
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

        ColorCombination = new string[8]{ "#197278",  // 마커 1
                                          "#83a8a6",  // 마커 2
                                          "#ae9d96",  // 마커 3
                                          "#d99185",  // 마커 4
                                          "#c44536",  // 마커 5
                                          "#772e25",  // 마커 6
                                          "#283d3b",  // 수직선
                                          "#edddd4"}; // 배경

        AvailableLine = new Dictionary<string, int>() { { "Normal", -1 }, { "Arrow", 1 }, { "Color1", 8 }, };  // -1이면 무한


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
