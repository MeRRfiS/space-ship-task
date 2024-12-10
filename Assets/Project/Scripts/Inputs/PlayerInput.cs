using UnityEngine;
using UnityEngine.Events;

namespace SpaceShip.Scripts.Input
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private UnityEvent<Vector2> OnMove;

        private PlayerInputAction _input;

        private void Start()
        {
            _input = new PlayerInputAction();

            _input.Ship.Move.performed += x => HandleMove(x.ReadValue<Vector2>());
            _input.Ship.Move.canceled += x => HandleMove(Vector2.zero);

            _input.Enable();
        }

        private void HandleMove(Vector2 value)
        {
            OnMove?.Invoke(value);
        }

        private void OnDisable()
        {
            _input.Ship.Move.performed -= x => HandleMove(x.ReadValue<Vector2>());
            _input.Ship.Move.canceled -= x => HandleMove(Vector2.zero);

            _input.Disable();
        }
    }
}