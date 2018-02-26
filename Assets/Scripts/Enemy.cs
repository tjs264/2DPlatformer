using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Enemy : MonoBehaviour{

	public GameObject user;
	public float speed = 3;
	private UIEnemyHealth epanel;
	public int maxLives;
	public int lives;
	[Tooltip ("GameObject to be spawned when this instance dies.")]
	[SerializeField] GameObject deadPrefab = null;
	[Tooltip ("Duration of the blinking and stunning when hurt by an enemy.")]
	[SerializeField] float hurtTimer = 0.1f;
	EnemyStatus status;
	SpriteRenderer[] sr;
	Coroutine hurtRoutine;
	private Vector2 currentLocation;
	private Vector2 previousLocation;

	public enum EnemyStatus
	{
		Hurt,
		Active,
		InActive,
		Dead
	}

	void Start(){
		epanel = GameObject.FindObjectOfType<UIEnemyHealth> ();
		if (epanel == null) {
			Debug.LogError ("UIEnemyHealth component could not be found, add it to the UI");
		}
		epanel.UpdateSlider(maxLives, lives);
	
	}

	void Update(){
		if (user != null) {
			float distanceToTarget = Vector2.Distance (user.transform.position, transform.position);
			//Vector2 direction = (user.transform.position - transform.position).normalized;
			if (distanceToTarget <= 20) {
				if (user != null) {
					transform.position = Vector2.MoveTowards (transform.position, user.transform.position, Time.deltaTime * speed);
				}
			}
		}
	}

	void OnCollisionStay2D (Collision2D col)
	{
		if (col.collider.CompareTag ("Player")) {
			Player player = col.transform.root.GetComponentInChildren<Player> ();
			player.Hurt ();
		}
	}
	public void OnHit(){
		lives--;
		epanel.UpdateSlider (maxLives, lives);
		if (lives <= 0)
			Die ();
		hurtRoutine = StartCoroutine (HurtRoutine ());
	}
	IEnumerator HurtRoutine (){
		status = EnemyStatus.Hurt;
		float timer = 0;
		bool blink = false;
		while (timer < hurtTimer) {
			blink = !blink;
			timer += Time.deltaTime;
			if (blink) {
				foreach (SpriteRenderer rend in sr) {
					rend.color = Color.white;
				}
			} else {
				foreach (SpriteRenderer rend in sr) {
					rend.color = Color.red;
				}
			}
			yield return new WaitForSeconds (0.05f);
		}
		foreach (SpriteRenderer rend in sr) {
			rend.color = Color.white;
		}
		status = EnemyStatus.Active;
	}
		

	void Die (){
		Instantiate<GameObject> (deadPrefab, transform.position, transform.rotation);
		Destroy (gameObject);
	}

}

