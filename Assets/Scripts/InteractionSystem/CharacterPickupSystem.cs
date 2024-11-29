using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterPickupSystem : MonoBehaviour
{
    private bool keyItem1;
    private bool keyItem2;
    [SerializeField] private GameObject flashlight;

    [SerializeField] private float pickupRaycastDistance = 1f;
    [SerializeField] private float placeRaycastDistance = 2f;
    public LayerMask pickableLayer;
    public LayerMask floorLayer;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, pickupRaycastDistance, pickableLayer))
            {
                switch (hit.collider.gameObject.tag)
                {
                    case "KeyItem1":
                        keyItem1 = true;
                        Destroy(hit.collider.gameObject);
                        break;
                    case "KeyItem2":
                        keyItem2 = true;
                        Destroy(hit.collider.gameObject);
                        break;
                    case "Flashlight":
                        FlashlightOn(hit.collider.gameObject);
                        break;
                    default:
                        throw new Exception("Unknown item tag: " + hit.collider.gameObject.tag);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.G)) { DropFlashlight(); }
    }
    private void DropFlashlight()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, placeRaycastDistance, floorLayer))
        {
            Vector3 spawnPosition = hit.point + new Vector3(0, 0, (float)0.5);
            Quaternion spawnRotation = Quaternion.LookRotation(transform.forward);
            spawnRotation.x = 90f;
            Debug.Log(spawnRotation + "wanted");
            GameObject newFlashlight = Instantiate(flashlight, spawnPosition, Quaternion.identity);
            Debug.Log(newFlashlight.transform.rotation + "not final");
            newFlashlight.transform.rotation = spawnRotation;
            Debug.Log(newFlashlight.transform.rotation + "actual");

            //newFlashlight.tag = "Flashlight";
            //newFlashlight.layer = pickableLayer;

            FlashlightOff();
        }
    }
    private void FlashlightOn(GameObject externalGameObject)
    {
        flashlight.SetActive(true);
        Destroy(externalGameObject);
    }
    private void FlashlightOff()
    {
        flashlight.SetActive(false);
    }




}
