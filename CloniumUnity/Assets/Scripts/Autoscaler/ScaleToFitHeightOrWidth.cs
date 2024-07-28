
using Clonium.Core.General;
using UnityEngine;

namespace Clonium.Autoscaler
{
    public class ScaleToFitHeightOrWidth : MonoBehaviour
    {
        public void Fit(Vector2 dimensions)
        {
            float scale = Mathf.Min(GetScale(16, dimensions.x), GetScale(9, dimensions.y));
            float scaleWithSafeZone = scale * 0.9f;

            float offsetX = 0 - (dimensions.x / 2) * Constants.TILE_PER_UNIT * scaleWithSafeZone + Constants.TILE_PER_UNIT * scaleWithSafeZone / 2;
            float offsetY = 0 - (dimensions.y / 2) * Constants.TILE_PER_UNIT * scaleWithSafeZone + Constants.TILE_PER_UNIT * scaleWithSafeZone / 2;
            
            transform.localScale = new Vector3(scaleWithSafeZone, scaleWithSafeZone, 1);
            transform.localPosition = new Vector3(offsetX, offsetY, 0);
        }

        private float GetScale(int referenceSize, float dimension)
        {
            return referenceSize / (dimension * Camera.main.orthographicSize / 1.5f);
        }
    }
}