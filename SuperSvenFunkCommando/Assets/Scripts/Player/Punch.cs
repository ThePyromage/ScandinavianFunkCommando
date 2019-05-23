using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
	//whether or not the player can punch
	private bool m_canPunch;
	//whether or not the hitbox is active
	private bool m_punchActive;

	[Tooltip("How long between punches")]
	[SerializeField] private float m_punchCooldown;
	[Tooltip("How long a punch should deflect bullets for")]
	[SerializeField] private float m_punchActiveTime;

	//internal timer
	private float m_timer;

	[Tooltip("Punch hitbox")]
	[SerializeField] GameObject m_hitbox;
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetButtonDown("Fire1"))
		{
			if(m_canPunch)
			{
				m_hitbox.SetActive(true);
				m_canPunch = false;
				m_punchActive = true;
			}
		}
		if (m_canPunch == false)
		{
			m_timer += Time.deltaTime;
			if(m_timer >= m_punchActiveTime && m_punchActive)
			{
				m_hitbox.SetActive(false);
				m_punchActive = false;
			}
			else if(m_timer >= m_punchCooldown)
			{
				m_canPunch = true;
				m_timer = 0.0f;
			}
		}
	}
}
