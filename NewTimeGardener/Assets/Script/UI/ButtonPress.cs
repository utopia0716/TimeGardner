using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonPress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool m_isClicked = false;
    public bool m_isPressed = false;

    public void OnPointerDown(PointerEventData e)
    {
        m_isPressed = true;
        m_isClicked = true;
    }

    public void OnPointerUp(PointerEventData e)
    {
        m_isPressed = false;
    }

    void LateUpdate()
    {
        m_isClicked = false;
    }
}