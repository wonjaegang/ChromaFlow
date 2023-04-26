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

        ColorCombination = new string[8]{ "#197278",  // ��Ŀ 1
                                          "#83a8a6",  // ��Ŀ 2
                                          "#ae9d96",  // ��Ŀ 3
                                          "#d99185",  // ��Ŀ 4
                                          "#c44536",  // ��Ŀ 5
                                          "#772e25",  // ��Ŀ 6
                                          "#283d3b",  // ������
                                          "#edddd4"}; // ���

        newBoard.Data = BoardData;
        newBoard.ColorCombination = ColorCombination;

        newBoard.DrawBoard();
    }

    // Update is called once per frame
    void Update()
    {

    }
 
}
