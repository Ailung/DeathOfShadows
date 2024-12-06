using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    [SerializeField] private List<Light> lights;
    [SerializeField] private bool isOn;
    [SerializeField] private List<GameObject> lightSwitches;

    private void Awake()
    {
        changeState();
    }

    public void changeState()
    {
        switchRotation();
        OnOffState();
        isOn = !isOn;
    }

    private void switchRotation()
    {
        if (isOn)
        {
            foreach (GameObject lightSwitch in lightSwitches) { lightSwitch.transform.localEulerAngles = new Vector3(0, 0, 0); }
            
        }
        else
        {
            foreach (GameObject lightSwitch in lightSwitches) { lightSwitch.transform.localEulerAngles = new Vector3(60, 0, 0); }
            
        }
    }

    private void OnOffState()
    {
        if (isOn)
        {
            foreach (Light light in lights) { light.enabled = true; }
            AudioManager.Instance.PlaySFX("switch");
        }
        else
        {
            foreach (Light light in lights) { light.enabled = false; }
            AudioManager.Instance.PlaySFX("switch");
        }
    }
}
