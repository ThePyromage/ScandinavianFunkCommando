using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HueShift : MonoBehaviour
{
	[SerializeField] private float m_shiftSpeed;
	// Update is called once per frame
	void Update ()
	{
		Color meshColor = gameObject.GetComponent<MeshRenderer>().material.color;
		float hue;
		float sat;
		float val;
		Color.RGBToHSV(meshColor, out hue, out sat, out val);
		hue += m_shiftSpeed * Time.deltaTime;
		gameObject.GetComponent<MeshRenderer>().material.color = Color.HSVToRGB(hue, sat, val);
	}
}
