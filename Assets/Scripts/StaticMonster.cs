using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticMonster : MonoBehaviour
{
    public GameObject scientist;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
        }
    }

    public void OnHit()
    {
        Destroy(gameObject);
    }
}

