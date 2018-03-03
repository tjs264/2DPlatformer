using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatEnemy : MonoBehaviour {

	public GameObject player;
	[Tooltip ("GameObject to be spawned when this instance dies.")]
	[SerializeField] GameObject deadPrefab = null;

	public bool moveRight = true;
	Rigidbody2D enemyRigidBody2D;
	public int UnitsToMove = 5;
	public float EnemySpeed = 5;
	public bool isFacingRight;
	private float startPos;
	private float endPos;
	Player user;

	void OnCollisionStay2D(Collision2D col){
		if (col.collider.CompareTag ("Player")) {
			user = col.collider.GetComponent<Player>();
			if (user.status != Player.PlayerStatus.Giant) {
				player.GetComponent<Player>().Die();
			} else {
				Die();
			}
		}
	}

	public void OnHit(){
		if (gameObject != null) {
			Die ();
		}
	}

	public void Die (){
		Instantiate<GameObject> (deadPrefab, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
