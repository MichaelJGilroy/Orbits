using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    Rigidbody2D rb;
    public Transform target;
    private float atan2;
    Vector3 velo;
    private int travelSpeed;
    bool rotateToTarget;
    bool travelToTarget;
    Vector3 target2;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(0.0f, 3.0f, 0.0f);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector3 velo = rb.velocity;
    }
    
    
    void Update ()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mouseClick = new Vector2(Input.mousePosition.x - 485.0f, Input.mousePosition.y - 165.0f) * -1;
            int speed = (int)(Input.mousePosition.x + Input.mousePosition.y)^2;
            //GetComponent<Rigidbody2D>().LookAt();
            print(mouseClick);
            print(speed);
            GetComponent<Rigidbody2D>().AddForce(mouseClick);

            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(-diff.y, -diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }
        else
        {
            Vector3 moveDirection = gameObject.transform.position;
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            Vector2 direction = (target.transform.position - GetComponent<Rigidbody2D>().transform.position).normalized;
        }
    }
}
