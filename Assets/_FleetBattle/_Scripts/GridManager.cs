using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    public Dictionary<Vector2Int, GameObject> map;
    [SerializeField] private GameObject overlayPrefab;
    [SerializeField] private GameObject overlayContainer;

    private void Start()
    {
        Tilemap tileMap = gameObject.GetComponentInChildren<Tilemap>();
        map = new Dictionary<Vector2Int, GameObject>();
        BoundsInt bounds = tileMap.cellBounds;

        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int cellPosition = new Vector3Int(x, y, 0);
                TileBase tile = tileMap.GetTile(cellPosition);
                if (tile != null)
                {
                    var tileKey = new Vector2Int(x, y);
                    var overlayTile = Instantiate(overlayPrefab, overlayContainer.transform);
                    var cellWorldPosition = tileMap.GetCellCenterWorld(cellPosition);
                    overlayTile.transform.position = new Vector3(cellWorldPosition.x, cellWorldPosition.y, 0);

                    TileComponent tileComponent= overlayTile.GetComponent<TileComponent>();
                    TileItem tileItem = new TileItem
                    {
                        index = tileKey,
                        hasShip = false,
                    };
                    tileComponent.SetData(tileItem);

                    map.Add(tileKey, overlayTile);
                }
            }
        }
    }
}
