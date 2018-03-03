using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Goal : MonoBehaviour {
	public static bool foundKey;
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			if (Player.foundKey) {
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			}
		}
	}
}
