using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Shatter : MonoBehaviour
{
    public GameObject shatteredObject;

    bool is_shattered;
    GameObject object_instance;

    void Start()
    {
        if (transform.childCount == 1)
        {
            object_instance = transform.GetChild(0).gameObject;

            BoxCollider box_collider = gameObject.AddComponent<BoxCollider>();
            MeshRenderer rend = object_instance.GetComponent<MeshRenderer>();

            box_collider.isTrigger = true;
            box_collider.center = object_instance.transform.localPosition + Vector3.up * rend.bounds.extents.y;
            box_collider.size = rend.bounds.size;
        }
        else
            Debug.Log("Object Shatterer should only have one child object");

        is_shattered = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (is_shattered == false)
        {
            Destroy(object_instance);
            object_instance = Instantiate(shatteredObject, transform.position, Quaternion.identity);

            is_shattered = true;
        }
    }
}
