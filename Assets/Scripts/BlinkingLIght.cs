using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlinkingLIght : MonoBehaviour
{
    private Light light;
    [SerializeField] private Light[] lights;
    [SerializeField] private float[] times;
    [SerializeField] private float[] intensities;
    private int i = 0;

    [SerializeField] float minTime;
    [SerializeField] float maxTime;
    [SerializeField] bool pattern;
    [SerializeField] bool sound;
    [SerializeField] string soundName;
    [SerializeField] AudioSource audioSource;
     float timer;
    
    // Start is called before the first frame update
    void Awake()
    {
        light = this.GetComponent<Light>();

    }

    private void Start()
    {
        timer = Random.Range(minTime, maxTime);
        if (pattern)
        {
            blink();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!pattern)
        {
            blink();
        }
    }

    private void blink() 
    {
        if (pattern) 
        {

            if (times.Length == intensities.Length && i < times.Length) 
            {

                StartCoroutine(patternBlink(intensities[i], times[i]));

            } else
            {
                i = 0;
                StartCoroutine(patternBlink(intensities[i], times[i]));
            }
        } 
        else
        {
            if (timer > 0) timer -= Time.deltaTime;

            if (timer <= 0)
            {

                if (lights.Length <= 0)
                {
                    light.enabled = !light.enabled;

                }
                else
                {
                    foreach (Light light in lights)
                    {
                        light.enabled = !light.enabled;
                    }
                }
                timer = Random.Range(minTime, maxTime);
            }
            
        }
        
    }

    private IEnumerator patternBlink(float intensity, float time)
    {
        
        if (lights.Length <= 0)
        {
            light.intensity = intensity;
            if (intensity > 0 && sound)
            {
                AudioManager.Instance.PlaySFX(soundName, audioSource);
            }
        }
        else
        {
            foreach (Light light in lights)
            {
                light.intensity = intensity;
                if (intensity > 0 && sound)
                {
                    AudioManager.Instance.PlaySFX(soundName, audioSource);
                }
            }
        }
        i++;
        yield return new WaitForSeconds(time);
        blink();
    }

}
