using UnityEngine;

namespace SpaceShip.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 2.5f;
        private Vector2 _moveInput;

        private void Update()
        {
            ApplyMovement();
        }

        private void ApplyMovement()
        {
            Vector3 movement = new Vector2(_moveInput.x, _moveInput.y) * _speed * Time.deltaTime;
            Vector2 newPosition = transform.position + movement;

            Vector3 screenBounds = Camera.main.WorldToViewportPoint(newPosition);
            screenBounds.x = Mathf.Clamp(screenBounds.x, 0f, 1f);
            screenBounds.y = Mathf.Clamp(screenBounds.y, 0f, 1f);
            newPosition = Camera.main.ViewportToWorldPoint(screenBounds);

            transform.position = newPosition;
        }

        public void OnMove(Vector2 value)
        {
            _moveInput = value;
        }
    }
}