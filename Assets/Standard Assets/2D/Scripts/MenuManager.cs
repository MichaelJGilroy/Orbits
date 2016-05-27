using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
    public bool menuMode = true;
    PlayButton play;

    //public Canvas MainMenuCanvas= GameObject.Find("Canvas").GetComponent<Canvas>();
    public GameObject MainMenuCanvas = GameObject.Find("Canvas");

    // Use this for initialization
    void Start () {
        play = GameObject.Find("Canvas").GetComponentInChildren<PlayButton>();
    }

    
    // Update is called once per frame
    void Update () {
        if (menuMode)
        {
            if (play.clicked)
            {
                menuMode = false;
                MainMenuCanvas.SetActive(false);
            }

        }
	}
}
