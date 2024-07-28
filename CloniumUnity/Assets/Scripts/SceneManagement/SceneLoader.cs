using UnityEngine.SceneManagement;

namespace Clonium.SceneManagement
{
    public static class SceneLoader
    {
        public static void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}