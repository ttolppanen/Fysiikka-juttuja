using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtaAse : MonoBehaviour {

	public GameObject Nyrkki;
	public GameObject Tuppi;
	public GameObject Ukko;
	public float NostoEtaisyys;
	GameObject Ase;
	GameObject AseKadessa;
	GameObject AseVyotarolla;

	void Awake () {
		AseKadessa = Nyrkki.transform.GetChild (0).gameObject;
		AseVyotarolla = Tuppi.transform.GetChild (0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(1) && Ase != null){
			GameObject AseMaassa = Instantiate (AseKadessa, Ukko.transform.position + Vector3.right, Quaternion.identity);
			Rigidbody2D AseMaassaRB = AseMaassa.GetComponent<Rigidbody2D> ();
			AseMaassaRB.bodyType = RigidbodyType2D.Dynamic;
			AseMaassaRB.AddForceAtPosition (Vector2.right, AseMaassa.transform.position + new Vector3(0, 0.2f, 0));
			AseMaassa.GetComponent<PolygonCollider2D> ().enabled = true;
			AseMaassa.GetComponent<PolygonCollider2D> ().isTrigger = false;
			AseMaassa.GetComponent<SpriteRenderer> ().enabled = true;
			Destroy (AseKadessa);
			Destroy (AseVyotarolla);
			Ase.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Kinematic;
			AseKadessa = Instantiate (Ase, Nyrkki.transform);
			AseVyotarolla = Instantiate (Ase, Tuppi.transform);
			AseKadessa.transform.localPosition = Vector3.zero;
			AseVyotarolla.transform.localPosition = Vector3.zero;
			AseKadessa.transform.localRotation = Quaternion.Euler (Vector3.zero);
			AseVyotarolla.transform.localRotation = Quaternion.Euler (Vector3.zero);
			AseKadessa.GetComponent<PolygonCollider2D> ().isTrigger = true;
			AseKadessa.GetComponent<PolygonCollider2D> ().enabled = false;
			AseVyotarolla.GetComponent<PolygonCollider2D> ().enabled = false;
			if (Ukko.GetComponent<UkonTila> ().OnkoAseKadessa) {
				AseKadessa.GetComponent<SpriteRenderer> ().enabled = true;
				AseVyotarolla.GetComponent<SpriteRenderer> ().enabled = false;
			} 
			else {
				AseKadessa.GetComponent<SpriteRenderer> ().enabled = false;
				AseVyotarolla.GetComponent<SpriteRenderer> ().enabled = true;
			}
			Destroy (Ase);
		}
	}
	void OnTriggerEnter2D(Collider2D TormausEsine){
		if (TormausEsine.tag == "Ase" && (TormausEsine.gameObject.transform.position - Ukko.transform.position).magnitude < NostoEtaisyys) {
			Ase = TormausEsine.gameObject;
		}
	}
	void OnTriggerLeave2D(Collider2D TormausEsine){
		Ase = null;
	}
}