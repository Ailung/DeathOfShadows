using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLIght : MonoBehaviour
{
    private Light light;
    [SerializeField] private Light[] lights;

    [SerializeField] float minTime;
    [SerializeField] float maxTime;
    [SerializeField] float timer;
    
    // Start is called before the first frame update
    void Awake()
    {
        light = this.GetComponent<Light>();

    }

    private void Start()
    {
        timer = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        blink();
    }

    private void blink() 
    {
        if (timer > 0) timer -= Time.deltaTime;

        if (timer <= 0)
        {
            if (lights.Length <= 0) 
            {
                light.enabled = !light.enabled;
            } else
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
