using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lyominen : MonoBehaviour {

	Animator Animaatio;
	public GameObject Tuppi;
	public GameObject Nyrkki;
	public GameObject OikeaKasi;

	void Start() {
		Animaatio = GetComponent<Animator> ();
	}
	void Update () {
		if (Input.GetMouseButtonDown(0) && !Animaatio.GetBool ("Lyonti") && Nyrkki.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled){
			Animaatio.SetBool("Lyonti", true);
		}
		if (Input.GetKeyDown ("g")) {
			Animaatio.SetTrigger ("VedaMiekka");
		}
		if (Animaatio.GetBool ("Lyonti")){
			Vector3 SuuntaPelaajaan;
			SuuntaPelaajaan = Camera.main.ScreenToWorldPoint(Input.mousePosition) - OikeaKasi.transform.position;
			if (transform.localScale.x > 0) {
				OikeaKasi.transform.rotation = Quaternion.Euler (0, 0, Mathf.Atan2 (SuuntaPelaajaan.y, SuuntaPelaajaan.x) * Mathf.Rad2Deg);
			}
			else {
				OikeaKasi.transform.rotation = Quaternion.Euler (0, 0, Mathf.Atan2 (-SuuntaPelaajaan.y, -SuuntaPelaajaan.x) * Mathf.Rad2Deg);
			}
		}
	}
	void VaihdaMiekat(){
		Tuppi.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
		Nyrkki.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
	}
	void SammutaMiekanIsku(){
		Nyrkki.transform.GetChild(0).GetComponent<PolygonCollider2D>().enabled = false;
		Animaatio.SetBool("Lyonti", false);
	}
	void KaynnistaMiekanIsku(){
		Nyrkki.transform.GetChild(0).GetComponent<PolygonCollider2D>().enabled = true;
	}
	void PalautaKasi(){
		OikeaKasi.transform.rotation = Quaternion.Euler (0, 0, 0);
	}
}