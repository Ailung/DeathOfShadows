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
    [SerializeField] private GameObject playerFlashlight;
    [SerializeField] private GameObject itemFlashlight;
    private GameObject player;

    [SerializeField] private float pickupRaycastDistance = 1f;
    [SerializeField] private float placeRaycastDistance = 2f;
    [SerializeField] public LayerMask itemsLayer;
    [SerializeField] public LayerMask floorLayer;
    private int itemsLayerInt;
    private bool hasFlashlight = false;

    private void Awake()
    {
        itemsLayerInt = LayerMask.NameToLayer("ItemsLayer");
        player = transform.parent.gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, pickupRaycastDistance, itemsLayer))
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
                        if (!hasFlashlight) FlashlightOn(hit.collider.gameObject);
                        break;
                    case "LightSwitch":
                        SwitchLightOnOff(hit.collider.gameObject);
                        break;
                    default:
                        throw new Exception("Unknown item tag: " + hit.collider.gameObject.tag);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.G) && !hasFlashlight) { DropFlashlight(); }
    }

    private void SwitchLightOnOff(GameObject lightSwitch)
    {
        
    }

    private void DropFlashlight()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, placeRaycastDistance, floorLayer))
        {
            Vector3 spawnPosition = hit.point + new Vector3(0,.04f,0);

            Quaternion spawnRotation = Quaternion.Euler(90, player.transform.eulerAngles.y,0);

            GameObject newFlashlight = Instantiate(itemFlashlight, spawnPosition, spawnRotation);
            newFlashlight.tag = "Flashlight";
            newFlashlight.layer = itemsLayerInt;

            FlashlightOff();
        }
    }
    private void FlashlightOn(GameObject externalGameObject)
    {
        playerFlashlight.SetActive(true);
        Destroy(externalGameObject);
        hasFlashlight = true;
    }
    private void FlashlightOff()
    {
        playerFlashlight.SetActive(false);
        hasFlashlight = false;
    }




}
