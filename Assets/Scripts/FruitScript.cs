using System;
using System.Collections;
using UnityEngine;


public enum FruitType
{
    Apple,
    Orange,
    Peach,
    Pumpkin,
    WaterMelon

}
public class FruitScript : MonoBehaviour
{
    public FruitType fruitType;
    private Spawner _spawner;
    [SerializeField] ParticleSystem _mergeEffect;
    private void Start()
    {
        _spawner = Spawner.instance;
    }
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out FruitScript fruit))
        {
            if (fruit.fruitType == fruitType)
            {

                if (this.GetInstanceID() > fruit.GetInstanceID())
                {
                    if ((int)fruitType == (int)FruitType.WaterMelon)
                    {
                        float waitTime = 0.1f;
                        StartCoroutine(WaitDesktroy(waitTime, other.gameObject, gameObject));

                    }
                    else
                    {
                        Debug.Log("Fruit Combined");

                        float waitTime = 0.1f;
                        StartCoroutine(WaitDesktroySpawn(waitTime, other.gameObject, gameObject));


                    }
                }
            }
        }


    }
    private void DestroyFruit(GameObject other, GameObject gameObject)
    {
        Destroy(other);
        Destroy(gameObject);
    }
    IEnumerator WaitDesktroy(float waitTime, GameObject other, GameObject gameObject)
    {
        yield return new WaitForSeconds(waitTime);
        DestroyFruit(other.gameObject, gameObject);
    }
    IEnumerator WaitDesktroySpawn(float waitTime, GameObject other, GameObject gameObject)
    {
        yield return new WaitForSeconds(waitTime);

        Vector3 spawnPosition = (other.transform.position + gameObject.transform.position) / 2f;
        Instantiate(_mergeEffect, spawnPosition, Quaternion.identity);
        _spawner.SpawnFruit(fruitType + 1, spawnPosition);
        DestroyFruit(other.gameObject, gameObject);
    }

}
