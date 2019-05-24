using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_Attacher : MonoBehaviour
{
    Object_Shatter parent_script = null;

    private void Start()
    {
        MeshFilter[] all_meshes = GetComponentsInChildren<MeshFilter>();

        foreach (MeshFilter m in all_meshes)
        {
            MeshCollider collider = m.gameObject.AddComponent<MeshCollider>();

            if (parent_script != null)
            {
                collider.convex = true;
                collider.isTrigger = true;
            }
        }
    }

    public void Link (Object_Shatter os)
    {
        parent_script = os;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (parent_script != null)
            parent_script.ShatterObject(other);
    }
}
