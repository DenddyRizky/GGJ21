using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    Torso torso;
    Stats stats;
    public int holeDamage;
    Vector3 playerPos;
    Vector3 resetPosition;
    public float resetOffsetx, resetOffsety;
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

        if(playerPos.y > this.transform.position.y)
        {
            resetOffsety = resetOffsety;
        }else if(playerPos.y < this.transform.position.y)
        {
            resetOffsety = -resetOffsety;
        }

        if(playerPos.x > this.transform.position.y)
        {
            resetOffsetx = resetOffsetx;
        }else if(playerPos.x < this.transform.position.x)
        {
            resetOffsetx = -resetOffsetx;
        }
        
    }

    private void FixedUpdate()
    {
        if (fallen)
        {
            player.transform.position = resetPosition;
            fallen = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        torso = collision.gameObject.GetComponent<Torso>();
        stats = collision.gameObject.GetComponent<Stats>();

        if (collision.gameObject.name == "Player" && torso.currentTorso != torso.angelWings)
        {
            player = GameObject.Find("Player");
            stats.hp -= holeDamage;
            resetPosition = player.transform.position + new Vector3(resetOffsetx, resetOffsety, 0);
            fallen = true;
            Debug.Log("Stored position" + resetPosition);
        }

        //player hits hole, player position is saved when hitting hole, player position is reset to that position

        //playerPos = GameObject.Find("Player").transform.position;
        //if (reset)
        //{
        //    Debug.Log("Down the holeeee" + stats.hp);
        //    playerPos = resetPosition;
        //    Debug.Log("Resetttt!");
        //}
        //else
        //    resetPosition = playerPos;
    }

}