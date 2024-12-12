using SpaceShip.Scripts.Constants;
using SpaceShip.Scripts.Managers;
using SpaceShip.Scripts.Player;
using SpaceShip.Scripts.Pool;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SpaceShip.Scripts.Level
{
    public class Asteroid : Poolable
    {
        [SerializeField] private Image _asteroidImage;
        [SerializeField] private Sprite[] _asteroidSprites;
        [SerializeField] private Rigidbody2D _rigidbody;

        [HideInInspector] public UnityEvent OnDestroyAsteroid = new UnityEvent();

        private int _asteroidHealth = 2;
        private float _defaultDestroyTime = 10;

        private void OnEnable()
        {
            _asteroidImage.sprite = _asteroidSprites[Random.Range(0, _asteroidSprites.Length)];
            var speed = PlayerPrefs.GetFloat(PlayerPrefsKeys.AsteroidSpeedKey);
            _rigidbody.linearVelocity = -Vector2.up * speed;
            _destroyTime = _defaultDestroyTime - (float)((speed - 1.1f) * 3);

            StartCoroutine(DestroyObject());
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.TryGetComponent<PlayerHealth>(out PlayerHealth player)) return;

            player.TakeDamage();
            Reset();
        }

        public override void Reset()
        {
            _asteroidHealth = 2;
            OnDestroyAsteroid.RemoveAllListeners();
            base.Reset();
        }

        public void HitAsteroid()
        {
            _asteroidHealth--;

            if (_asteroidHealth > 0) return;

            OnDestroyAsteroid?.Invoke();
            Reset();
        }
    }
}