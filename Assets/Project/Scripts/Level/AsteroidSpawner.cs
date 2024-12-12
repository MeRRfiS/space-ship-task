using SpaceShip.Scripts.Interfaces;
using SpaceShip.Scripts.Pool;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace SpaceShip.Scripts.Level
{
    public class AsteroidSpawner: MonoBehaviour
    {
        [SerializeField] private float _frequency = 1f;
        [SerializeField] private Transform _minSpawnPosition;
        [SerializeField] private Transform _maxSpawnPosition;
        [SerializeField] private Transform _container;
        [SerializeField] private Asteroid _asteroidPrefab;

        private float _timer;

        private ObjectPool _objectPool;

        [Inject]
        private void Constructor(ObjectPool objectPool)
        {
            _objectPool = objectPool;

            _objectPool.Container = _container;
        }

        public void SpawnAsteroid(UnityAction UpdateScore, UnityAction DestroyAsteroid)
        {
            _timer += Time.deltaTime;

            if (_timer < _frequency) return;

            var asteroid = _objectPool.GetObject(_asteroidPrefab);
            asteroid.transform.position = new Vector2(Random.Range(_minSpawnPosition.position.x, _maxSpawnPosition.position.x),
                                                      _minSpawnPosition.position.y);
            asteroid.OnDestroyAsteroid.AddListener(UpdateScore);
            asteroid.OnDestroyAsteroid.AddListener(DestroyAsteroid);

            _timer = 0f;
        }
    }
}