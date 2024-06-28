using UnityEngine;
using Zenject;

namespace Project.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private PlayerCamera _playerCamera;
        [SerializeField] private Transform _spawnPoint;
        
        public override void InstallBindings()
        {
            InstantiateAndInstallPlayer();
        }

        private void InstantiateAndInstallPlayer()
        {
            Player player = Instantiate(_playerPrefab, _spawnPoint.position, Quaternion.identity, null).GetComponent<Player>();
            Container.Bind<Player>().FromInstance(player).AsSingle().NonLazy();
        }
    }
}
