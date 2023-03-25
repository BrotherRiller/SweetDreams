using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{

    [SerializeField] GameObject Object;

    private void Update()
    {
        if(Mathf.FloorToInt(Object.transform.rotation.eulerAngles.y) == 22)
        {
            Debug.Log("GESCHAFFT");
        }
    }
    
    void Rotate()
    {
            
        Object.transform.Rotate(0, 45, 0 * Time.deltaTime, Space.World);
        Debug.Log(Object.transform.rotation.eulerAngles.y);
        
        
            
    }
}
