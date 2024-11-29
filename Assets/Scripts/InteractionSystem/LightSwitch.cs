using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    [SerializeField] private List<Light> lights;

    public void changeState()
    {
        foreach (Light light in lights) { light.enabled = !light.enabled; }
    }
}
