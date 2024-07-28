using Clonium.Core;
using Clonium.Core.MapModel;
using UnityEngine;

namespace Clonium.DotsVisuals
{
    [System.Serializable]
    public class DotData
    {
        [field:SerializeField] public DotColor Color { get; private set; }
        [field:SerializeField] public int Count { get; private set; }
        [field:SerializeField] public Sprite Sprite { get; private set; }
    }
}