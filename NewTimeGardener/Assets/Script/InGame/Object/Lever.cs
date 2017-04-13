using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject player = null;
    public ActObjManager m_ActManager = null;

    public GameObject m_Wall = null;

    public bool m_CanOnOff = false;
    public bool m_IsOn = true;

    void Update()
    {
        if(m_CanOnOff && m_ActManager.m_ActionClick)
        {
            OnOff();
        }
    }

	void OnOff()
    {
        m_IsOn = !m_IsOn;
        m_Wall.SetActive(m_IsOn);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == player && m_ActManager.m_ActionClick)
        {
            m_CanOnOff = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject == player && m_ActManager.m_ActionClick)
        {
            m_CanOnOff = false;
        }
    }
}