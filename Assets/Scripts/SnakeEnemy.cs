using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(SimpleNPCInputModule2D))]
public class SnakeEnemy : MonoBehaviour {

	public int maxLives;
	public int lives;

	[Tooltip ("GameObject to be spawned when this instance dies.")]
	[SerializeField] GameObject deadPrefab = null;

//	[SerializeField] float hurtTimer = 0.1f;
//	EnemyStatus status;
//	SpriteRenderer[] sr;
//	Coroutine hurtRoutine;
//
//	public enum EnemyStatus
//	{
//		Hurt,
//		Active,
//		InActive,
//		Dead
//	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionStay2D(Collision2D col){
		if (col.collider.CompareTag ("Player")) {
			Player player = col.transform.root.GetComponentInChildren<Player> ();
			player.Hurt ();
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(30f, 30f));

		}
	}

//	public void OnHit(){
//		if (status != EnemyStatus.Active) {
//			return;
//		}
//
//		lives--;
//		if (lives <= 0)
//			Die ();
//		if (hurtRoutine != null) {
//			StopCoroutine (HurtRoutine ());
//		}
//		hurtRoutine = StartCoroutine (HurtRoutine ());
//	}
//
//	IEnumerator HurtRoutine(){
//		status = EnemyStatus.Hurt;
//		float timer = 0;
//		bool blink = false;
//		while (timer < hurtTimer) {
//			blink = !blink;
//			timer += Time.deltaTime;
//			if (blink) {
//				foreach (SpriteRenderer rend in sr) {
//					rend.color = Color.white;
//				}
//			} else {
//				foreach (SpriteRenderer rend in sr) {
//					rend.color = Color.red;
//				}
//			}
//			yield return new WaitForSeconds (0.05f);
//		}
//		foreach (SpriteRenderer rend in sr) {
//			rend.color = Color.white;
//		}
//		status = EnemyStatus.Active;
//	}
//

	public void Die (){
		Instantiate<GameObject> (deadPrefab, transform.position, transform.rotation);
		Destroy (gameObject);
	}

			
}
