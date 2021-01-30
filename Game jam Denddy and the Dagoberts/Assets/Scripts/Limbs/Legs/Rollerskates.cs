using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rollerskates : Leg

{
    public Rigidbody2D player;
    private Vector3 target;
    public float dashSpeed;
    public float maxDashDist;

    Vector3 mousePos;
    Vector3 mouseDir;

    // Start is called before the first frame update
    void Start()
    {
        spd = 5;
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        mouseDir = mousePos - transform.position;
        
        Debug.DrawRay(transform.position, mouseDir, Color.green);

        if (Input.GetButtonDown("Jump"))
        {   
            Debug.Log("We goin");
            Dash(x, y);
        }

    }

    void Dash(float x, float y)
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 moveDirection = (transform.position - mousePos);
        moveDirection.z = 0;
        moveDirection.Normalize();

        //player.velocity = Vector2.zero;
        //moveDirection = new Vector2(mousePos.x, mousePos.y);

        player.AddForce(-moveDirection * dashSpeed);
        Debug.Log((-moveDirection * dashSpeed));
        //this.transform.position = Vector2.MoveTowards(transform.position, dir, maxDashDist);
        //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //mousePos.z = 0;
        //
        //target = (mousePos - this.transform.position).normalized;
        //player.AddForce(target * dashSpeed);
    }
}
