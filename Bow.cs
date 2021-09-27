using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject arrow;

    public float shootForce;

    public Transform shootPoint;

    public GameObject point;

    GameObject[] points;

    public int numberOfPoint;
    public float spaceBetweenPoints;
    Vector2 shootDir;
    private void Start()
    {
        points = new GameObject[numberOfPoint];
        for (int i = 0; i < numberOfPoint; i++)
        {
            points[i] = Instantiate(point, shootPoint.position, Quaternion.identity); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 bowPosition = transform.position;

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(Input.mousePosition);

        shootDir = mousePosition - bowPosition;

        transform.right = shootDir;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject arrowIns = Instantiate(arrow, shootPoint.position, shootPoint.rotation);
            arrowIns.GetComponent<Rigidbody2D>().velocity = transform.right * shootForce;
        }

        for (int i = 0; i < numberOfPoint; i++)
        {
            points[i].transform.position = PointPosition(i * spaceBetweenPoints);
        }
    }

    Vector3 PointPosition(float t)
    {
        Vector2 position = (Vector2)shootPoint.position + shootDir.normalized * shootForce * t + 0.5f * Physics2D.gravity * t * t;
        return position;
    }
}
