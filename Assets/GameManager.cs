using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
/*
    �ΰ��� �� ��ü ���μ��� ���� Ŭ����
 */
{
    public List<List<string>> BoardData = new(){new List<string>() {  "1",   "2",   "3"},
                                                new List<string>() {   "", "nr0", "nl0"},
                                                new List<string>() {  "3",   "2",   "1"}};

    public Board newBoard;

    // Start is called before the first frame update
    void Start()
    {
        newBoard.Data = BoardData;
        newBoard.DrawBoard();
    }

    // Update is called once per frame
    void Update()
    {

    }
 
}
