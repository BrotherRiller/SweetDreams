using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberGuesser : MonoBehaviour
{
    [SerializeField] GameObject number1;
    [SerializeField] GameObject number2;
    [SerializeField] GameObject number3;

    [SerializeField] GameObject socket1;
    [SerializeField] GameObject socket2;
    [SerializeField] GameObject socket3;

    [SerializeField] Animator door;

    bool answer1 = false;
    bool answer2 = false;
    bool answer3 = false;

    private void Update()
    {
        if (socket1.transform.childCount > 0 && number1.transform == socket1.transform.GetChild(0)) 
        {
            answer1 = true;
        }
        if (socket2.transform.childCount > 0 && number2.transform == socket2.transform.GetChild(0))
        {
            answer2 = true;
        }
        if (socket3.transform.childCount > 0 && number3.transform == socket3.transform.GetChild(0))
        {
            answer3 = true;
        }

        if(answer1 && answer2 && answer3)
        {
            Debug.Log("Geschafft");
        }
    }
}
