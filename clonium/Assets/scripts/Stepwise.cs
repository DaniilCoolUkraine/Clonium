using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Stepwise : MonoBehaviour
{
    [SerializeField]
    private Image _buttonColor;
    
    private MapManager _tile;

    private Tilemap _map;
    
    private TileBase _clickedBackgroundTile;
    private TileBase _clickedForegroundTile;
    
    short _stepNum = 0;
    
    void Start()
    {
        _buttonColor.color = Color.cyan;
        _tile = gameObject.GetComponent<MapManager>();
        _map = _tile.GetMap();
    }
    
    void Update()
    {
        
        _clickedBackgroundTile = _tile.GetBackTile();
        _clickedForegroundTile = _tile.GetFrontTile();
        
        if (_clickedBackgroundTile != null)
        {
            if (_clickedForegroundTile != null)
            {
                if (_stepNum == 0)
                {
                    if (BlueFinder())
                    {
                        _buttonColor.color = Color.cyan;
                        if (_clickedForegroundTile.name.Contains("Blue"))
                        {
                            _stepNum++;
                            _tile.BlueDraw(_tile.GetPosition(), _clickedForegroundTile.name);
                        }
                        else
                            _stepNum = 0;
                    }
                    else
                        _stepNum++;
                }
                else if (_stepNum == 1)
                {
                    if (GreenFinder())
                    {
                        _buttonColor.color = Color.green;
                        if (_clickedForegroundTile.name.Contains("Green"))
                        {
                            _stepNum++;
                            _tile.GreenDraw(_tile.GetPosition(), _clickedForegroundTile.name);
                        }
                        else
                            _stepNum = 1;
                    }
                    else
                        _stepNum++;
                }
                else if (_stepNum == 2)
                {
                    if (RedFinder())
                    {
                        _buttonColor.color = Color.red;
                        if (_clickedForegroundTile.name.Contains("Red"))
                        {
                            _stepNum++;
                            _tile.RedDraw(_tile.GetPosition(), _clickedForegroundTile.name);
                        }
                        else
                            _stepNum = 2;
                    }
                    else
                        _stepNum++;
                }
                else if (_stepNum == 3)
                {
                    if (YellowFinder())
                    {
                        _buttonColor.color = Color.yellow;
                        if (_clickedForegroundTile.name.Contains("Yellow"))
                        {
                            _stepNum++;
                            _tile.YellowDraw(_tile.GetPosition(), _clickedForegroundTile.name);
                        }
                        else
                            _stepNum = 3;
                    }
                    else
                        _stepNum++;
                }
                else _stepNum = 0;
            }
        }
    }

    public bool BlueFinder()
    {
        for (int i = -5; i < 5; i++)
        {
            for (int j = -10; j < 10; j++)
            {
                Vector3Int pos = new Vector3Int(i, j, 0);
                
                if (_map.GetTile(pos) != null)
                    if (_map.GetTile(pos).name.Contains("Blue"))
                        return true;
            }
        }
        return false;
    }
    public bool GreenFinder()
    {
        for (int i = -5; i < 5; i++)
        {
            for (int j = -10; j < 10; j++)
            {
                Vector3Int pos = new Vector3Int(i, j, 0);
                
                if (_map.GetTile(pos) != null)
                    if (_map.GetTile(pos).name.Contains("Green"))
                        return true;
            }
        }
        return false;
    }
    public bool RedFinder()
    {
        for (int i = -5; i < 5; i++)
        {
            for (int j = -10; j < 10; j++)
            {
                Vector3Int pos = new Vector3Int(i, j, 0);
                
                if (_map.GetTile(pos) != null)
                    if (_map.GetTile(pos).name.Contains("Red"))
                        return true;
            }
        }
        return false;
    }
    public bool YellowFinder()
    {
        for (int i = -5; i < 5; i++)
        {
            for (int j = -10; j < 10; j++)
            {
                Vector3Int pos = new Vector3Int(i, j, 0);
                
                if (_map.GetTile(pos) != null)
                    if (_map.GetTile(pos).name.Contains("Yellow"))
                        return true;
            }
        }
        return false;
    }

}
