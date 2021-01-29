using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicOrb : Arm
{
    public GameObject beamStart;
    public GameObject beamMid;
    public GameObject beamEnd;

    private GameObject start;
    private GameObject middle;
    private GameObject end;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Attack();

    }
    void Attack()
    {
        if (start == null)
        {
            start = Instantiate(beamStart) as GameObject;
            start.transform.parent = this.transform;
            Debug.Log(start.transform.parent);
        }

        if (middle == null)
        {
            middle = Instantiate(beamMid) as GameObject;
            middle.transform.parent = this.transform;
            middle.transform.localPosition = Vector2.zero;
        }

        float maxSize = 20f;
        float currentSize = maxSize;

        Vector2 beamDirection = this.transform.right;

        RaycastHit2D hit = Physics2D.Raycast(
            this.transform.position,
            beamDirection,
            maxSize);

        if (hit.collider != null)
        {
            currentSize = Vector2.Distance(hit.point, this.transform.position);

            if (end == null)
            {
                end = Instantiate(beamEnd) as GameObject;
                end.transform.parent = this.transform;
                end.transform.localPosition = Vector2.zero;
            }
        }
        else
        {
            if (end != null) Destroy(end);
        }

        if (end != null)
        {
            end.transform.localPosition = new Vector2(currentSize, 0f);
        }
    }
}
