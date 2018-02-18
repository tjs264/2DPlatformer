using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour{
	public GameObject scientist;
	public float speed = 2;

	void Update(){
		if (scientist != null) {
			transform.position = Vector2.MoveTowards (transform.position, scientist.transform.position, Time.deltaTime * speed);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			Destroy (other.gameObject);
		}
	}

    public void OnHit() {
        Destroy(gameObject);
    }

}

