using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Spawner _spawner;
    [SerializeField] private Image _fruitImageNextVisual;

    private void Start()
    {
        _spawner = Spawner.instance;
    }
    private void UpdateNextFruitImage()
    {
        _fruitImageNextVisual.sprite = _spawner.GetFruitImage(_spawner.fruitTypeNext);
    }

    private void OnEnable()
    {
        Spawner.OnNextFruitChange += UpdateNextFruitImage;
    }

    private void OnDisable()
    {
        Spawner.OnNextFruitChange -= UpdateNextFruitImage;
    }
}
