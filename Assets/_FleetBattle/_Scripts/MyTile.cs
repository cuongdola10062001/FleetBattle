using MyGrid.Code;

public class MyTile : TileController
{
    public Movable Movable { get; private set; }
    public MyTile OnMyTile;

    private void Start()
    {
        Movable = GetComponent<Movable>();
    }
}
