using SpaceShip.Scripts.Constants;
using SpaceShip.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SpaceShip.Scripts.UI
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private GameObject _gameUI;
        [SerializeField] private Button _exitToMenu;

        [Header("Win Panel")]
        [SerializeField] private GameObject _winPanel;
        [SerializeField] private Button _playNext;
        [SerializeField] private Button _exitWinButton;

        [Header("Lose Panel")]
        [SerializeField] private GameObject _losePanel;
        [SerializeField] private Button _playAgain;
        [SerializeField] private Button _exitLoseButton;

        private IGameManager _gameManager;
        private ISceneLoader _sceneLoader;

        [Inject]
        private void Constructor(IGameManager gameManager,
                                 ISceneLoader sceneLoader)
        {
            _gameManager = gameManager;
            _sceneLoader = sceneLoader;
        }

        private void Start()
        {
            _exitToMenu.onClick.AddListener(ExitFromLevel);

            _playNext.onClick.AddListener(_gameManager.NextLevel);
            _playNext.onClick.AddListener(_sceneLoader.ReloadScene);
            _exitWinButton.onClick.AddListener(ExitFromLevel);

            _playAgain.onClick.AddListener(_sceneLoader.ReloadScene);
            _exitLoseButton.onClick.AddListener(ExitFromLevel);
        }

        public void OpenWinPanel()
        {
            _gameUI.SetActive(false);
            _winPanel.SetActive(true);
        }

        public void OpenLosePanel()
        {
            _gameUI.SetActive(false);
            _losePanel.SetActive(true);
        }

        private void ExitFromLevel()
        {
            _sceneLoader.OpenScene(SceneNames.MenuScene);
        }
    }
}