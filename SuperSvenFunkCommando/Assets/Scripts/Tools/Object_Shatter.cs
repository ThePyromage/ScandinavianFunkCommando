using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Shatter : MonoBehaviour
{
    [Tooltip ("The object that will replace the current one on trigger enter")]
    public GameObject shatteredObject;
    [Tooltip ("Explosion power applied to the shattering wall")]
    public float explosion_power = 100;
    [Tooltip ("Explosion range in Unity units")]
    public float explosion_range = 5;

    bool is_shattered;
    GameObject object_instance;

    void Start()
    {
        if (transform.childCount == 1)
        {
            object_instance = transform.GetChild(0).gameObject; 

            Collider_Attacher ca = object_instance.AddComponent<Collider_Attacher>();
            ca.Link(this);
        }
        else
            Debug.Log("Object Shatterer should only have one child object");

        is_shattered = false;
    }

    public void ShatterObject(Collider other)
    {
        if (is_shattered == false)
        {
            Destroy(object_instance);
            object_instance = Instantiate(shatteredObject, transform.position, transform.rotation);
            object_instance.GetComponent<Physics_Attacher>().Initiate();

            Vector3 explosion_position = other.transform.GetChild(0).position;

            Collider[] colliders = Physics.OverlapSphere(explosion_position, explosion_range);
            foreach (Collider c in colliders)
            {
                Rigidbody rb = c.GetComponent<Rigidbody>();
                if (rb != null && c.tag == "Shard")
                    rb.AddExplosionForce(explosion_power, explosion_position, explosion_range, 0, ForceMode.Impulse);
            }

            is_shattered = true;
        }
    }
}
