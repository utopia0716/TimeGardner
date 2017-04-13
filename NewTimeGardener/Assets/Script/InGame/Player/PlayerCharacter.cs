using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerStateEnum;

//플레이어의 행동을 정의한다.

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField]
    private LayerMask m_WhatIsGround;
    [SerializeField]
    private PlayerState m_PlayerState = PlayerState.Idle;

    public Vector2 m_VectorCharaterMove = Vector2.zero;
    private Vector2 m_VectorJump = Vector2.zero;
    private Vector2 m_VectorClimb = Vector2.zero;

    public float m_MoveSpeed = 4f;
    public float m_JumpSpeed = 10f;
    public float m_ClimbSpeed = 0.1f;
    
    private bool m_Move = false;
    private bool m_Jump = false;
    private bool m_Act = false;

    private int m_MoveDir = 0;
    public int m_ClimbDir = 0;
    private bool m_Grounded = false;

    private bool m_FacingRight = true;

    const float k_GroundedRadius = .1f;

    private bool m_OnClickRight = false;
    private bool m_OnClickLeft = false;
    public bool m_CanJump = false;

    public Transform m_GroundChk = null;
    public Collider2D m_Collider2D = null;
    private Rigidbody2D m_Rigidbody2D = null;

    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Collider2D = GetComponent<Collider2D>();
        m_VectorCharaterMove = new Vector2(m_MoveSpeed, 0);
    }

    void Update()
    {
        PlayerJump();
        PlayerMove();
        StateUpdate();
    }

	void FixedUpdate()
    {
        //바닥 판정
        m_Grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundChk.position, k_GroundedRadius, m_WhatIsGround);

        int iIndex = 0;
        int iLength = colliders.Length;

        for (iIndex = 0; iIndex < iLength; iIndex++)
        {
            if (colliders[iIndex].gameObject != gameObject)
                m_Grounded = true;
        }

        //사다리 판정
        if(m_Act)
        {
            if (m_ClimbDir != 0)
            {
                m_Rigidbody2D.isKinematic = true;
                m_Collider2D.isTrigger = true;
                m_VectorClimb.y = m_ClimbDir * m_ClimbSpeed;
                transform.Translate(m_VectorClimb);
            }
            else
            {
                m_Rigidbody2D.isKinematic = false;
                m_Collider2D.isTrigger = false;
            }
        }
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void PlayerMove()
    {
        if(!ChkrCanMove())
        {
            return;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            RightMove(true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            LeftMove(true);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            RightMove(false);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            LeftMove(false);
        }
        
        if (m_OnClickRight)
        {
            m_PlayerState = PlayerState.Walk;

            if (!m_FacingRight)
            {
                Flip();
            }

            m_VectorCharaterMove.x = m_MoveSpeed;
        }
        else if(m_OnClickLeft)
        {
            m_PlayerState = PlayerState.Walk;

            if (m_FacingRight)
            {
                Flip();
            }

            m_VectorCharaterMove.x = -m_MoveSpeed;
        }
        else
        {
            m_VectorCharaterMove.x = 0;
        }

        m_VectorCharaterMove.y = m_Rigidbody2D.velocity.y;
        m_Rigidbody2D.velocity = m_VectorCharaterMove;

    }


    public bool ChkrCanMove()
    {
        return ((m_PlayerState & (PlayerState.Die | PlayerState.Event | PlayerState.Act)) == 0);
    }

    public void RightMove(bool flag)
    {
        m_OnClickRight = flag;
        //m_PlayerState = PlayerState.Walk;
    }

    public void LeftMove(bool flag)
    {
        m_OnClickLeft = flag;
    }


    public void Jump()
    {
        if(!ChkrCanMove())
        {
            return;
        }

        if (m_Grounded)
        {
            m_VectorJump.x = m_Rigidbody2D.velocity.x;
            m_VectorJump.y = m_JumpSpeed;
            m_Rigidbody2D.velocity = m_VectorJump;

            m_Grounded = false;
            m_PlayerState = PlayerState.Jump;
        }
    }

    void StateUpdate()
    {
        if(m_Grounded)
        {
            if(m_Rigidbody2D.velocity.x < 1f)
            {
                m_PlayerState = PlayerState.Idle;
            }
            else
            {
                m_PlayerState = PlayerState.Walk;
            }

        }
        else
        {
            m_PlayerState = PlayerState.Jump;
        }
    }

    /*
    public void MoveDown(int move)
    {
        m_Move = true;
        m_MoveDir = move;
    }

    public void MoveUp()
    {
        m_Move = false;
        m_MoveDir = 0;
    }


    public void ActionDown()
    {
        m_Act = true;
    }

    public void ActionUp()
    {
        m_Act = false;
    }

    /*
    IEnumerator Climb(float time, int climb)
    {
        float i = 0;

        while(i < time)
        {
            m_VectorClimb.y = climb * m_ClimbSpeed;
            transform.Translate(m_VectorClimb);
            i += Time.deltaTime;
            yield return 0;
        }
    }
    */

    /*
    public void Climb(int climb)
    {
        m_Rigidbody2D.isKinematic = true;
        m_Collider2D.isTrigger = true;
        m_VectorClimb.y = climb * m_ClimbSpeed;
        transform.Translate(m_VectorClimb);
    }
    */
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;
        m_MoveDir *= -1;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}