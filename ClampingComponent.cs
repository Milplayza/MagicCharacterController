using System.Collections;
using UnityEngine;


namespace MagicCharacterControllerPackage
{
    public class ClampingComponent : MonoBehaviour
    {
        private bool _clamping;
        private const float _minClampDistace = 0.01f;
        private Vector3 _deltaMovement;

        [SerializeField]
        private MagicCharacterController _characterController;

        [SerializeField]
        private GroundSensor _sensor;
        [SerializeField]
        private Rigidbody _rb;

        public bool Clamping { get => _clamping; set => _clamping = value; }


        private void Awake()
        {
            Clamping = true;
            _rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (_sensor.Ground != null && Clamping)
            {
                if (Clamping) DoClamp();
            }

            RemoveDeltaMovementAfterFixedUpdate();
        }

        private void DoClamp()
        {
            if (Time.deltaTime != 0 && _sensor.Ground.Distance > _minClampDistace)
            {
                _deltaMovement = (-1f * transform.up * (_sensor.Ground.Distance - _minClampDistace) / Time.deltaTime);
                _characterController.AddTempVelocity(_deltaMovement);
            }
        }

        private IEnumerator RemoveDeltaMovementAfterFixedUpdate()
        {
            yield return new WaitForFixedUpdate();
            _rb.velocity -= _deltaMovement;
            yield return null;
        }
    }
}

// By Milplayza (3. Mai 2022)