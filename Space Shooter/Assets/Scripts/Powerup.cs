using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    float speed = 3f;

    [SerializeField]
    private int powerupID;

    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    private void CalculateMovement()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(transform.position.y <= -5.5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            switch (powerupID)
            {
                case 0:
                    if (player != null) player.TripleShotActive();
                    break;
                case 1:
                    if (player != null) player.SpeedBoostActive();
                    break;
                case 2:
                    if (player != null) player.ShieldBoostActive();
                    break;
            }
            Destroy(gameObject);
        }
    }

}
