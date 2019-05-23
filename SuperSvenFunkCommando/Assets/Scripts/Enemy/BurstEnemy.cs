using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstEnemy : BaseEnemy
{
	[Tooltip("How many shots will be fired in the burst")]
	[Range(1,10)][SerializeField] private int m_burstSize;

	[Tooltip("How long between each shot in the burst")]
	[SerializeField] private float m_burstDelay;
	//timer for bursts
	private float m_burstTimer;

	//how many shots of the current burst have been fired
	private int m_currentBurstCount;

	//whether or not this enemy is currently firing
	private bool m_currentlyFiring;

	override protected void Fire()
	{
		m_currentlyFiring = true;
	}

	protected new void Update()
	{

		if(m_currentlyFiring)
		{
			m_burstTimer += Time.deltaTime;
			if (m_burstTimer >= m_burstDelay)
			{
				m_burstTimer = 0.0f;
				Vector3 lookPos = m_player.transform.position - m_bulletSource.position;
				Quaternion targetRotation = Quaternion.LookRotation(lookPos);
				Instantiate(m_bulletPrefab, m_bulletSource.position, targetRotation);
				m_currentBurstCount++;
			}
			if(m_currentBurstCount >= m_burstSize)
			{
				m_currentlyFiring = false;
				m_currentBurstCount = 0;
			}
		}
		else
		{
			base.Update();
		}
	}
}
