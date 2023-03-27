using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] GameObject objectHolder;
    private bool cooldown = false;

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 10))
        {
            Debug.Log(hit.transform.tag);
            var selection = hit.transform;

            if(Input.GetKey(KeyCode.E) && !cooldown && selection.CompareTag("PickUpable") && objectHolder.transform.childCount <= 0)
            {
                var pickUp = selection.GetComponent<PickUp>();
                pickUp.PickObjectUp();
                
                Invoke("ResetCooldown", 1f);
                cooldown = true;
            }
            if(Input.GetKey(KeyCode.E) && !cooldown && selection.CompareTag("PlaceObject") && objectHolder.transform.childCount > 0)
            {

                var placeObject = objectHolder.transform.GetChild(0).GetComponent<PickUp>();
                placeObject.PlaceObject(selection.gameObject);
                
                Invoke("ResetCooldown", 1f);
                cooldown = true;
            }

            if (Input.GetKey(KeyCode.E) && !cooldown && selection.CompareTag("RotationPuzzle"))
            {
                var rotate = selection.GetComponent<RotateObject>();
                rotate.Rotate();

                Invoke("ResetCooldown", 1f);
                cooldown = true;
            }
            if (Input.GetKey(KeyCode.E) && !cooldown && selection.CompareTag("NumberBlock"))
            {
                var input = selection.GetComponent<NumberInputTrigger>();
                input.TriggerInput();

                Invoke("ResetCooldown", 1f);
                cooldown = true;
            }
        }
        if (Input.GetKey(KeyCode.Q) && !cooldown && objectHolder.transform.childCount > 0)
        {
            var pickUp = objectHolder.transform.GetChild(0).GetComponent<PickUp>();
            pickUp.Drop();
            
            Invoke("ResetCooldown", 1f);
            cooldown = true;
        }
        
    }

    void ResetCooldown()
    {
        cooldown = false;
    }
}
