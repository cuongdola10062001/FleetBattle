using MyGrid.Code;
using UnityEngine;

public class BaseGrid : MonoBehaviour
{
    [SerializeField] private GridManager _manager;

    private void CheckGrid()
    {

    }

    private bool IsFullRow(int row)
    {
        for (int i = 0; i < 10; i++)
        {
            var tile = (MyTile)_manager.GetTile(new Vector2Int(i, row));
            if (!tile.OnMyTile) return false;
        }

        return true;
    }
}
