using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControllerScript : MonoBehaviour
{
    public int c = 1;

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



    
    public Color inactiveColor;
    public List<Color> selectedColor;

    public int boarderCount;

    
    int cs;

    public float timer;
    public float switchTime;

    // Start is called before the first frame update
    void Start()
    {
        cs = 0;
        c = 0;
        inactiveColor = new Color(0, 0, 0);
        selectedColor = new List<Color>();
        for (int i = 0; i < 6; i++)
        {
            selectedColor.Add(new Color(255, 255, i * 50));
        }
        
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

    public void ChangeToButton(int i)
    {
        switch (i)
        {
            case 1:
                c = i;
                ChangeSelectedColor(c);
                break;
            case 2:
                c = i;
                ChangeSelectedColor(c);
                break;
            case 3:
                c = i;
                ChangeSelectedColor(c);
                break;
            case 4:
                c = i;
                ChangeSelectedColor(c);
                break;
            case 5:
                c = i;
                ChangeSelectedColor(c);
                break;
        }
    }





    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;


        InputStuff();


        
        UpdateColor(c);
    }

    private void InputStuff()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeToButton(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeToButton(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeToButton(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeToButton(4);
        }

    }
    private void UpdateColor(int c)
    {
        cs++;
        if (cs > 5)
        {
            cs = 0;
        }
        
        switch (c)
        {
            case 1:
                s1[0].color = selectedColor[cs];
                s1[1].color = selectedColor[cs];
                s1[2].color = selectedColor[cs];
                s1[3].color = selectedColor[cs];
                break;
            case 2:
                s2[0].color = selectedColor[cs];
                s2[1].color = selectedColor[cs];
                s2[2].color = selectedColor[cs];
                s2[3].color = selectedColor[cs];
                break;
            case 3:
                s3[0].color = selectedColor[cs];
                s3[1].color = selectedColor[cs];
                s3[2].color = selectedColor[cs];
                s3[3].color = selectedColor[cs];
                break;
            case 4:
                s4[0].color = selectedColor[cs];
                s4[1].color = selectedColor[cs];
                s4[2].color = selectedColor[cs];
                s4[3].color = selectedColor[cs];
                break;
            case 5:
                s5[0].color = selectedColor[cs];
                s5[1].color = selectedColor[cs];
                s5[2].color = selectedColor[cs];
                s5[3].color = selectedColor[cs];
                break;
        }
    }
    private void ChangeSelectedColor(int c)
    {
        switch (c)
        {
            case 1:
                for (int i = 0; i < 4; i++)
                {
                    s1[i].color = selectedColor[0];
                    s2[i].color = inactiveColor;
                    s3[i].color = inactiveColor;
                    s4[i].color = inactiveColor;
                    s5[i].color = inactiveColor;
                }

                break;
            case 2:
                for (int i = 0; i < 4; i++)
                {
                    s1[i].color = inactiveColor;
                    s2[i].color = selectedColor[0];
                    s3[i].color = inactiveColor;
                    s4[i].color = inactiveColor;
                    s5[i].color = inactiveColor;
                }
                break;
            case 3:
                for (int i = 0; i < 4; i++)
                {
                    s1[i].color = inactiveColor;
                    s2[i].color = inactiveColor;
                    s3[i].color = selectedColor[0];
                    s4[i].color = inactiveColor;
                    s5[i].color = inactiveColor;
                }
                break;
            case 4:
                for (int i = 0; i < 4; i++)
                {
                    s1[i].color = inactiveColor;
                    s2[i].color = inactiveColor;
                    s3[i].color = inactiveColor;
                    s4[i].color = selectedColor[0];
                    s5[i].color = inactiveColor;
                }
                break;
            case 5:
                for (int i = 0; i < 4; i++)
                {
                    s1[i].color = inactiveColor;
                    s2[i].color = inactiveColor;
                    s3[i].color = inactiveColor;
                    s4[i].color = inactiveColor;
                    s5[i].color = selectedColor[0];
                }
                break;
        }
    }
}
