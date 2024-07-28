using System.Text;
using UnityEngine;

namespace Clonium.Core.MapModel
{
    public class Dot
    {
        public DotColor DotColor { get; } 
        public Vector2Int Position { get; }
        public int Count { get; }

        public Dot(DotColor dotColor, Vector2Int position, int count)
        {
            DotColor = dotColor;
            Position = position;
            Count = count;
        }

        public Dot(Dot dot, int count)
        {
            DotColor = dot.DotColor;
            Position = dot.Position;
            Count = count;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(DotColor).Append(" ").Append(Count);
            return sb.ToString();
        }
    }
}