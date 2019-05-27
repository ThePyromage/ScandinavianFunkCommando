using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_Attacher : MonoBehaviour
{
    Object_Shatter parent_script = null;

    void Start()
    {
        MeshFilter[] all_meshes = GetComponentsInChildren<MeshFilter>();

        foreach (MeshFilter m in all_meshes)
        {
            if (m.name.Contains("stairs"))
                continue;

            MeshCollider collider = m.gameObject.AddComponent<MeshCollider>();

            if (parent_script != null)
            {
                collider.convex = true;
                collider.isTrigger = true;
            }
        }
    }

    public void Link (Object_Shatter obj)
    {
        parent_script = obj;
	}

    void OnTriggerEnter(Collider other)
    {
        if (parent_script != null)
            parent_script.ShatterObject(other);
    }
}
