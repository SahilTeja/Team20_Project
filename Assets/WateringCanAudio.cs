using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCanAudio : MonoBehaviour
{

    public AudioSource wateringCanSound;

    public float FadeOut;

    public static class AudioFadeOut {
 
    public static IEnumerator FadeOut (AudioSource audioSource, float FadeTime) {
        float startVolume = audioSource.volume;
 
        while (audioSource.volume > 0) {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
 
            yield return null;
        }
 
        audioSource.Stop ();
        audioSource.volume = startVolume;
    }
 
}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SystemInfo.deviceType == DeviceType.Desktop && (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.B)))
        {
            Debug.Log("water sounds");
            wateringCanSound.Play();
        }
        if (SystemInfo.deviceType == DeviceType.Handheld && Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            Debug.Log("water sounds");
            wateringCanSound.Play();
        }
        
        if(SystemInfo.deviceType == DeviceType.Desktop && (Input.GetKeyUp(KeyCode.JoystickButton1) || Input.GetKeyUp(KeyCode.B)))
        {
            StartCoroutine (AudioFadeOut.FadeOut (wateringCanSound, FadeOut));
        }
        if (SystemInfo.deviceType == DeviceType.Handheld && Input.GetKeyUp(KeyCode.JoystickButton2))
        {
            StartCoroutine (AudioFadeOut.FadeOut (wateringCanSound, FadeOut));
        }
    }
}
