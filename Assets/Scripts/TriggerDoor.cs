using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    [SerializeField] Animator myDoor;
    [SerializeField] string doorOpen;
    [SerializeField] string doorClose;

    private int counter = 0;
    private bool openTrigger;
    private bool closeTrigger;
    private bool cooldown = false;


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E) && !cooldown)
            {
                if (counter % 2 == 0)
                {
                    myDoor.Play(doorOpen, 0, 0.0f);
                    Debug.Log("Test1");
                    Invoke("ResetCooldown", 1f);
                    cooldown = true;
                    counter++;
                }
                else if (counter % 2 == 1)
                {
                    myDoor.Play(doorClose, 0, 0.0f);
                    Debug.Log("Test2");
                    Invoke("ResetCooldown", 1f);
                    cooldown = true;
                    counter++;
                }
            }
        }
    }

    void ResetCooldown()
    {
        cooldown = false;
    }
}
