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
        //Debug.Log(point);
        lr.enabled = true;
        var mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 angle = mousePos - point;
        angle.Normalize();

        Vector2 maxRangeBeam = point + (angle * maxLength);

        lr.SetPosition(0, point);
        Debug.Log("POINT 1 LR: " + point);
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

        DrawCollider(lr);
    }

    void DrawCollider(LineRenderer lr)
    {
        var ec = gameObject.AddComponent<EdgeCollider2D>();
        ec.isTrigger = true;
        Vector3[] points = new Vector3[lr.positionCount];
        lr.GetPositions(points);

        Vector2[] pointsList = new Vector2[lr.positionCount];

        for (int i=0; i<2; i++)
        {
            //pointsList[i] = points[i];
        }

        Debug.Log("POINT 1 EC: " + pointsList[0]);
        //Debug.Log("POINT 2: " + pointsList[1]);

        pointsList[0] = Vector2.zero;
        pointsList[1] = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);

        ec.points = pointsList;
        Destroy(ec, 0.2f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(point, maxLength);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemies")
        {
            Debug.Log("HIT");
        }
    }
}
