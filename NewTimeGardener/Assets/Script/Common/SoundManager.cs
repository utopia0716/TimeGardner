using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public static SoundManager  m_Instance = null;

    public AudioSource[]        m_BGMAudio = null;
    public AudioSource[]        m_EffectAudio = null;

    public enum SOUND_TYPE
    {
        SOUND_BGM,
        SOUND_EFFECT,
        SOUND_END
    };

    private SoundManager()
    {
    }

    void Awake()
    {
        if (null != m_Instance)
            return;

        m_Instance = this;

        DontDestroyOnLoad(this);
    }
		
    public static SoundManager GetInstance()
    {
        if (null == m_Instance)
            m_Instance = new SoundManager();

        return m_Instance;
    }

    public void SetBGMVolume(float fVolume)
    {
        int iIndex = 0;
        int iLength = m_BGMAudio.Length;

        for (iIndex = 0; iIndex < iLength; ++iIndex)
            m_BGMAudio[iIndex].volume = fVolume;
    }

    public void SetEffectSoundVolume(float fVolume)
    {
        int iIndex = 0;
        int iLength = m_EffectAudio.Length;

        for (iIndex = 0; iIndex < iLength; ++iIndex)
            m_EffectAudio[iIndex].volume = fVolume;
    }

    public void SoundOn(SOUND_TYPE eType, int iSoundIndex)
    {
        if (SOUND_TYPE.SOUND_BGM == eType)
            m_BGMAudio[iSoundIndex].Play();

        else if (SOUND_TYPE.SOUND_EFFECT == eType)
            m_EffectAudio[iSoundIndex].Play();
    }

    public void SoundOff(SOUND_TYPE eType, int iSoundIndex)
    {
        if (SOUND_TYPE.SOUND_BGM == eType)
            m_BGMAudio[iSoundIndex].Stop();

        else if (SOUND_TYPE.SOUND_EFFECT == eType)
            m_EffectAudio[iSoundIndex].Stop();
    }

    public void SoundAllOn(SOUND_TYPE eType)
    {
        int iIndex = 0;
        int iLength = 0;

        if (SOUND_TYPE.SOUND_BGM == eType)
        {
            iLength = m_BGMAudio.Length;

            for (iIndex = 0; iIndex < iLength; ++iIndex)
                m_BGMAudio[iIndex].Play();
        }

        else if (SOUND_TYPE.SOUND_EFFECT == eType)
        {
            iLength = m_EffectAudio.Length;

            for (iIndex = 0; iIndex < iLength; ++iIndex)
                m_EffectAudio[iIndex].Play();
        }
    }

    public void SoundOff(SOUND_TYPE eType)
    {
        int iIndex = 0;
        int iLength = 0;

        if (SOUND_TYPE.SOUND_BGM == eType)
        {
            iLength = m_BGMAudio.Length;

            for (iIndex = 0; iIndex < iLength; ++iIndex)
                m_BGMAudio[iIndex].Stop();
        }

        else if (SOUND_TYPE.SOUND_EFFECT == eType)
        {
            iLength = m_EffectAudio.Length;

            for (iIndex = 0; iIndex < iLength; ++iIndex)
                m_EffectAudio[iIndex].Stop();
        }
    }
}