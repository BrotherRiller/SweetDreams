using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] GameObject dreamLocation;
    [SerializeField] bool interactable;
    [SerializeField] bool automatic;

    private bool cooldown = false;
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E) && !cooldown && interactable || automatic)
            {
                var charContrl = other.GetComponent<CharacterController>();

                charContrl.enabled = false;
                other.gameObject.transform.position = dreamLocation.transform.position;
                charContrl.enabled = true;
                Invoke("ResetCooldown", 1f);
                cooldown = true;
            }
        }
    }

    void ResetCooldown()
    {
        cooldown = false;
    }
}
