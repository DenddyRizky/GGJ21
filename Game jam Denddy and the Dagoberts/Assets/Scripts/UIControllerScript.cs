using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControllerScript : MonoBehaviour
{
    public List<GameObject> Boarder1;
    public List<GameObject> Boarder2;
    public List<GameObject> Boarder3;
    public List<GameObject> Boarder4;
    public List<GameObject> Boarder5;

    public List<Image> s1;
    public List<Image> s2;
    public List<Image> s3;
    public List<Image> s4;
    public List<Image> s5;



    public int boarderCount;

    int c = 1;

    public float timer;
    public float switchTime;

    // Start is called before the first frame update
    void Start()
    {
        switchTime = 3;
        boarderCount = 5;
        s1 = new List<Image>();
        s2 = new List<Image>();
        s3 = new List<Image>();
        s4 = new List<Image>();
        s5 = new List<Image>();



        for (int j = 0; j < 4; j++)
        {
            s1.Add(Boarder1[j].GetComponent<Image>());
        }
        for (int j = 0; j < 4; j++)
        {
            s2.Add(Boarder2[j].GetComponent<Image>());
        }
        for (int j = 0; j < 4; j++)
        {
            s3.Add(Boarder3[j].GetComponent<Image>());
        }
        for (int j = 0; j < 4; j++)
        {
            s4.Add(Boarder4[j].GetComponent<Image>());
        }
        for (int j = 0; j < 4; j++)
        {
            s5.Add(Boarder5[j].GetComponent<Image>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (switchTime < timer)
        {
            c++;
            if (c == 6)
            {
                c = 1;
            }
            timer = 0;
        }
        switch (c)
        {
            case 1:
                for (int i = 0; i < 4; i++)
                {
                    s5[i].color = Random.ColorHSV();
                }
                
                break;
            case 2:
                for (int i = 0; i < 4; i++)
                {
                    s5[i].color = Random.ColorHSV();
                }
                break;
            case 3:
                for (int i = 0; i < 4; i++)
                {
                    s5[i].color = Random.ColorHSV();
                }
                break;
            case 4:
                for (int i = 0; i < 4; i++)
                {
                    s5[i].color = Random.ColorHSV();
                }
                break;
            case 5:
                for (int i = 0; i < 4; i++)
                {
                    s5[i].color = Random.ColorHSV();
                }
                break;
        }
    }
}
