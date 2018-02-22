using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    private bool hasGun = true;
    public GameObject bullet;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            if (hasGun)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GetComponent<SpriteRenderer>().flipX = true;
            bullet.GetComponent<Projectile>().direction = new Vector2(-1, 0);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GetComponent<SpriteRenderer>().flipX = false;
            bullet.GetComponent<Projectile>().direction = new Vector2(1, 0);
        }
    }
}
