using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {

    // reference external scripts
    //MenuManager mm;
    PlayButton play;

    // Use this for initialization
    void Start () {
        //mm = GameObject.Find("MainCamera").GetComponent<MenuManager>();
        play = GameObject.Find("Canvas").GetComponentInChildren<PlayButton>();
    }


    public GameObject player;
    public float cameraHeight;

    // Update is called once per frame
    void Update () {
        // if play button unclicked, camera is not
        if (!play.clicked)
        {
            
        }
        // if it is clicked, use the camera focused on the rocket
        else
        {
            Vector3 pos = player.transform.position;
            pos.z += cameraHeight;
            transform.position = pos;
        }
        
    }
}
