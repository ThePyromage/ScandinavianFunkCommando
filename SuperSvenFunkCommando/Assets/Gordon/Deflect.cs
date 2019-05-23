using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deflect : MonoBehaviour
{
    private GameObject m_bullet;
    private Rigidbody m_bulletRB;

    private void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "Projectile")
        {
            m_bullet = collider.gameObject;
            m_bulletRB = m_bullet.GetComponent<Rigidbody>();
            Debug.Log("hit");
            m_bulletRB.AddForce( m_bulletRB.velocity * -2.0f, ForceMode.Impulse);
        }
    }
}
