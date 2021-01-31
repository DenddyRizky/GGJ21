using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovemtentScript : MonoBehaviour
{
    Rigidbody2D body;

    public float rotation;

    public Vector2 playerPosition;
    public Vector2 startPosition;
    public Vector2 waypoint;
    public Vector2 velocity;

    protected float runSpeed = 5f;
    protected float maxSteering = 10f;

    public float mag;
    public float timer;
    public float checkTime;
    public float maxTime;

    public bool playerInRange;
    // Start is called before the first frame update
    //when player is in range, determinded by big circle collider, switch from random waypoints around me, to random waypoints around player. turn off waypoints, perform dash and return to wyapoints
    void Start()
    {
        playerInRange = false;

        rotation = 1;

        body = GetComponent<Rigidbody2D>();

        checkTime = 3;
        maxTime = 10;
        startPosition = body.position;        

        waypoint.x = Random.Range(startPosition.x - 3, startPosition.x + 2);
        waypoint.y = Random.Range(startPosition.y - 3, startPosition.y + 2);

    }

    private void Update()
    {
        timer += Time.deltaTime;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        NewWaypoint();
        var target = waypoint;

        var desiredVelocity = target - new Vector2(body.position.x, body.position.y);

        Debug.DrawRay(body.position, desiredVelocity);

        desiredVelocity.Normalize();

        //desiredVelocity = Truncate(desiredVelocity, runSpeed);
        //desiredVelocity -= velocity;
        //desiredVelocity = Truncate(desiredVelocity, maxSteering);
        //desiredVelocity = desiredVelocity / body.mass;
        //desiredVelocity = Truncate(desiredVelocity, runSpeed);

        body.velocity += desiredVelocity * Time.deltaTime;

        target.x = target.x - transform.position.x;
        target.y = target.y - transform.position.y;
        var angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;

        if (playerInRange)
        {
            angle = Mathf.Atan2(startPosition.y, startPosition.x) * Mathf.Rad2Deg;
        }

        body.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));

        mag = (target - body.position).magnitude;
        Debug.Log(mag);
    }
    protected virtual Vector2 Truncate(Vector2 vector, float length)
    {
        if (vector.sqrMagnitude > length * length)
        {
            vector.Normalize(); vector *= length;
        }
        return vector;
    }
    protected virtual void NewWaypoint()
    {
        if (mag < 1f && timer > checkTime || timer > maxTime)
        {
            if (transform.position.x > 0)
            {
                waypoint.x = Random.Range(startPosition.x - 3, startPosition.x - 2);
            }
            else if (transform.position.x <= 0)
            {
                waypoint.x = Random.Range(startPosition.x + 2, startPosition.x + 3);
            }

            if (transform.position.y > 0)
            {
                waypoint.y = Random.Range(startPosition.y - 3, startPosition.y - 2);
            }
            else if (transform.position.y <= 0)
            {
                waypoint.y = Random.Range(startPosition.y + 2, startPosition.y + 3);
            }
            timer = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            //Debug.Log("I have spotted the playa");
            playerInRange = true;
            playerPosition = GameObject.Find("Player").GetComponent<Rigidbody2D>().transform.position;
            startPosition = playerPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            timer = maxTime;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            playerInRange = false;
            startPosition = body.position;
        }
    }
}
