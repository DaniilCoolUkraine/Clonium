using System;
using Clonium.Core.MapModel;
using Clonium.DotsVisuals;
using UnityEngine;

namespace Clonium.Tiles
{
    public class TileMap : MonoBehaviour
    {
        public event Action<Dot> TileClicked;
        
        [SerializeField] private Tile _tilePrefab;
        [SerializeField] private Transform _tileParent;
        [SerializeField] private DotsVisualData _dotsVisualData;

        private Tile[,] _tiles;
        
        private Map _map;
        
        public void Init(Map map)
        {
            _map = map;
            _map.MapUpdated += DrawMap;
            
            _tiles = new Tile[_map.Dimensions.x, _map.Dimensions.y];

            DrawMap();
        }
        
        public void Dispose()
        {
            _map.MapUpdated -= DrawMap;
        }

        private void DrawMap()
        {
            for (int i = 0; i < _map.Dimensions.x; i++)
            {
                for (int j = 0; j < _map.Dimensions.y; j++)
                {
                    var dot = _map.GetDot(i, j);
                    var tile = _tiles[i, j];

                    Sprite dotSprite = null;
                    if (dot != null)
                    {
                        dotSprite = _dotsVisualData.DotToSprite(dot);
                    }

                    if (tile == null)
                    {
                        tile = Instantiate(_tilePrefab, _tileParent);
                        _tiles[i, j] = tile;
                    }

                    tile.Init(dot, _dotsVisualData.GetEmptyTile(), dotSprite);
                    tile.SetCallback(OnTileClicked);
                    tile.transform.localPosition = TileUtils.TileToWorldPosition(i, j);
                }
            }
        }

        private void OnTileClicked(Dot dot)
        {
            TileClicked?.Invoke(dot);
        }
    }
}