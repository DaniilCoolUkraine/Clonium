using System;
using Clonium.Core.MapModel;
using UnityEngine;

namespace Clonium.Tiles
{
    public class Tile : MonoBehaviour
    {
        private Action<Dot> Clicked; 
        
        [SerializeField] private SpriteRenderer _backgroundHolder;
        [SerializeField] private SpriteRenderer _dotsHolder;

        private Dot _dot;
        
        public void Init(Dot dot, Sprite background, Sprite dotSprite)
        {
            _dot = dot;
            DrawTile(background, dotSprite);
            
#if UNITY_EDITOR
            ChangeTileName(_dot);
#endif
        }

        public void SetCallback(Action<Dot> callback)
        {
            Clicked = callback;
        }
        
        private void DrawTile(Sprite background, Sprite dotSprite)
        {
            _dotsHolder.gameObject.SetActive(dotSprite != null);
            _backgroundHolder.gameObject.SetActive(true);

            _backgroundHolder.sprite = background;
            _dotsHolder.sprite = dotSprite;
        }

        private void ChangeTileName(Dot dot)
        {
            gameObject.name = "Tile_" + (dot == null ? "Empty" : dot.ToString());
        }

        private void OnMouseUpAsButton()
        {
            Clicked?.Invoke(_dot);
        }
    }
}