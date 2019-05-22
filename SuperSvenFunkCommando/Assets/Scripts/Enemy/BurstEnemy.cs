using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstEnemy : BaseEnemy
{
	[Tooltip("How many shots will be fired in the burst")]
	[Range(1,5)][SerializeField] private int m_burstSize;
	[Tooltip("How long between each shot in the burst")]
	[SerializeField] private float m_burstDelay;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
