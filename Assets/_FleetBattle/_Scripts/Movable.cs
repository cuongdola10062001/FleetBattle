using MyGrid.Code;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movable : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private Vector3 _offset;
    [SerializeField] private LayerMask mask;

    private Transform currentMovable;
    private Vector3 homePosition;
    private GridManager manager;
    private MyTile _myTile;

    private void Start()
    {
        currentMovable = transform.parent;
        homePosition = transform.position;
        manager = transform.parent.GetComponent<GridManager>();
        _myTile = GetComponent<MyTile>();
    }

    #region Pointer

    public void OnPointerDown(PointerEventData eventData)
    {
        var target = Camera.main.ScreenToWorldPoint(eventData.position);
        _offset = currentMovable.position - target;

    }

    public void OnDrag(PointerEventData eventData)
    {
        var target = Camera.main.ScreenToWorldPoint(eventData.position);
        target += _offset;
        target.z = 0;
        currentMovable.position = target;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        var allowSetToGrid = AllowSetToGrid();

        if (allowSetToGrid)
        {
            SetPositionAll();
        }
        else
        {
            BackHomeAll();
        }
    }

    #endregion

    #region Manager
    private bool AllowSetToGrid()
    {
        var allowSetToGrid = true;
        foreach (var tile in manager.Tiles)
        {
            if (!tile.gameObject.activeSelf) continue;

            var myTile = (MyTile)tile;
            var hit = myTile.Movable.Hit();

            if (!hit)
            {

                allowSetToGrid = false;
                break;
            }

            // OnMyTile
            var baseTile = hit.transform.GetComponent<MyTile>();
            if (baseTile.OnMyTile)
            {
                allowSetToGrid = false;
                break;
            }

        }

        return allowSetToGrid;
    }

    private void SetPositionAll()
    {
        foreach (var tile in manager.Tiles)
        {
            if (!tile.gameObject.activeSelf) continue;
            var myTile = (MyTile)tile;
            myTile.Movable.SetPositionToHit();
        }
    }

    private void BackHomeAll()
    {
        foreach (var tile in manager.Tiles)
        {
            if (!tile.gameObject.activeSelf) continue;
            var myTile = (MyTile)tile;
            myTile.Movable.BackHome();
        }
    }
    #endregion


    private void SetPositionToHit()
    {
        var hit = Hit();
        var baseTile = hit.transform.GetComponent<MyTile>();
        baseTile.OnMyTile = _myTile;
        var target = hit.transform.position;
        target.z = 0.5f;
        transform.position = target;
    }



    private void BackHome()
    {
        transform.position = homePosition;
    }



    private RaycastHit2D Hit()
    {
        var origin = transform.position;

        return Physics2D.Raycast(origin, Vector3.forward, 10, mask);

    }

    /*void FixedUpdate()
    {
        var hit = this.it();
        Debug.Log(hit ? $"Did it {hit.transform.name}" : "No hit");
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, hit ? Color.yellow : Color.white);
    }*/
}
