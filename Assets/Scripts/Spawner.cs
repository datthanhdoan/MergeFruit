using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;
    [SerializeField] private FruitListSO _fruitListSO;

    private float _timeToSpawn = 0.5f;
    private float _timeToSpawnCounter = 0f;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && _timeToSpawnCounter <= 0)
        {
            int fruitTypeCount = _fruitListSO.fruitList.Count;
            // Random in all fruit types
            FruitType fruitType = (FruitType)Random.Range(0, 3);
            SpawnFruit(fruitType, transform.position);

            _timeToSpawnCounter = _timeToSpawn;
        }
        if (_timeToSpawnCounter > 0) _timeToSpawnCounter -= Time.deltaTime;
    }

    public void SpawnFruit(FruitType fruitType, Vector3 spawnPosition)
    {
        Instantiate(_fruitListSO.fruitList[(int)fruitType], spawnPosition, Quaternion.identity);
        // Instantiate(_fruitListSO.fruitList[index], spawnTransform.position, Quaternion.identity);
    }
}