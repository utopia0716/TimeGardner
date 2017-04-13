using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//과거/현재 시점 오브젝트를 전환하는 함수를 정의 한다.

public class TimeChange : MonoBehaviour
{
    public GameObject Past = null;
    public GameObject Present = null;

    void Awake()
    {
        Change(Present);
    }

	public void Change(bool isPresent)
    {
        if(Past != null)
        {
            Past.SetActive(!isPresent);
        }

        if (Present != null)
        {
            Present.SetActive(isPresent);
        }
    }
}