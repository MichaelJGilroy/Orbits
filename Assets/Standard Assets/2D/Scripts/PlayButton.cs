using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {
    public bool clicked = false;
    public GameObject menu;
    public Transform rocketPrefab;
    //MenuManager mm;
    // Use this for initialization
    void Start () {
        //mm = GameObject.Find("MainCamera").GetComponent<MenuManager>();
        //public Transform bulletPrefab;
        Transform bullet = Instantiate(rocketPrefab) as Transform;
        Physics2D.IgnoreCollision(rocketPrefab.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
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
