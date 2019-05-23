using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
	[Tooltip("List of all enemies in this room")]
	[SerializeField] private EnemySpawn[] m_enemies;

	private void OnTriggerEnter(Collider other)
	{
		//check if trigger is a player
		if(other.tag == "Player")
		{
			Debug.Log("Player has entered room " + gameObject.name.ToString());
			//Spawn each enemy in the room
			foreach (EnemySpawn enemySpawner in m_enemies)
			{
				enemySpawner.SpawnEnemy();
			}
		}
	}
}
