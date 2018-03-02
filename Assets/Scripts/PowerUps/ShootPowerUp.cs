using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootPowerUp : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Player") {
			Player.hasShootPower = true; 
			Destroy(gameObject);
		}
	}
}
