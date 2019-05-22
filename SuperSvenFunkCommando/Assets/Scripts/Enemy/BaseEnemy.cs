using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
	[Tooltip("How long between shots")]
	[SerializeField] private float m_shootTimer;
	//the current timer
	private float m_currentTimer = 0.0f;

	[Tooltip("The prefab of the bullet this enemy shoots")]
	[SerializeField] private GameObject m_bulletPrefab;
	[Tooltip("The location the bullet shoots from")]
	[SerializeField] private Transform m_bulletSource;
	//whether or not the enemy should be tracking and shooting at Sven
	private bool m_isActive;

	//the player
	private GameObject m_player;



	// Use this for initialization
	void Start ()
	{
		m_player = GameObject.FindGameObjectWithTag("Player");
		if (m_player == null)
			Debug.LogWarning("There is no object with the 'Player' tag!");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (m_isActive)
		{
			m_currentTimer += Time.deltaTime;

			if (m_currentTimer >= m_shootTimer)
			{
				//shoot at player
			}
		}
	}
}
