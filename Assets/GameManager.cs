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
    public Board newBoard;

    // Start is called before the first frame update
    void Start()
    {
        BoardData = new()
        {
            new List<string>() {   "0",   "2",   "3",   "4" },
            new List<string>() { "nr0", "nl0", "nr0", "nl0" },
            new List<string>() {    "",    "", "ac3",    "" },
            new List<string>() {   "3",   "2",   "0",   "4" }
        };

        ColorCombination = new string[8]{ "#197278",  // 마커 1
                                          "#83a8a6",  // 마커 2
                                          "#ae9d96",  // 마커 3
                                          "#d99185",  // 마커 4
                                          "#c44536",  // 마커 5
                                          "#772e25",  // 마커 6
                                          "#283d3b",  // 수직선
                                          "#edddd4"}; // 배경

        newBoard.Data = BoardData;
        newBoard.ColorCombination = ColorCombination;

        newBoard.DrawBoard();
    }

    // Update is called once per frame
    void Update()
    {

    }
 
}
