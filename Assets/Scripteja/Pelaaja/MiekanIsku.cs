using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiekanIsku : MonoBehaviour {

	public float Vahinko = 30f;
	bool Maassa;

	void Update(){
		if (transform.parent == null) {
			Maassa = true;
		} 
		else {
			Maassa = false;
		}
	}

	void OnTriggerEnter2D(Collider2D Vihollinen){
		Debug.Log (Vihollinen);
		if (Vihollinen.gameObject != transform.root.gameObject && Vihollinen.tag != "Kursori" && !Maassa){
			Vihollinen.gameObject.GetComponent<Elama> ().OtaVahinkoa (Vahinko);
			GetComponent<PolygonCollider2D> ().enabled = false;
			Vihollinen.gameObject.GetComponentInChildren<ParticleSystem> ().Play ();
		}
	}
}