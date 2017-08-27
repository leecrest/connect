using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelGame : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    public static PanelGame It;
    private void Awake() { It = this; }

    private List<Cell> m_Select;
    private int m_CurIndex;

    private void Start()
    {
        m_Select = new List<Cell>();
    }



    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.dragging) return;
        Cell cell = eventData.pointerCurrentRaycast.gameObject.GetComponent<Cell>();
        //SelectStart();
        //SelectCell(cell);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.dragging) return;
        Debug.Log("OnBeginDrag:" + eventData.pointerCurrentRaycast.gameObject.name);
        Cell cell = eventData.pointerCurrentRaycast.gameObject.GetComponent<Cell>();
        SelectStart();
        m_CurIndex = cell.Index;
        SelectCell(cell);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag:" + eventData.pointerCurrentRaycast.gameObject.name);
        Cell cell = eventData.pointerCurrentRaycast.gameObject.GetComponent<Cell>();
        if (m_CurIndex != cell.Index)
        {
            
        }
        SelectCell(cell);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag:" + eventData.pointerCurrentRaycast.gameObject.name);
        Cell cell = eventData.pointerCurrentRaycast.gameObject.GetComponent<Cell>();
        SelectCell(cell);
        SelectOver();
    }

    private void SelectCell(Cell cell)
    {
        if (cell.Select) return;
        cell.Select = true;
        m_Select.Add(cell);
    }

    private void SelectStart()
    {
        m_Select.Clear();
    }

    private void SelectOver()
    {
        int sum = 0;
        Cell cell;
        for (int i = 0; i < m_Select.Count; i++)
        {
            cell = m_Select[i];
            cell.Select = false;
            sum += cell.Index;
            if (i == m_Select.Count - 1)
            {
                cell.Index = sum;
            }
            else
            {
                cell.Index = Random.Range(1, 10);
            }
        }
        m_Select.Clear();
    }
}
