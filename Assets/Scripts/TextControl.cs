using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour {

    public string[] text = {
        "You've gained the abiity to jump!",
        "Press spacebar to jump"
    };

    private int i;

    public GameObject UIText;
    private Text t;


	// Use this for initialization
	void Start () {
        t = UIText.GetComponent<Text>();
        t.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            i += 1;
            if (i >= text.Length) { i = 0; }
            t.text = text[i];
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        t.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        t.enabled = false;
    }
}
