using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaannaOsoitinta : MonoBehaviour {


	void Update () {
		Vector3 Suunta = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		float Kulma = Mathf.Atan2 (Suunta.y, Suunta.x);
		transform.rotation = Quaternion.Euler (0, 0, Mathf.Rad2Deg * Kulma);
	}
}
