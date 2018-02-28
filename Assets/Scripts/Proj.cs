using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proj : MonoBehaviour
{
    public float speed = 2;
    public float lifeTime = 3;
    public Vector2 direction = new Vector2(1, 0);
    public bool flip = false;


    void Start()
    {

        Debug.Log("start");
        StartCoroutine(KillAfterSeconds(lifeTime));
        direction.Normalize();
        if (flip)
        {
            Debug.Log("SDFSDFSDFSDFSDFSDF");
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0f);
        }
        else if (!flip)
        {
            Debug.Log("LLLLLLLLLLL");
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0f);
        }


    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {


    }

    IEnumerator KillAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}