using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] Transform objectContainer;

    private Rigidbody rb;
    private BoxCollider coll;

    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        coll = this.gameObject.GetComponent<BoxCollider>();
    }


    public void PickObjectUp()
    {
        transform.SetParent(objectContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        

        rb.isKinematic = true;
        coll.isTrigger = true;

    }

    public void PlaceObject(GameObject socket)
    {
        transform.SetParent(socket.transform);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = new Vector3(1.01f, 1.01f, 1.01f);

        rb.isKinematic = true;
        coll.isTrigger = true;
    }

    public void Drop()
    {

        transform.SetParent(null);

        rb.isKinematic = false;
        coll.isTrigger = false;
    }
}
