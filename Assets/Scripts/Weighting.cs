using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weighting : MonoBehaviour
{
    [SerializeField] GameObject tilter;
    [SerializeField] GameObject cup1;
    [SerializeField] GameObject cup2;
    [SerializeField] GameObject socket1;
    [SerializeField] GameObject socket2;

    bool onlyOnce = false;
    bool alsoOnlyOnce = false;
    bool right = false;
    bool left = false;
    int standardWeight = 0;
    int weight1;
    int weight2;

    private void Update()
    {
        if(socket1.transform.childCount > 0)
        {
            weight1 = socket1.transform.GetChild(0).GetComponent<Weight>().GetWeight();
        }
        else
        {
            weight1 = standardWeight;
        }
        if(socket2.transform.childCount > 0)
        {
            weight2 = socket2.transform.GetChild(0).GetComponent<Weight>().GetWeight();
        }
        else
        {
            weight2 = standardWeight;
        }

        if(weight2 > weight1 && !onlyOnce)
        {
            if (alsoOnlyOnce)
            {
                tilter.transform.Rotate(50, 0, 0, Space.World);
                cup1.transform.position += new Vector3(0, 2.2f, 0);
                cup2.transform.position -= new Vector3(0, 2.6f, 0);
                alsoOnlyOnce = false;
            }
            else
            {
                tilter.transform.Rotate(25, 0, 0, Space.World);
                cup1.transform.position += new Vector3(0, 1.1f, 0);
                cup2.transform.position -= new Vector3(0, 1.3f, 0);
            }
            onlyOnce = true;
            left = false;
            right = true;
        }
        if(weight2 < weight1 && !alsoOnlyOnce)
        {
            if (onlyOnce)
            {
                tilter.transform.Rotate(-50, 0, 0, Space.World);
                cup1.transform.position -= new Vector3(0, 2.2f, 0);
                cup2.transform.position += new Vector3(0, 2.6f, 0);
                onlyOnce = false;
            }
            else
            {
                tilter.transform.Rotate(-25, 0, 0, Space.World);
                cup1.transform.position -= new Vector3(0, 1.1f, 0);
                cup2.transform.position += new Vector3(0, 1.3f, 0);
            }
            alsoOnlyOnce = true;
            left = true;
            right = false;
        }

        if(weight1 == weight2 && left)
        {
            tilter.transform.Rotate(25, 0, 0, Space.World);
            cup1.transform.position += new Vector3(0, 1.1f, 0);
            cup2.transform.position -= new Vector3(0, 1.3f, 0);
            left = false;
            onlyOnce = false;
            alsoOnlyOnce = false;

        }
        if(weight1 == weight2 && right)
        {
            tilter.transform.Rotate(-25, 0, 0, Space.World);
            cup1.transform.position -= new Vector3(0, 1.1f, 0);
            cup2.transform.position += new Vector3(0, 1.3f, 0);
            right = false;
            onlyOnce = false;
            alsoOnlyOnce = false;
        }

        Debug.Log(weight1);
        Debug.Log(weight2);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tilter.transform.Rotate(25, 0, 0, Space.World);
            cup1.transform.position += new Vector3(0, 1.1f, 0);
            cup2.transform.position -= new Vector3(0, 1.3f, 0);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tilter.transform.Rotate(-25, 0, 0, Space.World);
            cup1.transform.position -= new Vector3(0, 1.1f, 0);
            cup2.transform.position += new Vector3(0, 1.3f, 0);
        }
    }
}
