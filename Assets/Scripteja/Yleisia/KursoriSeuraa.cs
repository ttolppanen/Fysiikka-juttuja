using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KursoriSeuraa : MonoBehaviour {

	void Awake(){
		Cursor.visible = false;
	}

	void Update () {

		Vector3 input = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		input.z = 0;
		transform.position = input;
	}
}
