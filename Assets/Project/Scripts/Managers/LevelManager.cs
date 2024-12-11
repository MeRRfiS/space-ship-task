using SpaceShip.Scripts.Level;
using SpaceShip.Scripts.Pool;
using UnityEngine;
using Zenject;

namespace SpaceShip.Scripts.Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private float _frequency = 1f;
        [SerializeField] private Transform _minSpawnPosition;
        [SerializeField] private Transform _maxSpawnPosition;
        [SerializeField] private Transform _container;
        [SerializeField] private Stone _stonePrefab;

        private float _timer;

        private ObjectPool _objectPool;

        [Inject]
        private void Constructor(ObjectPool objectPool)
        {
            _objectPool = objectPool;

            _objectPool.Container = _container;
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer < _frequency) return;

            var stone = _objectPool.GetObject(_stonePrefab);
            stone.transform.position = new Vector2(Random.Range(_minSpawnPosition.position.x, _maxSpawnPosition.position.x),
                                                   _minSpawnPosition.position.y);

            _timer = 0f;
        }
    }
}