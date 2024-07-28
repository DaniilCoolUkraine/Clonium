using System.Collections.Generic;
using Clonium.Autoplayer;
using Clonium.Autoscaler;
using Clonium.Core.MapModel;
using Clonium.Tiles;
using UnityEngine;

namespace Clonium
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private TileMap _tileMap;
        [SerializeField] private Vector2Int _dimensions;
        [SerializeField] private ScaleToFitHeightOrWidth _scaler;

        private Map _map;
        private TurnManager _turnManager;
        private BotManager _botManager;

        private void Start()
        {
            _map = new Map(_dimensions);
            _map.MapUpdated += UpdateExistingColors;
            
            _turnManager = new TurnManager();
            _botManager = new BotManager(_turnManager, _map, new[] { DotColor.Green, DotColor.Red, DotColor.Yellow });

            _tileMap.Init(_map);
            _tileMap.TileClicked += OnTileClicked;
            
            _scaler.Fit(_dimensions);
        }

        private void OnDestroy()
        {
            _map.MapUpdated -= UpdateExistingColors;
            _tileMap.TileClicked -= OnTileClicked;

            _tileMap.Dispose();
            _botManager.Dispose();
        }
        
        private void UpdateExistingColors()
        {
            _turnManager.UpdateExistingColors(GetExistingColors());
        }

        private IEnumerable<DotColor> GetExistingColors()
        {
            var existingColors = new List<DotColor>();

            for (int i = 0; i < _map.Dimensions.x; i++)
            {
                for (int j = 0; j < _map.Dimensions.y; j++)
                {
                    var dot = _map.GetDot(i, j);

                    if (dot == null)
                    {
                        continue;
                    }

                    if (!existingColors.Contains(dot.DotColor))
                    {
                        existingColors.Add(dot.DotColor);
                    }
                }
            }

            return existingColors;
        }
        
        private void OnTileClicked(Dot dot)
        {
            if (dot != null && _turnManager.CanBeClicked(dot))
            {
                _map.SetDots(new[] { new Dot(dot, dot.Count + 1) });
                _turnManager.UpdateTurn();
            }
        }
    }
}