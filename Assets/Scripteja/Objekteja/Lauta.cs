using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lauta : MonoBehaviour {

	Vector3 Alkupiste;

	void Start () {
		Alkupiste = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = Alkupiste;
	}
}
