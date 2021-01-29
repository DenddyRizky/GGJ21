using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerScript : MonoBehaviour
{
    public List<string> libs;
    Rigidbody2D body;
    public int bodyPartCount;

    public Vector3 startPosition;

    public float runSpeed = 20.0f;
    public float attackRange;
    public bool attackMode = false;

    public Vector2 waypoint;
    Vector2 velocity;

    public float mag;

    public float timer;
    public float checkTime;


    public List<GameObject> partList;

    public List<Sprite> spriteList;

    public List<Vector3> positionList;

    // Start is called before the first frame update
    void Start()
    {
        libs = new List<string>();
        
        body = GetComponent<Rigidbody2D>();

        checkTime = 3;

        for (int i = 0; i < bodyPartCount; i++)
        {
            partList.Add(new GameObject());
            partList[i].transform.parent = gameObject.transform;
            partList[i].transform.position = positionList[i];
            SpriteRenderer renderer = partList[i].AddComponent<SpriteRenderer>();
            renderer.sprite = spriteList[i];
        }
        startPosition = transform.position;
        waypoint.x = Random.Range(startPosition.x - 3, startPosition.x + 2);
        waypoint.y = Random.Range(startPosition.y - 3, startPosition.y + 2);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Movement(transform.position);
     
        body.velocity = new Vector2(velocity.x , velocity.y) * runSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            attackMode = true;
        }
    }

    private void Movement(Vector3 playerLocation)
    {
        var target = waypoint;

        

        velocity = Vector2.Lerp(playerLocation, target, 1);

        mag = target.magnitude - playerLocation.magnitude;
        //mag = Mathf.Abs(mag);
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
