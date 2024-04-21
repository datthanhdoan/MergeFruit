using System;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;
    public static event Action OnNextFruitChange;
    [SerializeField] private FruitListSO _fruitListSO;
    [SerializeField] private Image _visualFruitImageNow;
    [NonSerialized] public FruitType fruitTypeNow, fruitTypeNext;
    private bool _randomFruit = false;
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

    private void Start()
    {
        fruitTypeNext = (FruitType)Random.Range(0, 3);
    }

    private void Update()
    {
        if (!_randomFruit)
        {
            // Random in all fruit types

            fruitTypeNow = fruitTypeNext;
            fruitTypeNext = (FruitType)Random.Range(0, 3);
            OnNextFruitChange?.Invoke();

            _visualFruitImageNow.sprite = _fruitListSO.fruitList[(int)fruitTypeNow].GetComponent<SpriteRenderer>().sprite;
            _visualFruitImageNow.transform.localScale = _fruitListSO.fruitList[(int)fruitTypeNow].gameObject.transform.localScale;

            _randomFruit = true;
        }
        if (Input.GetMouseButtonUp(0) && _timeToSpawnCounter <= 0)
        {
            SpawnFruit(fruitTypeNow, transform.position);

            _timeToSpawnCounter = _timeToSpawn;

            _randomFruit = false;
        }
        if (_timeToSpawnCounter <= 0)
        {
            _visualFruitImageNow.gameObject.SetActive(true);
        }
        if (_timeToSpawnCounter > 0)
        {
            _visualFruitImageNow.gameObject.SetActive(false);
            _timeToSpawnCounter -= Time.deltaTime;
        }
    }

    public Sprite GetFruitImage(FruitType fruitType)
    {
        return _fruitListSO.fruitList[(int)fruitType].GetComponent<SpriteRenderer>().sprite;
    }

    public void SpawnFruit(FruitType fruitType, Vector3 spawnPosition)
    {
        Instantiate(_fruitListSO.fruitList[(int)fruitType], spawnPosition, Quaternion.identity);
    }
}