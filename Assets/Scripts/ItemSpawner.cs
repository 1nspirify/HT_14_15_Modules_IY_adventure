using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private List<ItemSpawnPoint> _spawnPoints;
    [SerializeField] private List<Item> _itemPrefabs;

    private float _timer;
    [SerializeField] float _cooldown;

    private void Update()
    {
        _timer += Time.deltaTime;
        
        if (_timer >= _cooldown)
        {
            List<ItemSpawnPoint> _emptySpawnPoints = GetEmptySpawnPoints();

            if (_emptySpawnPoints.Count == 0)
            {
                _timer = 0;
                return;
            }

            ItemSpawnPoint itemSpawnPoint = _emptySpawnPoints[Random.Range(0, _emptySpawnPoints.Count)];
            
            Item item = Instantiate(_itemPrefabs[Random.Range(0, _itemPrefabs.Count)], itemSpawnPoint.Position,
                Quaternion.identity);

            itemSpawnPoint.Occupy(item);

            _timer = 0;
        }
    }

    private List<ItemSpawnPoint> GetEmptySpawnPoints()
    {
        List<ItemSpawnPoint> emptySpawnPoints = new List<ItemSpawnPoint>();
        
        foreach (ItemSpawnPoint spawnPoint in _spawnPoints)
        {
            if (spawnPoint.IsEmpty)
            {
                emptySpawnPoints.Add(spawnPoint);
                Debug.Log("Empty spawn point: " + spawnPoint.name);
            }
        }

        return emptySpawnPoints;
    }
}