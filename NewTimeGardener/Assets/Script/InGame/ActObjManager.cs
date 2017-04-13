using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActObjManager : MonoBehaviour
{
    float m_Time = 0f;
    bool m_TimeChk = false;

    public bool m_ActionClick = false;
    public bool m_ActionDown = false;

    public void ActionClick()
    {
        m_ActionClick = true;
        m_TimeChk = true;
    }
    /*
    public void ActionDown()
    {
        m_ActionDown = true;
    }

    public void ActionUp()
    {
        m_ActionDown = false;
    }
    */
    void FixedUpdate()
    {
        if(m_TimeChk)
        {
            m_Time += Time.deltaTime;

            if (m_Time > 2 * Time.deltaTime)
            {
                m_ActionClick = false;
                m_TimeChk = false;
                m_Time = 0f;
            }
        }
    }
}