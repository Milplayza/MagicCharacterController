using UnityEngine;

namespace MagicCharacterControllerPackage
{

    public class GravityHandler : MonoBehaviour
    {
        [SerializeField]
        private float _gravity;

        [SerializeField]
        private float _minFallSpeed = -4f;

        [SerializeField]
        private MagicCharacterController _cC;

        [SerializeField]
        private GroundSensor _sensor;

        [SerializeField]
        private ClampingComponent _clamping;

        private float _fallspeed;

        public float Gravity { get => _gravity; set => _gravity = value; }
        public float Fallspeed { get => _fallspeed; 
            set {
                if (value < MinFallSpeed) {
                    _fallspeed = MinFallSpeed;
                }
                else
                {
                    if (value > 0) _clamping.Clamping = false;
                    _fallspeed = value;
                }
            } }

        public float MinFallSpeed { get => _minFallSpeed; set => _minFallSpeed = value; }

        private void FixedUpdate()
        {
            Ground ground = _sensor.Ground;

            if (_clamping.Clamping)
            {
                if(ground == null)
                {
                    _clamping.Clamping = false;
                }
            }
            else
            {
                Fallspeed -= Time.deltaTime * _gravity;
                if (ground != null && _sensor.IsOnGround(0.1f) && Fallspeed <= 0)
                {
                    _clamping.Clamping = true;
                    _fallspeed = 0;
                }
            }

            _cC.AddTempVelocity(transform.up * Fallspeed);
        }
    }
}

// By Milplayza (16. Mai 2023)
