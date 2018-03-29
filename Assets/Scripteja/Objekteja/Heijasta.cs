using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heijasta : MonoBehaviour {

	public GameObject Laaseri;
	public GameObject SuuntaVektori;
	GameObject CheckLaaseri;
	public float IrtiPinnasta = 0.3f;
	bool OsuukoLaser = false;

	void Update(){
		if (CheckLaaseri != null) {
			if (CheckLaaseri.transform.localScale.x == 0) {
				Laaseri.transform.localScale = new Vector3 (0, 0, 0);
			}
		}
	}
	void OnCollisionStay2D (Collision2D TulevaLaaseri){
		Debug.Log ("joojoo");
		OsuukoLaser = true;
		Vector3 Suunta = TulevaLaaseri.transform.position;
		Vector3 PinnanSuunta = SuuntaVektori.transform.position - transform.position;
		Laaseri.transform.position = TulevaLaaseri.contacts [0].point;
		Laaseri.transform.rotation = Quaternion.Euler (0, 0, 2 * (transform.rotation.eulerAngles.z - 90) - TulevaLaaseri.transform.rotation.eulerAngles.z);
		RaycastHit2D Sade = Physics2D.Raycast (TulevaLaaseri.contacts [0].point, new Vector2 (Mathf.Cos (Laaseri.transform.rotation.eulerAngles.z * Mathf.Deg2Rad), Mathf.Sin (Laaseri.transform.rotation.eulerAngles.z * Mathf.Deg2Rad)));
		Laaseri.transform.localScale = new Vector3 (Sade.distance, 1, 1);
		CheckLaaseri = TulevaLaaseri.gameObject;
	}
	void OnCollisionEnter2D(Collision2D coll){
		OsuukoLaser = true;
	}
	void OnCollisionLeave2D(Collision2D coll){
		OsuukoLaser = false;
	}
}