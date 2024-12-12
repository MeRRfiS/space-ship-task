using SpaceShip.Scripts.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShip.Scripts.Pool
{
    public class ObjectPool
    {
        private readonly Dictionary<Component, PoolTask> _activePoolTask;

        public Transform Container { private get; set; }

        public ObjectPool()
        {
            _activePoolTask = new Dictionary<Component, PoolTask>();
        }

        public T GetObject<T> (T prefab) where T: Component, IPoolable
        {
            if(!_activePoolTask.TryGetValue(prefab, out var poolTask))
            {
                AddTaskToPool(prefab, out poolTask);
            }

            return poolTask.GetFreeObejct(prefab);
        }

        private void AddTaskToPool<T>(T prefab, out PoolTask poolTask) where T : Component, IPoolable
        {
            poolTask = new PoolTask(Container);
            _activePoolTask.Add(prefab, poolTask);
        }
    }
}