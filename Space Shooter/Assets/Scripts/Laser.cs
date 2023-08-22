using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float speed = 8f;

    // Update is called once per frame
    void Update()
    {
        DestroyLaser();
        CalculateMovement();
    }

    private void DestroyLaser()
    {
        if(transform.position.y >= 8)
        {
            if(transform.parent) Destroy(transform.parent.gameObject);
            Destroy(gameObject);
        }
    }

    private void CalculateMovement()
    {
        Vector3 direction = new Vector3(0, 1, 0) * speed * Time.deltaTime;
        transform.Translate(direction);
    }
}
