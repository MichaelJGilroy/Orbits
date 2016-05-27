using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {
    public bool clicked = false;
    public GameObject menu;
    //MenuManager mm;
    // Use this for initialization
    void Start () {
        //mm = GameObject.Find("MainCamera").GetComponent<MenuManager>();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
    void OnMouseDown()
    {
        transform.localScale *= 0.9F;
    }
    void OnMouseUp()
    {
        transform.localScale *= 1.111F;
        clicked = true;
        menu.SetActive(false);
    }
}
