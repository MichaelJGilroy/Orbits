using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    /*
     _______  _____  _______ . _______      _______  _____  _______  ______ _     _ _______ _______ _______ _____
    |  |  | |     | |  |  | ' |______      |______ |_____] |_____| |  ____ |_____| |______    |       |      |  
    |  |  | |_____| |  |  |   ______|      ______| |       |     | |_____| |     | |______    |       |    __|__
    
    */


    public Transform target;
    bool menuMode = true;
    float fuel = 100, maxfuel = 100;
    Rect fuelRect;
    Texture2D fuelTexture;
    Camera cam;

    PlayButton play;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(0.0f, 3.0f, 0.0f);
        fuelRect = new Rect(20, 40, 80, 20);
        fuelTexture = new Texture2D(1, 1);
        fuelTexture.SetPixel(0, 0, Color.red);
        fuelTexture.Apply();

        play = GameObject.Find("play").GetComponent<PlayButton>();
        cam = GameObject.Find("MainCamera").GetComponent<Camera>();
    }
    
    
    void Update ()
    {
        // when mouse is pressed and not in menu, get the distance & direction of click from rocket
        if (Input.GetMouseButton(0) && !menuMode && fuel >= 0.0f)
        {
            Vector2 mouseClick = new Vector2(Input.mousePosition.x - cam.WorldToScreenPoint(transform.position).x, Input.mousePosition.y - cam.WorldToScreenPoint(transform.position).y) * -1;
            print(Input.mousePosition);
            print(transform.position.x + ", " + transform.position.y);

            GetComponent<Rigidbody2D>().AddForce(mouseClick);

            // get direction of click and set rocket direction away from it
            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            //print(diff);
            diff.Normalize();
            //print(diff);

            // a^2 + b^2 = c^2 for distance
            float rot_z = Mathf.Atan2(-diff.y, -diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
            fuel -= 0.01f;
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

    void OnGUI()
    {
        if (!menuMode)
        {
            float ratio = fuel / maxfuel;
            float rectWidth = ratio * Screen.width / 3;
            fuelRect.width = rectWidth;
            GUI.DrawTexture(fuelRect, fuelTexture);
        }
        
    }
}
