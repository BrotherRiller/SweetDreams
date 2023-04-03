using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberInputTrigger : MonoBehaviour
{
    private bool ifChecked = false;

    [SerializeField] bool rightAnswer1;
    [SerializeField] bool rightAnswer2;
    [SerializeField] bool rightAnswer3;
    [SerializeField] bool falseAnswer;

    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = this.transform.position;
    }

    public void TriggerInput()
    {
        if (!ifChecked)
        {
            transform.position += new Vector3(0, 0, -0.2f);
            ifChecked = true;
            Debug.Log("Yes");
        }
    }

    public void ReturnDefault()
    {
        transform.position = originalPosition;
        ifChecked = false;
    }

    public bool checkInput()
    {
        return ifChecked;
    }

    public bool isRightAnswer1()
    {
        return rightAnswer1;
    }
    public bool isRightAnswer2()
    {
        return rightAnswer2;
    }
    public bool isRightAnswer3()
    {
        return rightAnswer3;
    }

    public bool isFalseAnswer()
    {
        return falseAnswer;
    }
}
