using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPowerUp : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Player") {
			Player.hasJumpPower = true; 
			Destroy(gameObject);			
		}
	}
}