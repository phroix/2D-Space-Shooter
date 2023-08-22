using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.5f;
    [SerializeField]
    private int speedBoost = 3;
    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private GameObject tripleLaserPrefab;
    [SerializeField]
    private Transform shootPoint;
    [SerializeField]
    private float fireRate = .5f;
    private float nextFire = -1f;
    [SerializeField]
    private int lives = 3;
    [SerializeField]
    private bool isTripleShotActive = false;
    [SerializeField]
    private bool isSpeedBoostActive = false;
    [SerializeField]
    private bool isShieldBoostActive = false;
    private SpawnManager spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        gameObject.transform.position = new Vector3(0,0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time +fireRate;

            if(isTripleShotActive)
            {
                Instantiate(tripleLaserPrefab,shootPoint.transform.position, Quaternion.identity);
            }else
            { 
                Instantiate(laserPrefab, shootPoint.transform.position, Quaternion.identity);
            }
        }
    }

    private void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticaltInput = Input.GetAxis("Vertical");


        Vector3 direction = new Vector3(horizontalInput, verticaltInput, 0);
        if(!isSpeedBoostActive)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(direction * (speed * speedBoost) * Time.deltaTime);
        }
        if (transform.position.y >= 5)
        {
            transform.position = new Vector3(transform.position.x, 5, 0);
        }
        else if (transform.position.y <= -3.8f)
        {
            transform.position = new Vector3(transform.position.x, -3.8f, 0);
        }

        //transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);

        if (transform.position.x > 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x < -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }

    public void Damage()
    {
        lives--;
        if(lives <= 0)
        {
            if (spawnManager != null) spawnManager.OnPlayerDeath();
            Destroy(gameObject);
        }
    }

    public void TripleShotActive()
    {
        isTripleShotActive = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5);
        isTripleShotActive = false;    
    }
    public void SpeedBoostActive()
    {
        isSpeedBoostActive = true;
        StartCoroutine(SpeedBoostPowerDownRoutine());
    }

    IEnumerator SpeedBoostPowerDownRoutine()
    {
        yield return new WaitForSeconds(5);
        isSpeedBoostActive = false;
    }

    public void ShieldBoostActive()
    {
        isShieldBoostActive = true;
        StartCoroutine(ShieldBoostPowerDownRoutine());
    }

    IEnumerator ShieldBoostPowerDownRoutine()
    {
        yield return new WaitForSeconds(5);
        isShieldBoostActive = false;
    }
}
