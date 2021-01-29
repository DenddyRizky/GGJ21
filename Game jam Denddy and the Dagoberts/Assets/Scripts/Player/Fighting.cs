using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighting : MonoBehaviour
{
    // Basic combat script
    public GameObject bullet;
    public GameObject player;

    void Start()
    {
        bullet = GameObject.Find("Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetCurrentArm(player);
        }
    }

    private void GetCurrentArm(GameObject player)
    {
        //currentArm = player.CurrentArm
    }
    //Get current arm, perform its attack
}
