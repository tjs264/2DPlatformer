using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public GameObject[] menu; // Assign in inspector
    public Button cont;
    public Button restart;
    public Button mainMenu;
    private bool isShowing;

    void Start() {
        isShowing = false;
        foreach (GameObject menu_part in menu) {
            menu_part.SetActive(isShowing);
        }

        cont.onClick.AddListener(HideMenu);
        restart.onClick.AddListener(RestartLevel);
        mainMenu.onClick.AddListener(GoToMain);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.Escape))
        {
            isShowing = !isShowing;
            foreach (GameObject menu_part in menu)
            {
                menu_part.SetActive(isShowing);
            }
        }
    }



    void HideMenu()
    {
        foreach (GameObject menu_part in menu)
            {
                menu_part.SetActive(false);
            }
    }

    void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GoToMain() {
        SceneManager.LoadScene(0);
    }
}
