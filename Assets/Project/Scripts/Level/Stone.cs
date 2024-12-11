using SpaceShip.Scripts.Interfaces;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShip.Scripts.Level
{
    public class Stone : MonoBehaviour, IPoolable
    {
        [SerializeField] private float _destroyTime = 7f;
        [SerializeField] private float _speed = 2.5f;
        [SerializeField] private Image _stoneImage;
        [SerializeField] private Sprite[] _stoneSprites;
        [SerializeField] private Rigidbody2D _rigidbody;

        public event Action<IPoolable> Destroyed;

        public GameObject GameObject => gameObject;

        private void OnEnable()
        {
            _stoneImage.sprite = _stoneSprites[UnityEngine.Random.Range(0, _stoneSprites.Length)];
            _rigidbody.linearVelocity = -Vector2.up * _speed;

            StartCoroutine(DestroyStone());
        }

        public void Reset()
        {
            Destroyed?.Invoke(this);
        }

        private IEnumerator DestroyStone()
        {
            yield return new WaitForSeconds(_destroyTime);

            Reset();
        }
    }
}