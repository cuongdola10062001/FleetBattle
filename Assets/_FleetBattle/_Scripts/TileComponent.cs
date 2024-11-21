using System;
using UnityEngine;

public class TileComponent : MonoBehaviour
{
    public TileItem tileItem;

    public virtual void SetData(TileItem tileItem)
    {
        this.tileItem = tileItem;
    }
}

[Serializable]
public class TileItem
{
    public Vector2Int index;
    public bool hasShip;
}

