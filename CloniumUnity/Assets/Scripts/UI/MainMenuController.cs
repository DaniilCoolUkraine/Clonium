using System;
using Clonium.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace Clonium.UI
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private Button _singlePlayerGame;

        private void OnEnable()
        {
            _singlePlayerGame.onClick.AddListener(LoadSinglePlayerScene);
        }

        private void OnDisable()
        {
            _singlePlayerGame.onClick.RemoveListener(LoadSinglePlayerScene);
        }

        private void LoadSinglePlayerScene()
        {
            SceneLoader.LoadScene(SceneNames.SINGLE_PLAYER_SCENE);
        }
    }
}