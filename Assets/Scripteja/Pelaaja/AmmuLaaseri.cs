using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmuLaaseri : MonoBehaviour {

	public GameObject Laaseri;

	void FixedUpdate () {
		if (Input.GetMouseButton(0)){
			float Kulma = transform.parent.rotation.eulerAngles.z;
			RaycastHit2D Sade = Physics2D.Raycast (transform.position, new Vector2(Mathf.Cos(Kulma * Mathf.Deg2Rad), Mathf.Sin(Kulma * Mathf.Deg2Rad)));
			Laaseri.transform.localScale = new Vector3 (Sade.distance, 1, 1);
		}
		else{
			Laaseri.transform.localScale = new Vector3 (0, 1, 1);
		}
	}
}
