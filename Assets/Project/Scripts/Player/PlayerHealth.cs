using UnityEngine;
using UnityEngine.Events;

namespace SpaceShip.Scripts.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private UnityEvent<int> OnTakeDamage;
        [SerializeField] private UnityEvent OnPlayerDead;

        private int _health = 3;

        public void TakeDamage()
        {
            _health--;
            OnTakeDamage?.Invoke(_health);

            if(_health <= 0)
            {
                OnPlayerDead?.Invoke();
            }
        }
    }
}