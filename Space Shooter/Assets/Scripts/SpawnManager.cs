using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject enemyContainer;

    [SerializeField]
    private GameObject powerupContainer;
    [SerializeField]
    private GameObject[] powerups;

    private bool stopSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while(!stopSpawning)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 9, 0);
            var newEnemy = Instantiate(enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(5f);
        }
    }

    IEnumerator SpawnPowerupRoutine()
    {
        while(!stopSpawning)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 9, 0);
            int randomPowerUp = Random.Range(0, 3);
            var newPowerup = Instantiate(powerups[randomPowerUp], posToSpawn, Quaternion.identity);
            newPowerup.transform.parent = powerupContainer.transform;
            yield return new WaitForSeconds(Random.Range(3, 7));
        }
    }

    public void OnPlayerDeath()
    {
        stopSpawning = true;  
    }
}
