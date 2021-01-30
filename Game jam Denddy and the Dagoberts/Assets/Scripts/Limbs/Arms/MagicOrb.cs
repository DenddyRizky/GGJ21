using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicOrb : Arm
{
    public Camera cam;
    public GameObject firePoint;
    public LineRenderer lr;
    public float maxLength;
    public LayerMask beamLayer;
    private Vector2 point;

    // Start is called before the first frame update
    void Start()
    {
        attack = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
            Attack();

        if (Input.GetButtonUp("Fire1"))
            lr.enabled = false;
    }
    void Attack()
    {
        point = firePoint.transform.position;
        lr.enabled = true;
        var mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 angle = new Vector2((mousePos.x - point.x), (mousePos.y - point.y));
        angle.Normalize();

        Vector2 maxRangeBeam = point + (angle * maxLength);

        lr.SetPosition(0, point);

        Vector2 angleToMouse = maxRangeBeam - mousePos;
        Vector2 angleToPoint = maxRangeBeam - point;
        angleToMouse.Normalize();
        angleToPoint.Normalize();

        if (angleToMouse != angleToPoint)
        {
            lr.SetPosition(1, maxRangeBeam);
        } else
        {
            lr.SetPosition(1, mousePos);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(point, maxLength);
    }
}
