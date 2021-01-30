using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovemtentScript : MonoBehaviour
{
    Rigidbody2D body;

    public float rotation;

    public Vector2 startPosition;
    public Vector2 waypoint;
    public Vector2 velocity;

    protected float runSpeed = 5f;
    protected float maxSteering = 10f;

    public float mag;

    public float timer;
    public float checkTime;
    // Start is called before the first frame update
    void Start()
    {
        rotation = 1;


        body = GetComponent<Rigidbody2D>();

        checkTime = 3;
        startPosition = body.position;
        waypoint.x = Random.Range(startPosition.x - 3, startPosition.x + 2);
        waypoint.y = Random.Range(startPosition.y - 3, startPosition.y + 2);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        NewWaypoint();
        var target = waypoint;

        var desiredVelocity = target - new Vector2(body.position.x, body.position.y);

        desiredVelocity = Truncate(desiredVelocity, runSpeed);
        desiredVelocity -= velocity;
        desiredVelocity = Truncate(desiredVelocity, maxSteering);
        desiredVelocity = desiredVelocity / body.mass;
        desiredVelocity = Truncate(desiredVelocity, runSpeed);

        body.velocity += desiredVelocity * Time.deltaTime;

        target.x = target.x - transform.position.x;
        target.y = target.y - transform.position.y;
        var angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        body.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));

        mag = (target - body.position).magnitude;
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
        if (mag < 0.5f && timer > checkTime)
        {
            if (transform.position.x > 0)
            {
                waypoint.x = Random.Range(startPosition.x - 5, startPosition.x - 2);
            }
            else if (transform.position.x <= 0)
            {
                waypoint.x = Random.Range(startPosition.x + 2, startPosition.x + 5);
            }

            if (transform.position.y > 0)
            {
                waypoint.y = Random.Range(startPosition.y - 5, startPosition.y - 2);
            }
            else if (transform.position.y <= 0)
            {
                waypoint.y = Random.Range(startPosition.y + 2, startPosition.y + 5);
            }
            timer = 0;
        }
    }
}
