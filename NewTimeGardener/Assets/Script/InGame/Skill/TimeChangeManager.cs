using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//스킬 사용시 오브젝트들을 전환한다.

public class TimeChangeManager : MonoBehaviour
{
    public TimeChange[] timeObjects;
    public int timeObjectNum = 0;
    public bool isPresent = false;

	void Start()
    {
        isPresent = true;
        timeObjectNum = timeObjects.Length;
    }

    public void TimeChange()
    {
        isPresent = !isPresent;

        int iIndex = 0;

        for (iIndex = 0; iIndex < timeObjectNum; ++iIndex)
        {
            timeObjects[iIndex].Change(isPresent);
        }
    }
}
