using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform objectContainer;
    [SerializeField] Transform cam;
    [SerializeField] Rigidbody rb;
    [SerializeField] BoxCollider coll;

    private float pickUpRange = 4f;
    private float dropForwardForce = 15f;
    private float dropUpwardForce= 7f;
    private bool cooldown = false;
    private bool equipped = false;
    private static bool slotFull;


    private void Start()
    {
        if (!equipped)
        {
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        if (equipped)
        {
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }

    private void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        
        if(!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKey(KeyCode.E) && !cooldown && !slotFull)
        {
            PickObjectUp();
            Invoke("ResetCooldown", 1f);
            cooldown = true;
        }
        if(equipped && Input.GetKey(KeyCode.Q) && !cooldown)
        {
            Drop();
            Invoke("ResetCooldown", 1f);
            cooldown = true;
        }
    }


    private void PickObjectUp()
    {
        equipped = true;
        slotFull = true;

        transform.SetParent(objectContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        

        rb.isKinematic = true;
        coll.isTrigger = true;

    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;

        transform.SetParent(null);

        rb.isKinematic = false;
        coll.isTrigger = false;

        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        rb.AddForce(cam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(cam.up * dropUpwardForce, ForceMode.Impulse);

        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10);

        rb.isKinematic = false;
        coll.isTrigger = false;
    }
    void ResetCooldown()
    {
        cooldown = false;
    }
}
