using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            player.GetComponent<SpriteRenderer>().color = Color.red;
            Debug.Log("COLORCHANGE");
        }
    }
}
