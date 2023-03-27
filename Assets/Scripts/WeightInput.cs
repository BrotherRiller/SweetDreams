using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightInput : MonoBehaviour
{
    [SerializeField] GameObject RotatingObject1;
    [SerializeField] GameObject RotatingObject2;
    [SerializeField] GameObject RotatingObject3;
    [SerializeField] Animator Door;

    private int check1;
    private int check2;
    private int check3;

    private void Update()
    {
        check1 = Mathf.RoundToInt(RotatingObject1.transform.rotation.eulerAngles.y);
        check2 = Mathf.RoundToInt(RotatingObject2.transform.rotation.eulerAngles.y);
        check3 = Mathf.RoundToInt(RotatingObject3.transform.rotation.eulerAngles.y);

        if (check1 == 0 && check2 == 60 && check3 == 120)
        {
            Door.Play("EgyptDoorOpen");
        }
    }
}
