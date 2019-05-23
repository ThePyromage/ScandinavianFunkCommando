using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstEnemy : BaseEnemy
{
	[Tooltip("How many shots will be fired in the burst")]
	[Range(1,5)][SerializeField] private int m_burstSize;
	[Tooltip("How long between each shot in the burst")]
	[SerializeField] private float m_burstDelay;

	override protected void Fire()
	{
		Debug.Log("Burst enemy fire!");
		//TODO, make this burst
		Vector3 lookPos = m_player.transform.position - m_bulletSource.position;
		Quaternion targetRotation = Quaternion.LookRotation(lookPos);
		Instantiate(m_bulletPrefab, m_bulletSource.position, targetRotation);
	}
}
