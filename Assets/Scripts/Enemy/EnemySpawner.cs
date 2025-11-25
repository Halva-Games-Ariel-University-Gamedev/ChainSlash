using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRadius = 8f;
    public float minDelay = 0.5f;
    public float maxDelay = 2f;

    public int maxEnemies = 20;
    public string enemyTag = "Enemy";  // make sure your enemy prefab is tagged

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            // stop spawning if we reached the cap
            if (GameObject.FindGameObjectsWithTag(enemyTag).Length >= maxEnemies)
                continue;

            Vector2 spawnPos = (Vector2)transform.position +
                Random.insideUnitCircle.normalized * spawnRadius;

            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
