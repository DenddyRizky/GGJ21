using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public int[] ActiveHeads;
    public int headNumber;
    public Head currentHead;
    // Start is called before the first frame update
    void Start()
    {
        ActiveHeads = new int[3];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            headNumber = 1;
            switchHead();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            headNumber = 2;
            switchHead();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            headNumber = 3;
            switchHead();
        }
    }

    void switchHead()
    {
        switch (ActiveHeads[headNumber])
        {
            case 1:
                Debug.Log("SHARINGAN");
                break;
            case 2:
                Debug.Log("SCARY FACE");
                break;
            case 3:
                Debug.Log("BIG FACE");
                break;
            case 0:
                currentHead = null;
                break;
        }
    }
}
