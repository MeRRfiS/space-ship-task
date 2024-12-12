using SpaceShip.Scripts.Interfaces;
using SpaceShip.Scripts.Managers;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private SaveManager _saveManager;

    public override void InstallBindings()
    {
        BindSaveManager();
        BindGameManager();
        BindSceneLoader();
    }

    private void BindSaveManager()
    {
        Container.Bind<ISaveManager>()
                         .FromInstance(_saveManager)
                         .AsSingle();
    }

    private void BindSceneLoader()
    {
        Container.Bind<ISceneLoader>()
                         .FromInstance(_sceneLoader)
                         .AsSingle();
    }

    private void BindGameManager()
    {
        Container.Bind<IGameManager>()
                         .FromInstance(_gameManager)
                         .AsSingle();
    }
}
