using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics_Attacher : MonoBehaviour
{
    List<MeshRenderer> meshes;

	// Use this for initialization
	void Start ()
    {
        meshes = new List<MeshRenderer>(GetComponentsInChildren<MeshRenderer>());

        foreach(MeshRenderer mr in meshes)
        {
            mr.gameObject.AddComponent<Rigidbody>();
            MeshCollider collider = mr.gameObject.AddComponent<MeshCollider>();
            collider.convex = true;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
