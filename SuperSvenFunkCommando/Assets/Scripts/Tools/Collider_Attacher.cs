using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_Attacher : MonoBehaviour
{
    Object_Shatter parent_script = null;

    private void Start()
    {
        MeshCollider collider = gameObject.AddComponent<MeshCollider>();

        collider.convex = true;
        collider.isTrigger = true;
    }

    public void Link (Object_Shatter os)
    {
        parent_script = os;
	}

    private void OnTriggerEnter(Collider other)
    {
        parent_script.ShatterObject(other);
    }
}
