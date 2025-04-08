using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _timeRate = 2.0f;
    [SerializeField] private List<SpawnPoint> _spawnPoints;

    private void Start()
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

    private IEnumerator SpawnRepeating()
    {
        WaitForSeconds wait = new WaitForSeconds(_timeRate);

        while (enabled)
        {
            Spawn();

            yield return wait;
        }
    }
}
