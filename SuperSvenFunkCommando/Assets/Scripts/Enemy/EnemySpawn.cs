using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
	[Tooltip("The enemy that will spawn here")]
	[SerializeField] private GameObject m_enemy;

	[Tooltip("How long from Sven entering the room until spawning the enemy")]
	[SerializeField] private float m_spawnDelay;
	//the current timer
	private float m_timer = 0.0f;

	//whether or not this spawner is active
	private bool m_isActive = false;
	//whether or not this spawner has spawned it's enemy
	private bool m_hasSpawned = false;

	/// <summary>
	/// Function to spawn the enemy
	/// </summary>
	public void SpawnEnemy()
	{
		if(!m_hasSpawned)
			m_isActive = true;
	}

	void Update()
	{
		if (m_isActive)
		{
			m_timer += Time.deltaTime;
			if(m_timer >= m_spawnDelay)
			{
				Debug.Log(gameObject.name.ToString() + " has spawned!");
				m_enemy.SetActive(true);
				m_isActive = false;
				m_hasSpawned = true;
			}
		}
	}
}
