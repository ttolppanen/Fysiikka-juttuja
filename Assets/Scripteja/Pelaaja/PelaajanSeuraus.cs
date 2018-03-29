using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelaajanSeuraus : MonoBehaviour {

	public GameObject Ukko;
	public float XSiirto;
	public float YSiirto;
	
	
	void Update () {
		transform.position = new Vector3 (Ukko.transform.position.x + XSiirto, Ukko.transform.position.y + YSiirto, -10);
	}
}
