using Main.Scripts.Movement;
using UnityEngine;

namespace Main.Scripts.Camera
{
    public class CameraController : MonoBehaviour
    {
        private PlayerController _target;
        
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _lookDownAngle;
        
        [SerializeField] private float wallCollisionRadius = 0.2f;

        private void Start()
        {
            _target = FindObjectOfType<PlayerController>();
            
            transform.rotation = Quaternion.Euler(_lookDownAngle, 0f, 0f);
        }

        private void LateUpdate()
        {
            var desiredPosition = _target.transform.position + _offset;

            var collisionAdjustedPosition = HandleCameraCollision(desiredPosition);

            transform.position = Vector3.Lerp(transform.position, collisionAdjustedPosition, Time.deltaTime * _rotationSpeed);
        }
        
        private Vector3 HandleCameraCollision(Vector3 desiredPosition)
        {
            var adjustedPosition = desiredPosition;

            if (Physics.Raycast(_target.transform.position, desiredPosition - _target.transform.position,
                    out var hit, _offset.magnitude))
            {
                adjustedPosition = hit.point + hit.normal * wallCollisionRadius;
            }

            return adjustedPosition;
        }
    }
}