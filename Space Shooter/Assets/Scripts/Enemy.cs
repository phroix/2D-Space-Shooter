using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 4f;

    // Update is called once per frame
    void Update()
    {
        Respawn();
        CalculateMovement();
    }

    private void Respawn()
    {
        if(transform.position.y < -4)
        {
            float randomX = Random.Range(-8f, 8f);
            transform.position = new Vector3(randomX, 9, 0);
        }
    }

    private void CalculateMovement()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if(player != null) player.Damage();
            Destroy(gameObject);
        }

        if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
