using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public Image m_Image;
    public Text m_Text;
    public int Index
    {
        get { return m_Index; }
        set { m_Index = value; m_Text.text = m_Index.ToString(); name = m_Index.ToString(); }
    }
    public bool Select
    {
        get { return m_Selected; }
        set
        {
            if (m_Selected == value) return;
            m_Selected = value;
            m_Image.color = value ? Color.red : Color.white;
        }
    }

    private int m_Index;
    private bool m_Selected;
}
