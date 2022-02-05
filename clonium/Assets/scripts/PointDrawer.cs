using UnityEngine;
using UnityEngine.Tilemaps;

public class PointDrawer : MonoBehaviour
{
    private MapManager _manager;
    private Stepwise _aliveCheck;
    
    private Tilemap _map;
    private Tilemap _background;
    
    [Header("Tiles")] 
    [SerializeField] 
    private TileBase[] _availableTile;
    private TileBase[] _dots;

    [Space(10)]
    [Header("Sounds")]
    [SerializeField] 
    private AudioSource _explosionSound;

    //enum to find winner
    public enum Winner
    {
        Blue,
        Green,
        Red,
        Yellow,
        No          //there is no winner now
    }
    
    private Winner _winner = Winner.No;
    
    void Start()
    {
        _manager = gameObject.GetComponent<MapManager>();
        _aliveCheck = gameObject.GetComponent<Stepwise>();
        
        _map = _manager.GetMap();
        _background = _manager.GetGrid();
        _dots = _manager.GetDots();
    }

    void Update()
    {
        for (int i = -5; i < 5; i++)
        {
            for (int j = -10; j < 10; j++)
            {
                Vector3Int pos = new Vector3Int(i, j, 0);
                if (_map.GetTile(pos) != null)
                {
                    //clear 4 dot tiles and fill other
                    
                    //blue
                    if (_map.GetTile(new Vector3Int(i, j, 0)) == _availableTile[0])
                    {
                        _explosionSound.Play();
                        UpperDot(pos);
                        LowerDot(pos);
                        LeftDot(pos);
                        RightDot(pos);
                        _map.SetTile(new Vector3Int(i, j, 0), null);
                    }
                    //green
                    else if (_map.GetTile(new Vector3Int(i, j, 0)) == _availableTile[1])
                    {
                        _explosionSound.Play();
                        UpperDot(pos);
                        LowerDot(pos);
                        LeftDot(pos); 
                        RightDot(pos); 
                        _map.SetTile(new Vector3Int(i, j, 0), null);
                    }
                    //red
                    else if (_map.GetTile(new Vector3Int(i, j, 0)) == _availableTile[2])
                    { 
                        _explosionSound.Play();
                        UpperDot(pos); 
                        LowerDot(pos); 
                        LeftDot(pos); 
                        RightDot(pos); 
                        _map.SetTile(new Vector3Int(i, j, 0), null);
                    }
                    //yellow
                    else if (_map.GetTile(new Vector3Int(i, j, 0)) == _availableTile[3])
                    { 
                        _explosionSound.Play();
                        UpperDot(pos); 
                        LowerDot(pos);
                        LeftDot(pos);
                        RightDot(pos);
                        _map.SetTile(new Vector3Int(i, j, 0), null);
                    }
                    
                    //find if there is only one color
                    if (!_aliveCheck.BlueFinder() && !_aliveCheck.GreenFinder() && !_aliveCheck.RedFinder())
                        _winner = Winner.Yellow;
                    else if(!_aliveCheck.BlueFinder() && !_aliveCheck.GreenFinder() && !_aliveCheck.YellowFinder())
                        _winner = Winner.Red;
                    else if(!_aliveCheck.BlueFinder() && !_aliveCheck.RedFinder() && !_aliveCheck.YellowFinder())
                        _winner = Winner.Green;
                    else if (!_aliveCheck.GreenFinder() && !_aliveCheck.RedFinder() && !_aliveCheck.YellowFinder())
                        _winner = Winner.Blue;
                    else 
                        _winner = Winner.No;
                }
            }
        }        
    }
    //functions to draw top/down/right/left dots 
    private void UpperDot(Vector3Int pos)
    {
        //set the direction
        Vector3Int cell = pos + Vector3Int.up;
        
        //check if it is the end of the field
        if (_background.GetTile(cell) != null)
        {
            if (_map.GetTile(pos).name.Contains("Blue"))
            {
                if (_map.GetTile(cell) == null)
                    _map.SetTile(cell, _dots[0]);
                else if (_map.GetTile(cell).name.Contains("1"))
                    _map.SetTile(cell, _dots[1]);
                else if (_map.GetTile(cell).name.Contains("2"))
                    _map.SetTile(cell, _dots[2]);
                else if (_map.GetTile(cell).name.Contains("3"))
                    _map.SetTile(cell, _dots[3]);
            }
            else if (_map.GetTile(pos).name.Contains("Green"))
            {
                if (_map.GetTile(cell) == null)
                    _map.SetTile(cell, _dots[4]);
                else if (_map.GetTile(cell).name.Contains("1"))
                    _map.SetTile(cell, _dots[5]);
                else if (_map.GetTile(cell).name.Contains("2"))
                    _map.SetTile(cell, _dots[6]);
                else if (_map.GetTile(cell).name.Contains("3"))
                    _map.SetTile(cell, _dots[7]);
            }
            else if (_map.GetTile(pos).name.Contains("Red"))
            {
                if (_map.GetTile(cell) == null)
                    _map.SetTile(cell, _dots[8]);
                else if (_map.GetTile(cell).name.Contains("1"))
                    _map.SetTile(cell, _dots[9]);
                else if (_map.GetTile(cell).name.Contains("2"))
                    _map.SetTile(cell, _dots[10]);
                else if (_map.GetTile(cell).name.Contains("3"))
                    _map.SetTile(cell, _dots[11]);
            }
            else if (_map.GetTile(pos).name.Contains("Yellow"))
            {
                if (_map.GetTile(cell) == null)
                    _map.SetTile(cell, _dots[12]);
                else if (_map.GetTile(cell).name.Contains("1"))
                    _map.SetTile(cell, _dots[13]);
                else if (_map.GetTile(cell).name.Contains("2"))
                    _map.SetTile(cell, _dots[14]);
                else if (_map.GetTile(cell).name.Contains("3"))
                    _map.SetTile(cell, _dots[15]);
            }
        }
    }
    private void LowerDot(Vector3Int pos)
    {
        Vector3Int cell = pos + Vector3Int.down;
        
        if (_background.GetTile(cell) != null)
        {
            if (_map.GetTile(pos).name.Contains("Blue"))
            {
                if (_map.GetTile(cell) == null)
                    _map.SetTile(cell, _dots[0]);
                else if (_map.GetTile(cell).name.Contains("1"))
                    _map.SetTile(cell, _dots[1]);
                else if (_map.GetTile(cell).name.Contains("2"))
                    _map.SetTile(cell, _dots[2]);
                else if (_map.GetTile(cell).name.Contains("3"))
                    _map.SetTile(cell, _dots[3]);
            }
            else if (_map.GetTile(pos).name.Contains("Green"))
            {
                if (_map.GetTile(cell) == null)
                    _map.SetTile(cell, _dots[4]);
                else if (_map.GetTile(cell).name.Contains("1"))
                    _map.SetTile(cell, _dots[5]);
                else if (_map.GetTile(cell).name.Contains("2"))
                    _map.SetTile(cell, _dots[6]);
                else if (_map.GetTile(cell).name.Contains("3"))
                    _map.SetTile(cell, _dots[7]);
            }
            else if (_map.GetTile(pos).name.Contains("Red"))
            {
                if (_map.GetTile(cell) == null)
                    _map.SetTile(cell, _dots[8]);
                else if (_map.GetTile(cell).name.Contains("1"))
                    _map.SetTile(cell, _dots[9]);
                else if (_map.GetTile(cell).name.Contains("2"))
                    _map.SetTile(cell, _dots[10]);
                else if (_map.GetTile(cell).name.Contains("3"))
                    _map.SetTile(cell, _dots[11]);
            }
            else if (_map.GetTile(pos).name.Contains("Yellow"))
            {
                if (_map.GetTile(cell) == null)
                    _map.SetTile(cell, _dots[12]);
                else if (_map.GetTile(cell).name.Contains("1"))
                    _map.SetTile(cell, _dots[13]);
                else if (_map.GetTile(cell).name.Contains("2"))
                    _map.SetTile(cell, _dots[14]);
                else if (_map.GetTile(cell).name.Contains("3"))
                    _map.SetTile(cell, _dots[15]);
            }
        }
    }
    private void LeftDot(Vector3Int pos)
    {
        Vector3Int cell = pos + Vector3Int.left;
        
        if (_background.GetTile(cell) != null)
        {
            if (_map.GetTile(pos).name.Contains("Blue"))
            {
                if (_map.GetTile(cell) == null)
                    _map.SetTile(cell, _dots[0]);
                else if (_map.GetTile(cell).name.Contains("1"))
                    _map.SetTile(cell, _dots[1]);
                else if (_map.GetTile(cell).name.Contains("2"))
                    _map.SetTile(cell, _dots[2]);
                else if (_map.GetTile(cell).name.Contains("3"))
                    _map.SetTile(cell, _dots[3]);
            }
            else if (_map.GetTile(pos).name.Contains("Green"))
            {
                if (_map.GetTile(cell) == null)
                    _map.SetTile(cell, _dots[4]);
                else if (_map.GetTile(cell).name.Contains("1"))
                    _map.SetTile(cell, _dots[5]);
                else if (_map.GetTile(cell).name.Contains("2"))
                    _map.SetTile(cell, _dots[6]);
                else if (_map.GetTile(cell).name.Contains("3"))
                    _map.SetTile(cell, _dots[7]);
            }
            else if (_map.GetTile(pos).name.Contains("Red"))
            {
                if (_map.GetTile(cell) == null)
                    _map.SetTile(cell, _dots[8]);
                else if (_map.GetTile(cell).name.Contains("1"))
                    _map.SetTile(cell, _dots[9]);
                else if (_map.GetTile(cell).name.Contains("2"))
                    _map.SetTile(cell, _dots[10]);
                else if (_map.GetTile(cell).name.Contains("3"))
                    _map.SetTile(cell, _dots[11]);
            }
            else if (_map.GetTile(pos).name.Contains("Yellow"))
            {
                if (_map.GetTile(cell) == null)
                    _map.SetTile(cell, _dots[12]);
                else if (_map.GetTile(cell).name.Contains("1"))
                    _map.SetTile(cell, _dots[13]);
                else if (_map.GetTile(cell).name.Contains("2"))
                    _map.SetTile(cell, _dots[14]);
                else if (_map.GetTile(cell).name.Contains("3"))
                    _map.SetTile(cell, _dots[15]);
            }
        }
    }
    private void RightDot(Vector3Int pos)
    {
        Vector3Int cell = pos + Vector3Int.right;
        
        if (_background.GetTile(cell) != null)
        {
            if (_map.GetTile(pos).name.Contains("Blue"))
            {
                if (_map.GetTile(cell) == null)
                    _map.SetTile(cell, _dots[0]);
                else if (_map.GetTile(cell).name.Contains("1"))
                    _map.SetTile(cell, _dots[1]);
                else if (_map.GetTile(cell).name.Contains("2"))
                    _map.SetTile(cell, _dots[2]);
                else if (_map.GetTile(cell).name.Contains("3"))
                    _map.SetTile(cell, _dots[3]);
            }
            else if (_map.GetTile(pos).name.Contains("Green"))
            {
                if (_map.GetTile(cell) == null)
                    _map.SetTile(cell, _dots[4]);
                else if (_map.GetTile(cell).name.Contains("1"))
                    _map.SetTile(cell, _dots[5]);
                else if (_map.GetTile(cell).name.Contains("2"))
                    _map.SetTile(cell, _dots[6]);
                else if (_map.GetTile(cell).name.Contains("3"))
                    _map.SetTile(cell, _dots[7]);
            }
            else if (_map.GetTile(pos).name.Contains("Red"))
            {
                if (_map.GetTile(cell) == null)
                    _map.SetTile(cell, _dots[8]);
                else if (_map.GetTile(cell).name.Contains("1"))
                    _map.SetTile(cell, _dots[9]);
                else if (_map.GetTile(cell).name.Contains("2"))
                    _map.SetTile(cell, _dots[10]);
                else if (_map.GetTile(cell).name.Contains("3"))
                    _map.SetTile(cell, _dots[11]);
            }
            else if (_map.GetTile(pos).name.Contains("Yellow"))
            {
                if (_map.GetTile(cell) == null)
                    _map.SetTile(cell, _dots[12]);
                else if (_map.GetTile(cell).name.Contains("1"))
                    _map.SetTile(cell, _dots[13]);
                else if (_map.GetTile(cell).name.Contains("2"))
                    _map.SetTile(cell, _dots[14]);
                else if (_map.GetTile(cell).name.Contains("3"))
                    _map.SetTile(cell, _dots[15]);
            }
        }
    }

    public Winner GetWinner() => _winner;

}
