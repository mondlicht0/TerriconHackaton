using UnityEngine;
using Zenject;
using Project.Systems;

namespace Project.DI
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private LevelManager _levelManager;
        [SerializeField] private Timer _timer;
        
        public override void InstallBindings()
        {
            Container.Bind<GameManager>().FromInstance(_gameManager).AsSingle();
            Container.Bind<LevelManager>().FromInstance(_levelManager).AsSingle();
            Container.Bind<Timer>().FromInstance(_timer).AsSingle();
        }
    }
}
