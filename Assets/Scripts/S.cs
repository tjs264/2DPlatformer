using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S : MonoBehaviour
{

    private bool hasGun = true;
    public GameObject bullet;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            if (hasGun)
            {
                Vector3 pos = transform.position;
                pos.y -= 0.1f;
                if (bullet.GetComponent<Proj>().flip == true)
                {
                    pos.x -= 0.5f;
                }
                else {
                    pos.x += 0.5f;
                }
                Instantiate(bullet, pos, Quaternion.identity);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GetComponent<SpriteRenderer>().flipX = true;
            bullet.GetComponent<Proj>().flip = true;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GetComponent<SpriteRenderer>().flipX = false;
            bullet.GetComponent<Proj>().flip = false;
        }
    }
}
