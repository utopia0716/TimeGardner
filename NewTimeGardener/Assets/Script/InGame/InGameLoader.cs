using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//인게임에 UI 및 EventSystem을 동적으로 불러온다.

public class InGameLoader : MonoBehaviour
{
    public GameObject gameUI;

    private GameObject m_Go;

    void Awake()
    {
        if (m_Go == null)
        {
            m_Go = Instantiate(gameUI);
        }

        if (!FindObjectOfType<EventSystem>())
        {
            //Instantiate(eventSystem);
            GameObject obj = new GameObject("EventSystem");
            obj.AddComponent<EventSystem>();
            obj.AddComponent<StandaloneInputModule>().forceModuleActive = true;
        }
    }
}
