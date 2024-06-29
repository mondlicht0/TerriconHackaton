using Project.Controls;
using UnityEngine;
using Zenject;

namespace Project.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private InputHandler _inputHandlerPrefab;
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private PlayerCamera _playerCamera;
        [SerializeField] private Transform _spawnPoint;
        
        public override void InstallBindings()
        {
            InstantiateAndInstallPlayer();
            InstallInput();
        }

        private void InstantiateAndInstallPlayer()
        {
            //Player player = Instantiate(_playerPrefab, _spawnPoint.position, Quaternion.identity, null).GetComponent<Player>();
            Container.Bind<Player>().FromInstance(_playerPrefab).AsSingle().NonLazy();
        }

        private void InstallInput()
        {
            InputHandler inputHandler = Instantiate(_inputHandlerPrefab);
            Container.Bind<InputHandler>().FromInstance(inputHandler).AsSingle().NonLazy();;
        }
    }
}
