using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(SimpleNPCInputModule2D))]
public class SnakeEnemy : MonoBehaviour {

	public int maxLives;
	public int lives;
	public GameObject user;

	[Tooltip ("GameObject to be spawned when this instance dies.")]
	[SerializeField] GameObject deadPrefab = null;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionStay2D(Collision2D other){
		if (other.collider.CompareTag ("Player")) {
			user.GetComponent<Player>().Die();
		}
	}

	public void Die (){
		Instantiate<GameObject> (deadPrefab, transform.position, transform.rotation);
		Destroy (gameObject);
	}

			
}
