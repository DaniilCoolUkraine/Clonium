using System;
using System.Collections.Generic;
using Clonium.Core.General;
using UnityEngine;
using Logger = Clonium.Core.General.Logger;

namespace Clonium.Core.MapModel
{
    public class Map
    {
        public event Action MapUpdated; 

        private Dot[,] _dots;
        private bool _initialized;

        public Map(Vector2Int dimensions)
        {
            OnStart(dimensions);
        }

        public Vector2Int Dimensions => new Vector2Int(_dots.GetLength(Constants.ROWS_ID), _dots.GetLength(Constants.COLUMNS_ID));
        
        public void SetDots(IEnumerable<Dot> newDots)
        {
            if (!_initialized)
            {
                throw new Exception("Map isn't initialized! Aborting process...");
            }

            foreach (var dot in newDots)
            {
                if (dot != null)
                {
                    if (PositionIsValid(dot.Position))
                    {
                        _dots[dot.Position.x, dot.Position.y] = dot;
                    }
                }
            }

            for (int i = 0; i < _dots.GetLength(Constants.ROWS_ID); i++)
            {
                for (int j = 0; j < _dots.GetLength(Constants.COLUMNS_ID); j++)
                {
                    var dot = _dots[i, j];
                    if (dot?.Count >= 4)
                    {
                        _dots[dot.Position.x, dot.Position.y] = null;

                        var right = GetDot(i + 1, j);
                        var left = GetDot(i - 1, j);
                        var top = GetDot(i, j + 1);
                        var bottom = GetDot(i, j - 1);

                        Dot[] dotsExpansion =
                        {
                            new Dot(dot.DotColor, new Vector2Int(i + 1, j), right != null ? right.Count + 1 : 1),
                            new Dot(dot.DotColor, new Vector2Int(i - 1, j), left != null ? left.Count + 1 : 1),
                            new Dot(dot.DotColor, new Vector2Int(i, j + 1), top != null ? top.Count + 1 : 1),
                            new Dot(dot.DotColor, new Vector2Int(i, j - 1), bottom != null ? bottom.Count + 1 : 1)
                        };

                        SetDots(dotsExpansion);
                    }
                }
            }
            
            MapUpdated?.Invoke();
        }

        public Dot GetDot(int x, int y)
        {
            if (PositionIsValid(new Vector2Int(x, y)))
            {
                return _dots[x, y];
            }

            return null;
        }

        public IEnumerable<Dot> GetDots(DotColor color)
        {
            foreach (var dot in _dots)
            {
                if (dot != null)
                {
                    if (dot.DotColor == color)
                    {
                        yield return dot;
                    }
                }
            }
        }
        
        private void OnStart(Vector2Int dimensions)
        {
            Init(dimensions);
            SetDots(GetStartDots());
        }

        private void Init(Vector2Int dimensions)
        {
            if (dimensions.x <= 2 || dimensions.y <= 2)
            {
                throw new ArgumentException("Invalid dimensions passed! Aborting process...");
            }

            _dots = new Dot[dimensions.x, dimensions.y];

            _initialized = true;
        }

        private IEnumerable<Dot> GetStartDots()
        {
            yield return new Dot(DotColor.Blue, new Vector2Int(0, 0), 
                Constants.DEFAULT_DOTS_IN_TILE);
            yield return new Dot(DotColor.Green, new Vector2Int(_dots.GetLength(Constants.ROWS_ID) - 1, 0),
                Constants.DEFAULT_DOTS_IN_TILE);
            yield return new Dot(DotColor.Red, new Vector2Int(0, _dots.GetLength(Constants.COLUMNS_ID) - 1),
                Constants.DEFAULT_DOTS_IN_TILE);
            yield return new Dot(DotColor.Yellow, new Vector2Int(_dots.GetLength(Constants.ROWS_ID) - 1, _dots.GetLength(Constants.COLUMNS_ID) - 1),
                Constants.DEFAULT_DOTS_IN_TILE);
        }

        private bool PositionIsValid(Vector2Int position)
        {
            return position.x >= 0 && position.y >= 0 &&
                   position.x < _dots.GetLength(Constants.ROWS_ID) && 
                   position.y < _dots.GetLength(Constants.COLUMNS_ID);
        }
    }
}