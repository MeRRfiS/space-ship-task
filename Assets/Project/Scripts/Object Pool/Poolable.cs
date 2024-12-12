using SpaceShip.Scripts.Interfaces;
using System;
using System.Collections;
using UnityEngine;

namespace SpaceShip.Scripts.Pool
{
    public class Poolable : MonoBehaviour, IPoolable
    {
        [SerializeField] protected float _destroyTime;

        public GameObject GameObject => gameObject;

        public event Action<IPoolable> Destroyed;

        public virtual void Reset()
        {
            Destroyed?.Invoke(this);
        }

        protected IEnumerator DestroyObject()
        {
            yield return new WaitForSeconds(_destroyTime);

            Reset();
        }
    }
}