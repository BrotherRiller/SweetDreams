using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerState : MonoBehaviour
{
    [SerializeField] string changeTo;
    [SerializeField] bool interactable;
    [SerializeField] bool automatic;

    private bool cooldown = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (Input.GetKey(KeyCode.E) && !cooldown && interactable || automatic)
            {
                var player = other.GetComponent<PlayerState>();

                Debug.Log("CHANGE TO " + changeTo);
                switch (changeTo)
                {
                    case "reset":
                        player.playerState = PlayerState.State.reset;
                        break;
                    case "real":
                        player.playerState = PlayerState.State.real;
                        break;
                    case "dream":
                        player.playerState = PlayerState.State.dream;
                        break;
                    case "jumpnrun":
                        player.playerState = PlayerState.State.jumpnrun;
                        break;
                    case "torch":
                        player.playerState = PlayerState.State.torch;
                        break;
                    default:
                        player.playerState = PlayerState.State.real;
                        break;
                }
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
