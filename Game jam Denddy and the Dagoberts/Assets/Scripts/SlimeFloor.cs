using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeFloor : MonoBehaviour
{
    public float slow;
    Leg leg;
    bool slowed;
    // Start is called before the first frame update
    void Start()
    {
        slowed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        leg = collision.gameObject.GetComponent<Leg>();
        Rigidbody2D playerrb = collision.gameObject.GetComponent<Rigidbody2D>();

        if (collision.gameObject.name == "Player" && leg.currentLeg != leg.spikeBoots)
        {
            playerrb.drag = slow;
            slowed = true;
        }else if(slowed && leg.currentLeg == leg.spikeBoots)
        {
            slowed = false;
            playerrb.drag = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && leg.currentLeg != leg.spikeBoots)
        {
            Rigidbody2D playerrb = collision.gameObject.GetComponent<Rigidbody2D>();
            playerrb.drag = 0;
        }

    }

}
