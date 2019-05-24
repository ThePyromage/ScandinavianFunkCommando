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
            object_instance.GetComponent<Physics_Attacher>().Initiate();

            Vector3 explosion_position = other.transform.childCount == 1 ? other.transform.GetChild(0).position : other.transform.position;

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
