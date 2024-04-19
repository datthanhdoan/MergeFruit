using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FruitListSO", menuName = "FruitListSO", order = 0)]
public class FruitListSO : ScriptableObject
{
    public List<GameObject> fruitList = new List<GameObject>();
}