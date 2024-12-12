using SpaceShip.Scripts.Constants;
using SpaceShip.Scripts.Pool;
using UnityEngine;
using Zenject;

namespace SpaceShip.Scripts.Player
{
    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField] private Transform _firePoint;
        [SerializeField] private Transform _container;
        [SerializeField] private Projectile _projectilePrefab;

        private float _timer;
        private float _frequency;

        private ObjectPool _objectPool;

        [Inject]
        private void Constructor(ObjectPool objectPool)
        {
            _objectPool = objectPool;

            _objectPool.Container = _container;
        }

        private void Start()
        {
            _frequency = PlayerPrefs.GetFloat(PlayerPrefsKeys.ShootFreqyencyKey);
        }

        private void Update()
        {
            ApplyShooting();
        }

        private void ApplyShooting()
        {
            _timer += Time.deltaTime;

            if (_timer < _frequency) return;

            var projectile = _objectPool.GetObject(_projectilePrefab);
            projectile.transform.position = _firePoint.position;

            _timer = 0;
        }
    }
}