using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    public GameObject player;
    public float cameraHeight;
    // Update is called once per frame
    void Update () {
        Vector3 pos = player.transform.position;
        pos.z += cameraHeight;
        transform.position = pos;
    }
}
