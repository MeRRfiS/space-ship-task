using SpaceShip.Scripts.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShip.Scripts.Pool
{
    public class PoolTask
    {
        private readonly Transform _container;
        private readonly List<IPoolable> _freeObjects;
        private readonly List<IPoolable> _objectsInUse;

        public PoolTask(Transform container)
        {
            _container = container;
            _freeObjects = new List<IPoolable>();
            _objectsInUse = new List<IPoolable>();
        }

        public T GetFreeObejct<T>(T prefab) where T: Component, IPoolable
        {
            T poolable;
            if(_freeObjects.Count > 0)
            {
                poolable = _freeObjects[0] as T;
                _freeObjects.RemoveAt(0);
            }
            else
            {
                poolable = Object.Instantiate(prefab, _container);
            }

            poolable.Destroyed += ReturnToPool;
            poolable.GameObject.SetActive(true);
            poolable.GameObject.transform.localScale = Vector2.one;
            _objectsInUse.Add(poolable);

            return poolable;
        }

        private void ReturnToPool(IPoolable poolable)
        {
            _objectsInUse.Remove(poolable);
            _freeObjects.Add(poolable);
            poolable.Destroyed -= ReturnToPool;
            poolable.GameObject.SetActive(false);
        }
    }
}