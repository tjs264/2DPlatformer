﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent (typeof(SimpleNPCInputModule2D))]
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
		

	void OnCollisionStay2D(Collision2D col){
		if (col.collider.CompareTag ("Player")) {
			player.GetComponent<Player>().Die();
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