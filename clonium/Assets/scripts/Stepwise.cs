using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Stepwise : MonoBehaviour
{
    
    private MapManager _tile;

    //field to place dots
    private Tilemap _map;
    
    //clicked tile on grid
    private TileBase _clickedBackgroundTile;
    
    //clicked tile on field
    private TileBase _clickedForegroundTile;
    
    //num of steps
    short _stepNum = 0;
    
    //indicate color of player
    [SerializeField]
    private Image _stepColor;

    void Start()
    {
        //initial color set
        _stepColor.color = Color.cyan;
        
        //get component from gameController
        _tile = gameObject.GetComponent<MapManager>();
        
        //get map from map manager
        _map = _tile.GetMap();
    }
    
    void Update()
    {
        //get Back tile from map manager
        _clickedBackgroundTile = _tile.GetBackTile();
        //get Front tile from map manager
        _clickedForegroundTile = _tile.GetFrontTile();
        
        /*
         * TODO
         * here is beautiful decision showed in this video https://youtu.be/rHRbBXWT3Kc
         */

        if (_clickedBackgroundTile == null)
            return;
        if (_clickedForegroundTile == null)
            return;

        //blue step
        if (_stepNum == 0)
        {
            if (BlueFinder())
            {
                _stepColor.color = Color.cyan;
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
        //green step
        else if (_stepNum == 1)
        {
            if (GreenFinder())
            {
                _stepColor.color = Color.green;
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
        //red step
        else if (_stepNum == 2)
        {
            if (RedFinder())
            {
                _stepColor.color = Color.red;
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
        //yellow step
        else if (_stepNum == 3)
        {
            if (YellowFinder())
            {
                _stepColor.color = Color.yellow;
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
        else 
            _stepNum = 0;
    }

    /*
     * here is functions to check if there is color on a field
     */
    public bool BlueFinder()
    {
        for (int i = -5; i < 5; i++)
        {
            for (int j = -10; j < 10; j++)
            {
                Vector3Int pos = new Vector3Int(i, j, 0);
                
                if (_map.GetTile(pos) != null)
                    if (_map.GetTile(pos).name.Contains("Blue"))
                        //return true if found and stop 
                        return true;                       
            }
        }
        //return false if not found
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
