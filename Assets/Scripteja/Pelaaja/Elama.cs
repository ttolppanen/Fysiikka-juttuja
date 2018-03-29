using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elama : MonoBehaviour {

	public float MaxHP = 100f;
	public float HP;

	void Awake (){
		HP = MaxHP;
	}

	void Update () {
		if (HP < 0f){
			Destroy (gameObject);
		}
	}
	public void OtaVahinkoa(float Vahinko){
		HP -= Vahinko;
	}
}