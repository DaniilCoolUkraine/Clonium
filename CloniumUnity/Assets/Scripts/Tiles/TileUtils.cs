using Clonium.Core.General;
using UnityEngine;

namespace Clonium.Tiles
{
    public static class TileUtils
    {
        public static Vector3 TileToWorldPosition(int x, int y)
        {
            return new Vector3(x * Constants.TILE_PER_UNIT, y * Constants.TILE_PER_UNIT, 0);
        }
    }
}