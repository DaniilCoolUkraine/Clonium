using System.Linq;
using Clonium.Core;
using Clonium.Core.MapModel;
using UnityEngine;

namespace Clonium.DotsVisuals
{
    [CreateAssetMenu(fileName = "DotsVisuals", menuName = "Config/DotsVisuals", order = 0)]
    public class DotsVisualData : ScriptableObject
    {
        [SerializeField] private DotData[] _dotsVisualsData;
        [SerializeField] private Sprite _emptyTile;

        public Sprite DotToSprite(Dot dot)
        {
            return _dotsVisualsData.FirstOrDefault(v => v.Color == dot.DotColor && v.Count == dot.Count)?.Sprite;
        }

        public Sprite GetEmptyTile()
        {
            return _emptyTile;
        }
    }
}