using System;
using UnityEngine;

namespace SpaceShip.Scripts.Interfaces
{
    public interface IPoolable
    {
        public event Action<IPoolable> Destroyed;
        public GameObject GameObject { get; }
        public void Reset();
    }
}