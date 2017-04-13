using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterRestarter : MonoBehaviour
{
    public int m_Chapter = 0;
    public int m_Stage = 0;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            string strSceneName = null;

            SceneManager.GetSceneByName(strSceneName);

            SceneManager.LoadScene(strSceneName);

            strSceneName = null;
        }
    }
}