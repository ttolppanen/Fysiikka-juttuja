using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsineidenNosto : MonoBehaviour {

	// Scripti kiinni kursorissa!!!

	public float NopeusMaksimi = 10f;
	public float NostoVoima = 100f;
	public float NostoEtaisyys;
	public GameObject Ukko;
	GameObject Esine;
	Rigidbody2D rb;
	Vector3 EsineestaKursoriin; //Nämä kiinniotto pistettä varten
	float SuuntaKulma;
	float SuuntaPituus;

	void Update(){
		if (Esine != null) {
			if (Input.GetMouseButtonUp (0) || (Esine.transform.position - Ukko.transform.position).magnitude >= NostoEtaisyys) {
				EsineestaKursoriin = Vector3.zero;
				rb.drag = 0.1f;
				rb.angularDrag = 0.05f;
				Esine = null;

			}
			if (Input.GetMouseButtonDown(0)){
				/*EsineestaKursoriin = Quaternion.Inverse(Esine.transform.rotation) * (transform.position - Esine.transform.position);
				Debug.Log ("HEYYYYYY YA " + EsineestaKursoriin);*/
				EsineestaKursoriin = transform.position - Esine.transform.position;
				SuuntaKulma = Mathf.Atan2 (EsineestaKursoriin.y, EsineestaKursoriin.x) - Esine.transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
				SuuntaPituus = EsineestaKursoriin.magnitude;
			}
		}
	}

	void FixedUpdate () {
		if (Esine != null){
			rb = Esine.GetComponent<Rigidbody2D> ();
			if (Input.GetMouseButton (0) && (Esine.transform.position - Ukko.transform.position).magnitude < NostoEtaisyys) {
				float OikeaSuuntaKulma = SuuntaKulma + Esine.transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
				Vector3 Suunta = transform.position - (new Vector3(Mathf.Cos(OikeaSuuntaKulma) * SuuntaPituus, Mathf.Sin(OikeaSuuntaKulma) * SuuntaPituus, 0) + Esine.transform.position);
				Vector3 EtaisuusUkkoon = Esine.transform.position - Ukko.transform.position;
				/*Vector3 Suunta = transform.position - Esine.transform.position - Esine.transform.rotation * EsineestaKursoriin;*/
				rb.drag = 2f;
				rb.angularDrag = 2f;
				rb.AddForceAtPosition (Suunta * NostoVoima * 1 / Mathf.Pow((EtaisuusUkkoon.magnitude + 0.5f), 2f), new Vector3(Mathf.Cos(OikeaSuuntaKulma) * SuuntaPituus, Mathf.Sin(OikeaSuuntaKulma) * SuuntaPituus, 0) + Esine.transform.position);
			} 
		}
	}
	void OnTriggerEnter2D(Collider2D TormausEsine){
		if (TormausEsine.tag == "Esine" || TormausEsine.tag == "Ase" && !Input.GetMouseButton(0) && (TormausEsine.gameObject.transform.position - Ukko.transform.position).magnitude < NostoEtaisyys) {
			Esine = TormausEsine.gameObject;
		}
	}
}