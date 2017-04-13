using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public GameObject m_Player = null;
    public GameObject groundChk = null;
    public ActObjManager m_ActManager = null;

    public Transform top = null;
    public Transform bottom = null;
    
    public bool canClimb = false;
    public int m_ClimbDir = 0;

    private Rigidbody2D rb2d = null;
    private Collider2D col2d = null;
    private PlayerCharacter pc = null;

    private float ladder_y = 0.0f;
    private float top_y = 0.0f;
    private float bottom_y = 0.0f;
    

    void Start ()
    {
        rb2d = m_Player.GetComponent<Rigidbody2D>();
        col2d = m_Player.GetComponent<Collider2D>();
        pc = m_Player.GetComponent<PlayerCharacter>();
        ladder_y = transform.position.y;
        top_y = top.transform.position.y;
        bottom_y = bottom.transform.position.y;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject == m_Player)
        {
            canClimb = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject == m_Player)
        {
            canClimb = false;
            rb2d.isKinematic = false;
            col2d.isTrigger = false;
        }
    }

    void Update()
    {
        float m_Player_y = m_Player.transform.position.y;
        float groundChk_y = groundChk.transform.position.y;

        if (canClimb && m_ActManager.m_ActionClick)
        {
            if (m_Player_y < ladder_y)
            {
                m_ClimbDir = 1;
            }
            else
            {
                m_ClimbDir = -1;
            }
        }

        if(m_ClimbDir == 1 && !(groundChk_y < top_y))
        {
            m_ClimbDir = 0;
        }

        else if (m_ClimbDir == -1 && !(groundChk_y > bottom_y))
        {
            m_ClimbDir = 0;
        }
        
        pc.m_ClimbDir = m_ClimbDir;
    }
}