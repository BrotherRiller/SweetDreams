using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] bool labyrinth;
    [SerializeField] bool weight;

    // Start is called before the first frame update
    public void Rotate()
    {
        if (labyrinth)
        {
            this.transform.Rotate(0, 45, 0 * Time.deltaTime, Space.World);
        }
        if (weight)
        {
            this.transform.Rotate(0, 60, 0 * Time.deltaTime, Space.World);
        }
    }
}
