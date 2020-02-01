using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    public AudioSource AudioSrc;
    private float MusicVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        AudioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        AudioSrc.volume = MusicVolume;
    }

    public void SetVolume(float vol)
    {
        MusicVolume = vol;
    }
}
