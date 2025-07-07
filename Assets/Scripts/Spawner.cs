using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyTemplate;
    [SerializeField] private int enemiesToSpawn;
    [SerializeField] private float spawnTime;
    
    private Transform[] _spawnPoints;
    private readonly float _rotationAngle = 90;
    private readonly int _directionsCount = 4;
    
    private void Awake()
    {
        _spawnPoints = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            _spawnPoints[i] = transform.GetChild(i);    
        }
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int spawnPointIndex = Random.Range(0, _spawnPoints.Length);
            int moveDirection = Random.Range(0, _directionsCount);
            
            CreateEnemy(_spawnPoints[spawnPointIndex], moveDirection);
            
            yield return new WaitForSeconds(spawnTime);
        }
        
    }

    private void CreateEnemy(Transform spawnPoint, int moveDirection)
    {
        Quaternion enemyRotation = Quaternion.Euler(0,0, moveDirection * _rotationAngle);
        GameObject enemy = Instantiate(enemyTemplate,  spawnPoint.position, enemyRotation);
        enemy.GetComponent<EnemyController>().Init();
    }
    
}
