using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicCharacterControllerPackage {
    public class PlatformSticker : MonoBehaviour
    {
        private Vector3 _platformPos;
        private Quaternion _fixedstepRotation;
        private Ground _oldGround;

        private Vector3 _dragVector;

        private Quaternion _deltaRotation;


        [SerializeField]
        private MagicCharacterController _Cc;

        [SerializeField]
        private GroundSensor _sensor;


        [SerializeField]
        private float _drag = 1;

        [SerializeField]
        private Transform _rotateWithPlatform;

        public Quaternion DeltaRotation { get => _deltaRotation;}

        private void FixedUpdate()
        {
            Ground newGround = _sensor.Ground;

            if (newGround != null)
            {
                if (_oldGround != null && newGround.Collider == _oldGround.Collider && _sensor.IsOnGround(0.05f))
                {
                    FixedStepSameGround(newGround);
                }
                else
                {
                    _platformPos = newGround.Collider.transform.position;
                    _fixedstepRotation = newGround.Collider.transform.rotation;
                }
            }
            else
            {
                _deltaRotation = Quaternion.identity;
                _dragVector = Vector3.MoveTowards(_dragVector, Vector3.zero, _drag * Time.deltaTime);
            }

            _Cc.AddTempVelocity(_dragVector);
            _oldGround = newGround;
        }

        private void FixedStepSameGround(Ground g)
        {
            Vector3 n = g.Collider.transform.position;
            Quaternion q = g.Collider.transform.rotation;

            // calculate delta Rotation and delta Vector for rotation
            _deltaRotation = q * Quaternion.Inverse(_fixedstepRotation);
            Vector3 relativePlayerVector = transform.position - n;
            Vector3 newRelativePlayerVector = _deltaRotation * relativePlayerVector;

            //Assign dragVector
            if(Time.deltaTime != 0f)
            {
                _dragVector = (n - _platformPos + newRelativePlayerVector - relativePlayerVector) / Time.deltaTime;
            }

            //Rotate on Platform
            if(_rotateWithPlatform != null)
                _rotateWithPlatform.rotation *= _deltaRotation;

            // Update Pos and Rotation
            _platformPos = n;
            _fixedstepRotation = q;
        }
    }
}

// By Milplayza (17. Dez 2022)
