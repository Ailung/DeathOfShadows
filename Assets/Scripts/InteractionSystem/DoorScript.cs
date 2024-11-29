using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private bool isOpen = false;
    private bool opening = false;
    private bool closing = false;

    [SerializeField] private float angle;
    private Quaternion targetRotation;
    private Quaternion startingRotation;
    [SerializeField] private float animationTime;

    private void Start()
    {
        startingRotation = transform.rotation;
        targetRotation = Quaternion.Euler(0f, angle, 0f) * transform.rotation;
    }
    public void Interact()
    {
        Debug.Log("interact");

        if (isOpen && !opening && !closing) //close
        {
            closing = true;
        }
        else if (!isOpen && !opening & !closing) //open
        {
            opening = true;
        }
        else if (opening) 
        {
            return;
        }
        else if (closing) 
        {
            return;
        }
    }
    private void Update()
    {
        if (opening)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime / animationTime);

            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                opening = false;
                transform.rotation = targetRotation;
                isOpen = true;
            }
        }
        if (closing)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, startingRotation, Time.deltaTime / animationTime);

            if (Quaternion.Angle(transform.rotation, startingRotation) < 0.1f)
            {
                closing = false;
                transform.rotation = startingRotation;
                isOpen = false;
            }
        }

    }
}
