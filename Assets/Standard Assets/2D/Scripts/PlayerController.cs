using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Transform target;
    bool menuMode = true;

    PlayButton play;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(0.0f, 3.0f, 0.0f);

        play = GameObject.Find("Canvas").GetComponentInChildren<PlayButton>();
    }
    
    
    void Update ()
    {
        // when mouse is pressed and not in menu, get the distance & direction of click from rocket
        if (Input.GetMouseButton(0) && !menuMode)
        {
            Vector2 mouseClick = new Vector2(Input.mousePosition.x - 485.0f, Input.mousePosition.y - 165.0f) * -1;

            GetComponent<Rigidbody2D>().AddForce(mouseClick);

            // get direction of click and set rocket direction away from it
            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            diff.Normalize();

            // a^2 + b^2 = c^2 for distance
            float rot_z = Mathf.Atan2(-diff.y, -diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }
        // when mouse not pressed, calculate where rocket should be pointing
        else
        {
            Vector3 moveDirection = gameObject.transform.position;
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            if (play.clicked)
            {
                menuMode = false;
            }
        }
    }
}
