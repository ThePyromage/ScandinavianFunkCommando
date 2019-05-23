using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
	//the player, find on start
	private Transform m_player;

	[Tooltip("Whether or not this object should rotate towards player in the X axis")]
	[SerializeField] private bool m_rotateX;
	// Use this for initialization
	void Start ()
	{
		//find the player
		m_player = GameObject.FindGameObjectWithTag("Player").transform;
		if(m_player == null) //if player isn't found, warn
			Debug.LogWarning("There is no object with the 'Player' tag!");
	}
	
	// Update is called once per frame
	void Update ()
	{
		//rotate towards player in all axis
		if(m_rotateX)
		{
			Vector3 lookPos = m_player.transform.position - transform.position;
			Quaternion targetRotation = Quaternion.LookRotation(lookPos);
			transform.rotation = targetRotation;
		}
		//rotate towards the player in z and y axis
		else
		{
			Vector3 lookPos = m_player.transform.position - transform.position;
			lookPos.y = transform.position.y;
			Quaternion targetRotation = Quaternion.LookRotation(lookPos);
			transform.rotation = targetRotation;
		}
	}
}
