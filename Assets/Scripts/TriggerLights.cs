using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLights : MonoBehaviour
{
    [SerializeField] private List<Light> lights;
    [SerializeField] private float timeToRestart;
    [SerializeField] private bool restarBool;
    [SerializeField] private string soundName;

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }

    private void lightEffect()
    {
        foreach (Light light in lights)
        {
            light.enabled = !light.enabled;
        }
        AudioManager.Instance.PlaySFX(soundName);

        if (restarBool)
        {
            StartCoroutine(restartLight());
        }
    }

    private IEnumerator restartLight()
    {
        yield return new WaitForSeconds(timeToRestart);
        foreach (Light light in lights)
        {
            light.enabled = !light.enabled;
        }
        AudioManager.Instance.PlaySFX(soundName);
    }
}
