using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInfo : MonoBehaviour {

    public GameObject info;
    public string displayText;
    private Image i;
    private Text t;

	// Use this for initialization
	void Start () {
        i = info.GetComponentInChildren<Image>();
        t = info.GetComponentInChildren<Text>();
        i.enabled = false;
        t.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        t.text = displayText;
        i.enabled = true;
        t.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        i.enabled = false;
        t.enabled = false;
    }
}
