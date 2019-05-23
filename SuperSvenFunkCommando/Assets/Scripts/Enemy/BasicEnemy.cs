using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : BaseEnemy
{
	override protected void Fire()
	{
		Vector3 lookPos = m_player.transform.position - m_bulletSource.position;
		Quaternion targetRotation = Quaternion.LookRotation(lookPos);
		Instantiate(m_bulletPrefab, m_bulletSource.position, targetRotation);
	}
}
