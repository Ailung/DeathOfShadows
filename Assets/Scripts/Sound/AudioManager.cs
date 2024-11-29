using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Start()
    {
        PlayMusic("house1");
    }

    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); }
    }

    public void PlayMusic(string name)
    {
        Sound sound = Array.Find(musicSounds, x => x.soundName == name);
        if (sound == null) { Debug.Log("Sound " + name + " not found"); }
        else{ musicSource.clip = sound.clip; musicSource.Play(); }
    }
    public void PlaySFX(string name)
    {
        Sound sound = Array.Find(sfxSounds, x => x.soundName == name);
        if (sound == null) { Debug.Log("sfx " + name + " not found"); }
        else{ sfxSource.clip = sound.clip; sfxSource.Play(); }
    }
}
