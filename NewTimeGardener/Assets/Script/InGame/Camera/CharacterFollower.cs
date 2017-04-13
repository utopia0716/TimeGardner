using UnityEngine;
using System.Collections;

//카메라가 설정된 경계 안에서 플레이어를 따라가게 하도록 한다.

public class CharacterFollower : MonoBehaviour
{
    public GameObject character = null;

    public Transform boundaryLeft = null;
    public Transform boundaryRight = null;

    // 17.02.21 추가
    private Vector2 m_VectorCharacterPosition = Vector2.zero;

    private float m_widthHalf = 0.0f;
    private float m_limitLeft = 0.0f;
    private float m_limitRight = 0.0f;

    void Start()
    {
        float heightHalf = Camera.main.orthographicSize;
        m_widthHalf = heightHalf * Camera.main.aspect;
        m_limitLeft = boundaryLeft.position.x + m_widthHalf;
        m_limitRight = boundaryRight.position.x - m_widthHalf;
    }

    void Update()
    {
        m_VectorCharacterPosition.x = character.transform.position.x;
        m_VectorCharacterPosition.y = character.transform.position.y;

        if (m_VectorCharacterPosition.x < m_limitLeft)
        {
            m_VectorCharacterPosition.x = m_limitLeft;
        }

        if (m_VectorCharacterPosition.x > m_limitRight)
        {
            m_VectorCharacterPosition.x = m_limitRight;
        }

        transform.position = m_VectorCharacterPosition;
    }
}