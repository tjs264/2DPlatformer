using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour{
	public float speed = 2;
	public float lifeTime = 3;
	public Vector2 direction = new Vector2(1,0);

	void Start(){
		StartCoroutine (KillAfterSeconds (lifeTime));
		direction.Normalize ();
	}

	void Update ()
	{
		transform.position += new Vector3 (direction.x, direction.y, 0) * speed * Time.deltaTime;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Enemy")) { 
			Enemy enemy = other.GetComponent<Enemy>();
            enemy.OnHit();
			Destroy (gameObject); //destroy the projectile
		}

	}

    IEnumerator KillAfterSeconds (float seconds)
	{
		yield return new WaitForSeconds (seconds);
		Destroy (gameObject);
	}
}
