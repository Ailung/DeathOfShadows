using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpectre : MonoBehaviour
{
    [SerializeField] private GameObject[] spectreObject;
    [SerializeField] private Vector3 spectreMovement;
    [SerializeField] private float spectreForce;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            foreach (var obj in spectreObject) 
            {
                obj.GetComponent<Rigidbody>().AddForce(spectreMovement * spectreForce, ForceMode.Impulse);
            }
        }
    }
}
