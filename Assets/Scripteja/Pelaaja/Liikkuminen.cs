using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liikkuminen : MonoBehaviour {

	public float XMaxNopeus = 10f;
	public GameObject Miekka;
	Animator Animaatio;
	Rigidbody2D rb;

	// Use this for initialization
	void Awake(){
		rb = GetComponent<Rigidbody2D> ();
		Animaatio = GetComponent<Animator> ();
	}
	
	void Update(){
		if (Input.GetKeyDown ("w")) {
			rb.AddForce (new Vector2 (0, 20f), ForceMode2D.Impulse);
		}
		if (rb.velocity.magnitude > 0.1f) {
			Animaatio.SetBool ("Juoksussa", true);
		} 
		else {
			Animaatio.SetBool ("Juoksussa", false);
		}
	}
	void FixedUpdate () {
		if (Input.GetKey ("d") && rb.velocity.x < XMaxNopeus) {
			rb.AddForce (new Vector2 (50f, 0));
			KaannaUkko ();
		}
		if (Input.GetKey ("a") && rb.velocity.x > -XMaxNopeus) {
			rb.AddForce (new Vector2 (-50f, 0));
			KaannaUkko ();
		}
	}
	void KaannaUkko(){
		if (rb.velocity.x >= 0.1f && transform.localScale.x < 0){
			transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		}
		if (rb.velocity.x < 0.1f && transform.localScale.x > 0){
			transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		}
	}
}