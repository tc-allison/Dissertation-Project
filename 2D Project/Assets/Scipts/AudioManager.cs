using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    [Header("----- Audio Source -----")]
    public AudioSource musicSource;
    public AudioSource SFXSource;

    [Header("----- Audio Clip -----")]
    public AudioClip jump;
    public AudioClip music;
    public AudioClip land;

    // Start is called before the first frame update
    void Start()
    {
        #if game_feel
        musicSource.clip = music;
        musicSource.Play();
        #endif

    }

    // Update is called once per frame
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
