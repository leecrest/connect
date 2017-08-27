using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour {
    public static GameMgr It;
    private void Awake() { It = this; }

    public Transform CellRoot;
    public GameObject CellPrefab;

    public static readonly int SIZE = 4;
    // 横屏比例
    //public static readonly float CELL_WIDTH = 1.67f * 0.7f;
    //public static readonly float CELL_HEIGHT = 1.82f * 0.56f;
    //public static readonly Vector3 CELL_SCALE = new Vector3(0.8f, 0.8f, 0.8f);
    // 竖屏比例
    public static readonly float CELL_WIDTH = 167f * 0.9f;
    public static readonly float CELL_HEIGHT = 182f * 0.74f;
    public static readonly Vector3 CELL_SCALE = Vector3.one;


    private Cell[,] m_Cells;


    private void Start()
    {
        m_Cells = new Cell[SIZE*2,SIZE*2-1];
        GameReady();
    }

    public void GameReady()
    {
        GameObject obj;
        Vector3 pos = Vector3.zero;
        Cell cell;

        // 绘制棋盘最中间的一行
        // 棋盘每条边的元素个数是 SIZE，那么最中间一行的个数 = 2*SIZE-1
        int count = 2 * SIZE - 1;
        float left = -(SIZE - 1) * CELL_WIDTH;
        pos.y = 0;
        pos.x = left;
        for (int i = 0; i < count; i++)
        {
            obj = Instantiate(CellPrefab, CellRoot);
            obj.transform.localPosition = pos;
            obj.transform.localScale = CELL_SCALE;
            obj.SetActive(true);
            cell = obj.GetComponent<Cell>();
            cell.Index = Random.Range(1, 4);
            pos.x += CELL_WIDTH;
        }

        // 绘制上半部分
        pos.x = left;
        pos.y = 0;
        for (int i = 0; i < SIZE-1; i++)
        {
            pos.x = left + CELL_WIDTH * 0.5f * (i+1);
            pos.y += CELL_HEIGHT;
            for (int j = 0; j < count - i - 1; j++)
            {
                obj = Instantiate(CellPrefab, CellRoot);
                obj.transform.localPosition = pos;
                obj.transform.localScale = CELL_SCALE;
                obj.SetActive(true);
                cell = obj.GetComponent<Cell>();
                cell.Index = Random.Range(1, 4);
                pos.x += CELL_WIDTH;
            }
        }

        // 绘制下半部分
        pos.x = left;
        pos.y = 0;
        for (int i = 0; i < SIZE - 1; i++)
        {
            pos.x = left + CELL_WIDTH * 0.5f * (i + 1);
            pos.y -= CELL_HEIGHT;
            for (int j = 0; j < count - i - 1; j++)
            {
                obj = Instantiate(CellPrefab, CellRoot);
                obj.transform.localPosition = pos;
                obj.transform.localScale = CELL_SCALE;
                obj.SetActive(true);
                cell = obj.GetComponent<Cell>();
                cell.Index = Random.Range(1, 4);
                pos.x += CELL_WIDTH;
            }
        }
    }

    public void GameStart()
    {

    }

    public void GamePause()
    {

    }

    public void GameResume()
    {

    }

    public void GameOver()
    {

    }
}
