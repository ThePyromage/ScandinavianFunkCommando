using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
	[SerializeField] private EnemySpawn[] m_enemies;

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			Debug.Log("Player has entered room " + gameObject.name.ToString());
			foreach(EnemySpawn enemySpawner in m_enemies)
			{
				enemySpawner.SpawnEnemy();
			}
		}
	}
}
