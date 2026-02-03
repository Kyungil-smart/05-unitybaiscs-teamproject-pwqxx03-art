using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
  [SerializeField] private GameObject _monsterPrefab;
    [SerializeField] private List<Vector2> _spawnPoints = new List<Vector2>();
    [SerializeField] private float _spawnDelay;

    private void Start()
    {
        StartCoroutine(SpawnMonster());
    }

    private IEnumerator SpawnMonster()
    {
        while (true)
        {
            
            for (int i = 0; i < _spawnPoints.Count; i++)
            {
                Instantiate(_monsterPrefab, _spawnPoints[i], Quaternion.identity);
             
            }
            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}
