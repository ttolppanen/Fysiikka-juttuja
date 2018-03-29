using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gobliini : MonoBehaviour {

	public float LyontiEtaisyys = 1f;
	public float MaksimiNopeus;
	public float Kiihtyvyys;
	public float HyppyVoima;
	bool Hyppy = false;
	GameObject Pelaaja;
	Rigidbody2D rb;
	Vector3 EtaisyysPelaajaan;

	void Awake () {
		Pelaaja = GameObject.FindGameObjectWithTag ("Pelaaja");
		rb = GetComponent<Rigidbody2D>();
	}

	void Update () {
		EtaisyysPelaajaan = Pelaaja.transform.position - transform.position;
		if (OllaankoMaassa ()) {
			Hyppy = false;
		} 
		/*if (EtaisyysPelaajaan.x > 0) {
			transform.localScale = new Vector3 (1, 1, 1);
		} 
		else {
			transform.localScale = new Vector3 (-1, 1, 1);
		}*/
	}
	void FixedUpdate(){
		if (EtaisyysPelaajaan.magnitude > LyontiEtaisyys){
			if (rb.velocity.magnitude < MaksimiNopeus){
				rb.AddForce (new Vector2(Kiihtyvyys * EtaisyysPelaajaan.x / Mathf.Abs(EtaisyysPelaajaan.x), 0));
				if (rb.velocity.magnitude <= 0.01f && !Hyppy && TarkistaSeina()){
					Hyppy = true;
					rb.AddForce (Vector2.up * HyppyVoima, ForceMode2D.Impulse);		
				}
			}
		}
		/*if (rb.velocity.magnitude < 0.1f && !Hyppy && TarkistaSeina() && EtaisyysPelaajaan.magnitude > 0.9f){
			Hyppy = true;
			rb.AddForce (Vector2.up * HyppyVoima, ForceMode2D.Impulse);		
		}*/
	}

	bool TarkistaSeina(){
		float EtaisyysSeinaan = 100f;
		for (int i = 0; i <= 2; i++) {
			if (Pelaaja.transform.position.x - transform.position.x >= 0) {
				if (Physics2D.Raycast (new Vector2 (transform.position.x + 0.15f, transform.position.y - 0.237f + i * 0.237f), Vector2.right).distance < EtaisyysSeinaan) {
					EtaisyysSeinaan = Physics2D.Raycast (new Vector2 (transform.position.x + 0.15f, transform.position.y - 0.237f + i * 0.237f), Vector2.right).distance;		
				}
			} 
			else {
				if (Mathf.Abs(Physics2D.Raycast (new Vector2 (transform.position.x - 0.035f, transform.position.y - 0.237f + i * 0.237f), Vector2.left).distance) < EtaisyysSeinaan) {
					EtaisyysSeinaan = Mathf.Abs(Physics2D.Raycast (new Vector2 (transform.position.x - 0.035f, transform.position.y - 0.237f + i * 0.237f), Vector2.left).distance);		
				}
			}
		}
		Debug.Log (EtaisyysSeinaan);
		if (Mathf.Abs(EtaisyysSeinaan) < 0.02f) {
			return true;
		} 
		else {
			return false;
		}
	}
	bool OllaankoMaassa(){
		/*float EtaisyysMaahan = 100f;
		for (int i = 0; i <= 2; i++) {
			if (){
				EtaisyysMaahan = Mathf.Abs (Physics2D.Raycast (new Vector2 (transform.position.x, transform.position.y - 0.25f), Vector2.right).distance)
			}
		}*/
		if (Mathf.Abs (Physics2D.Raycast (new Vector2 (transform.position.x, transform.position.y - 0.255f), Vector2.down).distance) < 0.1f) {
			return true;
		} 
		else {
			return false;
		}
	}
}