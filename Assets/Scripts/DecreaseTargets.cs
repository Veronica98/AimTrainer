using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseTargets : MonoBehaviour
{
    [SerializeField] private float seconds;
    private GenerateTargets generateTargets;

    void Start()
    {
        generateTargets = GameObject.Find("TargetSpawner").GetComponent<GenerateTargets>();
    }

    void FixedUpdate()
    {
        if (Time.timeScale > 0f)
        {
            transform.localScale -= new Vector3(seconds, seconds, seconds);
            if (transform.localScale.x < 0)
            {
                generateTargets.GenerateDecreasingTargets(1);
                Object.Destroy(gameObject);

            }
        }
    }
}
