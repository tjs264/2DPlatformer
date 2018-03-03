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

	public enum EnemyStatus
	{
		Hurt,
		Active,
		InActive,
		Dead
	}

	void Start()
	{
		epanel = GameObject.FindObjectOfType<UIEnemyHealth> ();
		if (epanel == null) {
			Debug.LogError ("UIEnemyHealth component could not be found, add it to the UI");
		}
		epanel.UpdateSlider(maxLives, lives);
		sr = GetComponentsInChildren<SpriteRenderer> ();
		status = EnemyStatus.Active;
	}

	void Update()
	{
		if (user != null) {
			transform.position = Vector2.MoveTowards (transform.position, user.transform.position, Time.deltaTime * speed);
		}
	}

	void OnCollisionStay2D (Collision2D other)
	{
		if (other.collider.CompareTag ("Player")) {
			user.GetComponent<Player> ().Die ();
		}
	}

	public void OnHit()
	{
		if (status != EnemyStatus.Active) {
			return;
		}

		lives--;
		epanel.UpdateSlider (maxLives, lives);
		if (lives <= 0) {
			Die ();
		}

		if (hurtRoutine != null) {
			StopCoroutine (hurtRoutine);
		}
		hurtRoutine = StartCoroutine (HurtRoutine ());
	}

	IEnumerator HurtRoutine ()
	{
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


	void Die ()
	{
		Instantiate<GameObject> (deadPrefab, transform.position, transform.rotation);
		Destroy (gameObject);
	}

}
