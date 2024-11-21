using System.Collections.Generic;
using UnityEngine;

public class Ship
{
    public Vector2Int startIndex;      
    public List<Vector2Int> shape;     
    public bool isPlaced;              

    public Ship(Vector2Int start, List<Vector2Int> shapeOffsets)
    {
        startIndex = start;
        shape = new List<Vector2Int>(shapeOffsets);
        isPlaced = false;
    }
}