using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadEnemy : BaseEnemy
{
	[Tooltip("How many shots in the spread")]
	[SerializeField] private int m_shotCount;
	[Tooltip("The angle between shots in the spread")]
	[SerializeField] private float m_shotAngle;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
