using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour{
	public float speed = 2;
	public float lifeTime = 3;
	public Vector3 direction;
  public bool flip = false;

	void Start(){
		// // normalize direction so it does not impact the travel speed
		// direction.Normalize ();
		// // make the projectile rotate into the direction it is moving, math will be addressed in lecture 2
		// float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
		// transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		// StartCoroutine (KillAfterSeconds (lifeTime));

		StartCoroutine (KillAfterSeconds (lifeTime));
		direction.Normalize ();
		Debug.Log(transform.position);
		Debug.Log(flip);

      if (flip) {
        GetComponent<SpriteRenderer>().flipX = true;
      }
	}

	void Update ()
	{
		// transform.position += new Vector3 (direction.x, direction.y, 0) * speed * Time.deltaTime;

    if (flip) {
        transform.position += new Vector3(-direction.x, direction.y, 0) * speed * Time.deltaTime;
    }
    else {
        transform.position += new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;
    }
    // Debug.Log(flip);
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

	public void SetFlip (bool newFlip)
	{
		this.flip = newFlip;
		Debug.Log(flip);
	}
}
