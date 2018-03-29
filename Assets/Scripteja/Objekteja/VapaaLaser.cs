using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VapaaLaser : MonoBehaviour {

	void Update () {
		float Kulma = transform.rotation.eulerAngles.z;
		RaycastHit2D Sade = Physics2D.Raycast (transform.position, new Vector2(Mathf.Cos(Kulma * Mathf.Deg2Rad), Mathf.Sin(Kulma * Mathf.Deg2Rad)));
		transform.localScale = new Vector3 (Sade.distance, 1, 1);
	}
}
