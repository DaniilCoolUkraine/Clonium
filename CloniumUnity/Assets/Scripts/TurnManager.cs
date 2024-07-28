using System;
using System.Collections.Generic;
using System.Linq;
using Clonium.Core.General;
using Clonium.Core.MapModel;

namespace Clonium
{
    public class TurnManager
    {
        public event Action<DotColor> TurnUpdated;

        private int _currentTurn;
        private List<DotColor> _existingColors;

        public TurnManager()
        {
            _currentTurn = 0;
            _existingColors = new List<DotColor>() { DotColor.Blue, DotColor.Green, DotColor.Red, DotColor.Yellow };
        }

        public bool CanBeClicked(Dot dot)
        {
            if (dot == null)
            {
                return false;
            }

            return dot.DotColor == _existingColors[_currentTurn];
        }

        public void UpdateTurn()
        {
            _currentTurn = (_currentTurn + 1) % _existingColors.Count;
            var currentColor = _existingColors[_currentTurn];
            Logger.Log(nameof(TurnManager), $"{currentColor}");

            TurnUpdated?.Invoke(currentColor);
        }

        public void UpdateExistingColors(IEnumerable<DotColor> existingColors)
        {
            int oldCount = _existingColors.Count;
            _existingColors = _existingColors.Intersect(existingColors).ToList();
            int newCount = _existingColors.Count;

            if (oldCount != newCount)
            {
                UpdateTurn();
            }
        }
    }
}