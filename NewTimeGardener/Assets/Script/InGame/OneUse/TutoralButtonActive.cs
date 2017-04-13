using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutoralButtonActive : MonoBehaviour {

    public GameObject m_Button = null;
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            m_Button.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}