using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberInputChecker : MonoBehaviour
{
    [SerializeField] GameObject[] numbers;
    [SerializeField] Animator door;

    NumberInputTrigger check;

    bool gotAnswer1 = false;
    bool gotAnswer2 = false;
    bool wrongAnswer = false;

    // Update is called once per frame
    void Update()
    {
        foreach (var number in numbers)
        {
            check = number.GetComponent<NumberInputTrigger>();

            if (check.checkInput())
            {
               
                if (check.isFalseAnswer())
                {
                    wrongAnswer = true;
                }
                if (check.isRightAnswer1())
                { 
                    gotAnswer1 = true;
                }
                if(check.isRightAnswer2() && gotAnswer1)
                {
                    gotAnswer2 = true;
                }
                if(check.isRightAnswer3() && gotAnswer2)
                {
                    door.Play("EgyptDoorOpen");
                }
            }
            if (wrongAnswer)
            {
                if (check.checkInput())
                {
                    Debug.Log("kommt auch an");
                    check.ReturnDefault();
                }
                else
                {
                    Debug.Log("kommt an");
                    wrongAnswer = false;
                    gotAnswer1 = false;
                    gotAnswer2 = false;
                }
            }
        }
    }
}
