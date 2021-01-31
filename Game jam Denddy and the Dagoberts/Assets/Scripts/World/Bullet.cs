using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletTime;

    // Update is called once per frame
    void Update()
    {
        bulletTime -= Time.deltaTime;
        if (bulletTime < 0) Destroy(this.gameObject);
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemies")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);

        }
        else if (collision.gameObject.tag == "Environment")
        {
            Destroy(this.gameObject);
        }
    }*/

    /*private void OnTriggerExit2D(Collider2D collision)
    {
        //Maybe do the collision in the enemy

        if (collision.gameObject.tag == "Enemies")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            
        } else if (collision.gameObject.tag == "Environment")
        {
            Destroy(this.gameObject);
        }
    }*/
}
