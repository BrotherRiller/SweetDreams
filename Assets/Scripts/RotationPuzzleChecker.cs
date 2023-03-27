using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPuzzleChecker : MonoBehaviour
{

    [SerializeField] GameObject RotatingObject1;
    [SerializeField] GameObject RotatingObject2;
    [SerializeField] GameObject RotatingObject3;
    [SerializeField] GameObject RotatingObject4;
    [SerializeField] Animator Door;

    private int check1;
    private int check2;
    private int check3;
    private int check4;

    private void Update()
    {
        check1 = Mathf.FloorToInt(RotatingObject1.transform.rotation.eulerAngles.y);
        check2 = Mathf.FloorToInt(RotatingObject2.transform.rotation.eulerAngles.y);
        check3 = Mathf.FloorToInt(RotatingObject3.transform.rotation.eulerAngles.y);
        check4 = Mathf.FloorToInt(RotatingObject4.transform.rotation.eulerAngles.y);

        if (check1 == 157 && check2 == 22 && check3 == 247 && check4 == 112)
        {
            Door.Play("EgyptDoorOpen");
        }
    }
    
    
}
