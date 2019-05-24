using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    Animator m_Animator;
    public bool canLeftP;
    public bool canRightP;

	// Use this for initialization
	void Start () {
        canLeftP = true;
        canRightP = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if ((canLeftP == true) && (canRightP == true))
            {
                m_Animator.SetBool("LeftPunch", true);
            }

        }

        if (Input.GetMouseButtonDown(1))
        {
            if ((canLeftP == true) && (canRightP == true))
            {
                m_Animator.SetBool("RightPunch", true);
            }
        }

    }

}

