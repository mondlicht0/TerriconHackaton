using Project.Systems;
using UnityEngine;
using Zenject;

public class MainMenuSceneInstaller : MonoInstaller
{
    [SerializeField] private LevelManager _levelManager;
    
    public override void InstallBindings()
    {
        Container.Bind<LevelManager>().FromInstance(_levelManager).AsSingle();
    }
}
