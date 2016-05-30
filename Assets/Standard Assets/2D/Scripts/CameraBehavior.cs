using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {

    // reference external scripts
    //MenuManager mm;
    PlayButton play;

    // Use this for initialization
    void Start () {
        //mm = GameObject.Find("MainCamera").GetComponent<MenuManager>();
        play = GameObject.Find("play").GetComponent<PlayButton>();
    }


    public GameObject player;
    public float cameraHeight;

    // Update is called once per frame
    void Update () {
        // if play button unclicked, camera is not locked on rocket
        if (!play.clicked)
        {
            
        }
        else
        {
            // lock camera to rocket
            Vector3 pos = player.transform.position;
            pos.z += cameraHeight;
            transform.position = pos;
        }
        
    }
}
