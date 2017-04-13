using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//설정 UI에 쓰인다.

public class SettingUI : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource volumeAudio;
    public void VolumeController()
    {
        volumeSlider.value = volumeAudio.volume;
    }
}