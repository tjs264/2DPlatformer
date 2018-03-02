using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Player script. Manages the health and interaction with enemies of the player.
/// </summary>
[RequireComponent (typeof(PlatformerController2D))]
public class Player : MonoBehaviour
{
	public enum PlayerStatus
	{
		Hurt,
		Active,
		InActive,
		Shrunk,
		Giant,
		Dead
	}

	[Tooltip ("Number of lifes of the player.")]
	[SerializeField] int hitPoints = 5;
	[Tooltip ("Duration of the blinking and stunning when hurt by an enemy.")]
	[SerializeField] float hurtTimer = 0.1f;
	[Tooltip ("Object to be spawned on death.")]
	[SerializeField] GameObject deadPrefab = null;

	PlatformerController2D controller;
	SpriteRenderer[] sr;
	PlayerStatus status;
	Coroutine hurtRoutine;
	public static bool hasJumpPower = true;
	public static bool hasShootPower = false;
	Vector2 temp;
    bool flip = true;

	void Awake ()
	{
		controller = GetComponent<PlatformerController2D> ();
		sr = GetComponentsInChildren<SpriteRenderer> ();
		status = PlayerStatus.Active;
	}

	/// <summary>
	/// Makes the player jump upwards by force.
	/// </summary>
	/// <param name="force">Strength of upwards push.</param>
	public void ForceJump (float force)
	{
			controller.ForceJump (force);
	}

    /// <summary>
    /// Hurt the Player. The player will lose one hitpoint and is invulnerable for hurtTimer time.
    /// </summary>
    public void Hurt ()
	{
		if (status != PlayerStatus.Active) {
			return;
		}

		hitPoints--;
		Debug.Log ("HIT");
		UIManager.SetLifes (hitPoints);
		if (hitPoints <= 0) {
			Die ();
			return;
		}
		if (hurtRoutine != null) {
			StopCoroutine (hurtRoutine);
		}
		hurtRoutine = StartCoroutine (HurtRoutine ());
	}

	IEnumerator HurtRoutine ()
	{
		status = PlayerStatus.Hurt;
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
		status = PlayerStatus.Active;
	}

	IEnumerator SizeUp ()
	{
		status = PlayerStatus.Giant;
		temp = transform.localScale;
		temp.x += 1f;
		temp.y += 1f;
		transform.localScale = temp;

		yield return new WaitForSeconds(25f);
		temp.x -= 1f;
		temp.y -= 1f;
		transform.localScale = temp;
		status = PlayerStatus.Active;
	}

	IEnumerator Shrink ()
	{
		status = PlayerStatus.Shrunk;
		temp = transform.localScale;
		temp.x -= .5f;
		temp.y -= .5f;
		transform.localScale = temp;

		yield return new WaitForSeconds(20f);
		temp.x += .5f;
		temp.y += .5f;
		transform.localScale = temp;
		status = PlayerStatus.Active;
	}

	/// <summary>
	/// Destroy the player and spawn the death animation.
	/// </summary>
	public void Die ()
	{
        StartCoroutine(DieCoRout());
	}

    private IEnumerator DieCoRout()
    {
        GameObject dead = Instantiate<GameObject>(deadPrefab, transform.position, transform.rotation);
        dead.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,12f);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "SizeUp") {
			if(status != PlayerStatus.Shrunk) {
				StartCoroutine(SizeUp());
				Destroy(other);
			}

		}
		if(other.tag == "Shrink") {
			if(status != PlayerStatus.Giant){
				StartCoroutine(Shrink());
				Destroy(other);
			}
		}
		if(status == PlayerStatus.Giant){

			Destroy(other);
		}

	}

}
