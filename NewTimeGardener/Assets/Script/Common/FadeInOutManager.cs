using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class FadeInOutManager : MonoBehaviour
{
    [Serializable]
    public struct tagBackGround
    {
        public GameObject   BackGround;
        public float        fFade_in_Time;
        public float        fFade_Stop;
        public float        fFade_Out_Time;
    }

    public tagBackGround[]  m_tFadeInOut = null;

    public string           m_NextSceneName = null;

    // private 모음
    // Struct, enum 
    private enum Fade_Type { FADE_IN, FADE_STOP, FADE_OUT, FADE_END };
    private Fade_Type       m_eFade_Type = Fade_Type.FADE_IN;
    private CanvasGroup     m_CanvasBack = null;

    // Variable
    private int             m_iCanvasIndex = 0;

    // Use this for initialization
    void Start ()
    {
        int iIndex = 0;

        for (iIndex = 0; iIndex < m_tFadeInOut.Length; ++iIndex)
            m_tFadeInOut[iIndex].BackGround.SetActive(false);

        m_CanvasBack = gameObject.GetComponent<CanvasGroup>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Fade_Type.FADE_IN == m_eFade_Type)
            Fade_In();

        else if (Fade_Type.FADE_STOP == m_eFade_Type)
            Fade_Stop();

        else if (Fade_Type.FADE_OUT == m_eFade_Type)
            Fade_Out();
    }

    public void Fade_In()
    {
        m_tFadeInOut[m_iCanvasIndex].BackGround.SetActive(true);

        m_CanvasBack.alpha += Time.deltaTime / m_tFadeInOut[m_iCanvasIndex].fFade_in_Time;

        if (m_CanvasBack.alpha >= 1)
            m_eFade_Type = Fade_Type.FADE_STOP;
    }

    public void Fade_Stop()
    {
        m_tFadeInOut[m_iCanvasIndex].fFade_Stop -= Time.deltaTime * 0.5f;

        if (m_tFadeInOut[m_iCanvasIndex].fFade_Stop <= 0)
            m_eFade_Type = Fade_Type.FADE_OUT;
    }

    public void Fade_Out()
    {
        m_CanvasBack.alpha -= Time.deltaTime / m_tFadeInOut[m_iCanvasIndex].fFade_Out_Time;

        if (m_CanvasBack.alpha <= 0.1f)
        {
            m_tFadeInOut[m_iCanvasIndex].BackGround.SetActive(false);

            if (m_iCanvasIndex + 1 < m_tFadeInOut.Length)
            {
                m_tFadeInOut[m_iCanvasIndex + 1].BackGround.SetActive(true);

                m_CanvasBack.alpha = 0;
                m_eFade_Type = Fade_Type.FADE_IN;
            }

            else
            {
                m_eFade_Type = Fade_Type.FADE_END;
                SceneManager.LoadScene(m_NextSceneName);
            }

            ++m_iCanvasIndex;
        }
    }
}