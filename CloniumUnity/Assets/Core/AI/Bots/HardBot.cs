using System;
using Clonium.Core.AI.Decisions;
using Clonium.Core.General;
using Clonium.Core.MapModel;

namespace Clonium.Core.AI.Bots
{
    public class HardBot: Bot
    {
        private int[,] _tileRatings;
        
        public HardBot(DotColor dotColor) : base(dotColor)
        {
        }

        public override Decision RequestDecision(Map map)
        {
            _tileRatings = new int[map.Dimensions.x, map.Dimensions.y];

            ResetRatings();
            EvaluateTiles(map);
            var maxRate = _tileRatings.Max();
            
            Dot dot = map.GetDot(maxRate.row, maxRate.col);
            var newDot = new Dot(dot, dot.Count + 1);

            return new Decision(newDot);
        }

        private void ResetRatings()
        {
            for (int i = 0; i < _tileRatings.GetLength(Constants.ROWS_ID); i++)
            {
                for (int j = 0; j < _tileRatings.GetLength(Constants.COLUMNS_ID); j++)
                {
                    _tileRatings[i, j] = Int32.MinValue;
                }
            }
        }

        private void EvaluateTiles(Map map)
        {
            for (int i = 0; i < _tileRatings.GetLength(Constants.ROWS_ID); i++)
            {
                for (int j = 0; j < _tileRatings.GetLength(Constants.COLUMNS_ID); j++)
                {
                    var middle = map.GetDot(i, j);

                    if (middle != null)
                    {
                        if (middle.DotColor == BotColor)
                        {
                            _tileRatings[i, j] = middle.Count;
                            
                            var right = map.GetDot(i + 1, j);
                            var left = map.GetDot(i - 1, j);
                            var top = map.GetDot(i, j + 1);
                            var bottom = map.GetDot(i, j - 1);
                            
                            _tileRatings[i, j] += GetTileRate(right, middle);
                            _tileRatings[i, j] += GetTileRate(left, middle);
                            _tileRatings[i, j] += GetTileRate(top, middle);
                            _tileRatings[i, j] += GetTileRate(bottom, middle);
                        }
                    }
                }
            }
        }
        
        private int GetTileRate(Dot sideDot, Dot middleDot)
        {
            if (sideDot == null)
            {
                return 0;
            }

            if (sideDot.DotColor == BotColor)
            {
                return sideDot.Count;
            }

            if (sideDot.Count > middleDot.Count)
            {
                return -sideDot.Count;
            }
            else
            {
                return sideDot.Count;
            }
        }
    }
}