using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UkonTila : MonoBehaviour {

	public GameObject HPBar;
	GameObject AseVyotarolla;
	public bool OnkoAseKadessa;
	Slider HPSlider;
	float MaksimiHP;

	void Awake(){
		HPSlider = HPBar.GetComponent<Slider> ();
		MaksimiHP = GetComponent<Elama> ().MaxHP;
	}

	void Update () {
		if (transform.Find ("UkkoRuumis").transform.Find ("Tuppi").transform.GetChild (0).GetComponent<SpriteRenderer> ().enabled) {
			OnkoAseKadessa = false;
		} 
		else {
			OnkoAseKadessa = true;
		}
		HPSlider.value = GetComponent<Elama> ().HP / MaksimiHP;
	}
}