using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject heart4;
    public GameObject heart5;

    Animator h1;
    Animator h2;
    Animator h3;
    Animator h4;
    Animator h5;

    public int Health;

    // Start is called before the first frame update
    void Start()
    {
        h1 = heart1.GetComponent<Animator>();
        h2 = heart2.GetComponent<Animator>();
        h3 = heart3.GetComponent<Animator>();
        h4 = heart4.GetComponent<Animator>();
        h5 = heart5.GetComponent<Animator>();
        Health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        switch (Health)
        {
            case 1:
                h1.SetInteger("Health", 2);
                h2.SetInteger("Health", 1);
                h3.SetInteger("Health", 1);
                h4.SetInteger("Health", 1);
                h5.SetInteger("Health", 1);
                break;
            case 2:
                h1.SetInteger("Health", 3);
                h2.SetInteger("Health", 1);
                h3.SetInteger("Health", 1);
                h4.SetInteger("Health", 1);
                h5.SetInteger("Health", 1);
                break;
            case 3:
                h1.SetInteger("Health", 3);
                h2.SetInteger("Health", 2);
                h3.SetInteger("Health", 1);
                h4.SetInteger("Health", 1);
                h5.SetInteger("Health", 1);
                break;
            case 4:
                h1.SetInteger("Health", 3);
                h2.SetInteger("Health", 3);
                h3.SetInteger("Health", 1);
                h4.SetInteger("Health", 1);
                h5.SetInteger("Health", 1);
                break;
            case 5:
                h1.SetInteger("Health", 3);
                h2.SetInteger("Health", 3);
                h3.SetInteger("Health", 2);
                h4.SetInteger("Health", 1);
                h5.SetInteger("Health", 1);
                break;
            case 6:
                h1.SetInteger("Health", 3);
                h2.SetInteger("Health", 3);
                h3.SetInteger("Health", 3);
                h4.SetInteger("Health", 1);
                h5.SetInteger("Health", 1);
                break;
            case 7:
                h1.SetInteger("Health", 3);
                h2.SetInteger("Health", 3);
                h3.SetInteger("Health", 3);
                h4.SetInteger("Health", 2);
                h5.SetInteger("Health", 1);
                break;
            case 8:
                h1.SetInteger("Health", 3);
                h2.SetInteger("Health", 3);
                h3.SetInteger("Health", 3);
                h4.SetInteger("Health", 3);
                h5.SetInteger("Health", 1);
                break;
            case 9:
                h1.SetInteger("Health", 3);
                h2.SetInteger("Health", 3);
                h3.SetInteger("Health", 3);
                h4.SetInteger("Health", 3);
                h5.SetInteger("Health", 2);
                break;
            case 10:
                h1.SetInteger("Health", 3);
                h2.SetInteger("Health", 3);
                h3.SetInteger("Health", 3);
                h4.SetInteger("Health", 3);
                h5.SetInteger("Health", 3);
                break;
        }
    }
}
