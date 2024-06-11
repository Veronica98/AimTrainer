using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MovingTargets : MonoBehaviour
{
    private GameObject targetSpawner;
    private float speed;
    private int direction;

    void Start()
    {
        speed = Random.Range(2f, 10f);
        direction = Random.Range(0, 2) == 0 ? -1 : 1;
    }

    void Update()
    {
        transform.Translate(new Vector3(direction, 0, 0) * Time.deltaTime * speed);
    }


    private void OnCollisionEnter(Collision collision)
    {
        direction *= -1;
    }
}

