using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberInputChecker : MonoBehaviour
{
    [SerializeField] GameObject[] numbers;
    [SerializeField] Animator door;
    [SerializeField] TextMeshProUGUI question;

    NumberInputTrigger check;

    bool gotAnswer1 = false;
    bool gotAnswer2 = false;
    bool wrongAnswer = false;

    string question1 = "If you look out the window behind you, how many cactus are there?";
    string question2 = "How many desert tree are there?";
    string question3 = "How many ponds are there?";

    string wrong = "Wrong Answer, try again!";
    string right = "You did it! Proceed to the next room!";

    private void Start()
    {
        question.text = question1;
    }

    void Update()
    {
        foreach (var number in numbers)
        {
            check = number.GetComponent<NumberInputTrigger>();

            if (check.checkInput())
            {
                Debug.Log(check.isRightAnswer1());
                Debug.Log(check.isRightAnswer2());
                Debug.Log(check.isRightAnswer3());

                if (check.isFalseAnswer())
                {
                    wrongAnswer = true;
                    question.text = wrong;
                    Invoke("ResetQuestion", 1f);
                }
                if (check.isRightAnswer1() && !gotAnswer2)
                {
                    gotAnswer1 = true;
                    question.text = question2;
                }
                if(check.isRightAnswer2() && gotAnswer1)
                {
                    gotAnswer1 = false;
                    gotAnswer2 = true;
                    question.text = question3;
                }
                if(check.isRightAnswer3() && gotAnswer2)
                {
                    question.text = right;
                    door.Play("EgyptDoorOpen3");
                }
            }
            if (wrongAnswer)
            {
                if (check.checkInput())
                {
                    check.ReturnDefault();
                }
                else
                {
                    wrongAnswer = false;
                    gotAnswer1 = false;
                    gotAnswer2 = false;
                }
            }
        }
    }

    void ResetQuestion()
    {
        question.text = question1;
    }
}
