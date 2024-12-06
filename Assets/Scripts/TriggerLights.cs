using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLights : MonoBehaviour
{
    [SerializeField] private List<Light> lights;
    [SerializeField] private float timeToRestart;
    [SerializeField] private bool restartBool;
    [SerializeField] private string soundName;
    [SerializeField] private string soundName2;
    [SerializeField] private AudioSource soundSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            lightEffect();
            if (!restartBool)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    private void lightEffect()
    {
        foreach (Light light in lights)
        {
            light.enabled = !light.enabled;
        }
        AudioManager.Instance.PlaySFX(soundName, soundSource);

        if (restartBool)
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
        AudioManager.Instance.PlaySFX(soundName2, soundSource);
        this.gameObject.SetActive(false);
    }
}
