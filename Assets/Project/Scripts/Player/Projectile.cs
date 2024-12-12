using SpaceShip.Scripts.Interfaces;
using SpaceShip.Scripts.Level;
using SpaceShip.Scripts.Pool;
using System;
using System.Collections;
using UnityEngine;

namespace SpaceShip.Scripts.Player
{
    public class Projectile : Poolable
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private Rigidbody2D _rigidbody;

        private void OnEnable()
        {
            _rigidbody.linearVelocity = Vector2.up * _speed;

            StartCoroutine(DestroyObject());
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.TryGetComponent<Asteroid>(out Asteroid stone)) return;

            stone.HitAsteroid();
            Reset();
        }
    }
}