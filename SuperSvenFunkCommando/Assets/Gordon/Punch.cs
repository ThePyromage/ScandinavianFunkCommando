using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    private bool canPunch = true;
    private float timeBetweenPunch = 0.35f;
    private float timeBetweenActive = 0.15f;
    public GameObject hitbox;
    public GameObject bullet;

    private void Update()
    {
        CanPunch();
    }

    private void CanPunch()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (canPunch)
            {
                hitbox.SetActive(true);
                canPunch = false;
                Invoke("ResetPunch", timeBetweenPunch);
                Invoke("DelayAfter", timeBetweenActive);
            }
        }
    }

    private void ResetPunch()
    {
        canPunch = true;
    }

    private void DelayAfter()
    {
        hitbox.SetActive(false);
    }
}
