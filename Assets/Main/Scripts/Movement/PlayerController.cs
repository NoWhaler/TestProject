using UnityEngine;

namespace Main.Scripts.Movement
{
    public class PlayerController: MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotationSpeed;
        
        private JoystickController _joystickController;
        private CharacterController _characterController;

        private void Start()
        {
            _joystickController = FindObjectOfType<JoystickController>();
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            var joystickInput = _joystickController.InputDirection;

            var moveDirection = new Vector3(joystickInput.x, 0f, joystickInput.y).normalized;

            if (moveDirection == Vector3.zero) return;

            HandleRotation(moveDirection);

            _characterController.Move(moveDirection * _moveSpeed * Time.deltaTime);
        }

        private void HandleRotation(Vector3 moveDirection)
        {
            var targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
        }
    }
}