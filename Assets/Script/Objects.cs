using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D collid){
		if (collid.gameObject.tag == "Lose" || collid.gameObject.tag == "Play") {
			Destroy (gameObject);
		}
	}

	}