using SpaceShip.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShip.Scripts.Managers
{
    public class SceneLoader : MonoBehaviour, ISceneLoader
    {
        public void OpenScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}