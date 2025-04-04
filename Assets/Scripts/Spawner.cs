using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _timeRate = 2.0f;
    [SerializeField] private List<SpawnPoint> _spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Spawn), 0, _timeRate);
    }

    private void Spawn()
    {
        Enemy enemy = Instantiate(_enemyPrefab);
        enemy.Init(_spawnPoints[Random.Range(0, _spawnPoints.Count)].Position, GetRandomDirection());
    }

    private Vector3 GetRandomDirection()
    {
        Vector3 direction = Random.onUnitSphere;

        return new Vector3(direction.x, 0, direction.z).normalized;
    }

    [ContextMenu(nameof(FindSpawnPoints))]
    private void FindSpawnPoints()
    {
        _spawnPoints = new List<SpawnPoint>(FindObjectsOfType<SpawnPoint>());
    }
}
