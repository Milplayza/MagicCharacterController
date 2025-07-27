using UnityEngine;



namespace MagicCharacterControllerPackage
{
    public class MagicCharacterController : MonoBehaviour
    {

        [SerializeField]
        private Rigidbody _rb;

        private Vector3 _velocity;
        private Vector3 _tempVelocity;

        public Vector3 Velocity { get => _velocity; set => _velocity = value; }
        public Rigidbody Rb { get => _rb; set => _rb = value; }

        private void FixedUpdate()
        {
            _rb.velocity = _velocity + _tempVelocity;
            _tempVelocity = Vector3.zero;
        }

        public void AddTempVelocity(Vector3 velocity)
        {
            _tempVelocity += velocity;
        }
    }
}

// By Milplayza (3. Mai 2022) updated 20.03.2025
