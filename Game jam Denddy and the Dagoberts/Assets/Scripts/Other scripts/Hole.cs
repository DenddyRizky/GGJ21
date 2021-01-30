using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    Torso torso;
    Stats stats;
    public int holeDamage;
    Vector2 playerPos;
    Vector2 resetPosition;
    public float resetOffset;
    bool fallen, reset;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        fallen = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        if (fallen)
            reset = true;
        else reset = false;     
    }

    private void FixedUpdate()
    {
        if (fallen)
        {
            player.transform.position = resetPosition;
            Debug.Log("RESET NOW");
            fallen = false;
            player.GetComponent<Movement>().fallen = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        torso = collision.gameObject.GetComponent<Torso>();
        stats = collision.gameObject.GetComponent<Stats>();

        if (collision.gameObject.name == "Player" && torso.currentTorso != torso.angelWings)
        {
            Vector2 dir = collision.transform.position - this.transform.position;
            dir.Normalize();

            player = GameObject.Find("Player");
            stats.hp -= holeDamage;
            resetPosition = (Vector2)player.transform.position + dir * resetOffset;
            fallen = true;
            player.GetComponent<Movement>().fallen = true;
            Debug.Log("Stored position" + resetPosition);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(resetPosition, 1);
        Debug.Log("HI");
    }

}