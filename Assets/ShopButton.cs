using UnityEngine;
using System.Collections;

public class ShopButton : MonoBehaviour {
    //public bool clicked = false;

    // Use this for initialization
    void Start () {
	
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
        //clicked = true;
    }
}
