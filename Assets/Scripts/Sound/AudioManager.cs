using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource;
    public List<AudioSource> sfxSources;

    

    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = this; DontDestroyOnLoad(gameObject); 
        }
        else 
        {
            Destroy(gameObject); 
        }
    }

    private void Start()
    {
        PlayMusic("house1");
    }

    public void PlayMusic(string name)
    {
        Sound sound = Array.Find(musicSounds, x => x.soundName == name);
        
        if (musicSource != null && sound != null)
        {
            musicSource.clip = sound.clip;
            musicSource.loop = true;
            musicSource.spatialBlend = 0f;
            musicSource.Play(); 
        }
        else
        {
            Debug.Log("Sound " + name + " not found");
        }
    }
    public void PlaySFX(string name)
    {
        Sound sound = Array.Find(sfxSounds, x => x.soundName == name);

        //if (sound == null) 
        //{ 
        //    Debug.Log("sfx " + name + " not found"); 
        //}
        //else
        //{ 
        //    sfxSource.clip = sound.clip; sfxSource.Play(); 
        //}
        if(sound == null) 
        {
            Debug.Log("sfx " + name + " not found"); 
        }
        else
        {
            foreach (AudioSource source in sfxSources)
            {
                if (!source.isPlaying)
                {
                    source.clip = sound.clip;
                    source.spatialBlend = 1f;
                    source.Play();
                    return;
                }
            }
        }
        
    }
}
