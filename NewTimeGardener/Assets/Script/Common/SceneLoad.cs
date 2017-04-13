using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//해당 이름의 씬으로 이동한다.

public class SceneLoad : MonoBehaviour
{

    public void OpenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
