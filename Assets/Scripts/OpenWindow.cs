using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWindow : MonoBehaviour
{
    [SerializeField] Animator window;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            window.Play("EgyptWindowOpen");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            window.Play("EgyptWindowClose");
        }
    }
}
