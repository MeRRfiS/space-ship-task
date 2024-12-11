using SpaceShip.Scripts.Pool;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindObjectPool();
    }

    private void BindObjectPool()
    {
        Container.Bind<ObjectPool>().AsSingle();
    }
}