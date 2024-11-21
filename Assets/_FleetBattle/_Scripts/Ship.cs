using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public ShipSO shipSO;
    public bool isPlaced;

}

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Ship", order = 1)]
public class ShipSO : ScriptableObject
{
    public Vector2Int startIndex;
    public List<Vector2Int> shape;
}