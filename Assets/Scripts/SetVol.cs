using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVol : MonoBehaviour
{
    public AudioMixer mixer;
    
    public void SetVolume (float set)
    {
        mixer.SetFloat("MyExposedParam", Mathf.Log10(set) * 20);
    }
    
}
