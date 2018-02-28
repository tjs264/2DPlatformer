using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour{
	public float speed = 2;
	public float lifeTime = 3;
	public Vector2 direction = new Vector2(1,0);
    public bool flip = false;

	void Start(){
		StartCoroutine (KillAfterSeconds (lifeTime));
		direction.Normalize ();
        if (flip) {
            GetComponent<SpriteRenderer>().flipX = true;
        }
	}

	void Update ()
	{
        if (flip) {
            transform.position += new Vector3(-direction.x, direction.y, 0) * speed * Time.deltaTime;
        }
        else {
            transform.position += new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;
        }
        Debug.Log(transform.position);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Enemy")) {
			Enemy enemy = other.GetComponent<Enemy> ();
			enemy.OnHit ();
		}
		if(other.CompareTag("SnakeEnemy")){
			Destroy (other);
		}

	}

    IEnumerator KillAfterSeconds (float seconds)
	{
		yield return new WaitForSeconds (seconds);
		Destroy (gameObject);
	}
}
