using UnityEngine;


namespace MagicCharacterControllerPackage
{
    abstract public class GroundSensor : MonoBehaviour
    {
        [SerializeField]
        protected LayerMask _mask;

        [SerializeField]
        protected float _radius;

        [SerializeField]
        protected float _length;

        [SerializeField]
        private float maxAngle = 80f;

        [SerializeField]
        protected bool _demandDirectGround;
        protected bool _isOnDirectGround;


        protected Ground _ground = null;
        public Ground Ground { get => _ground; set => _ground = value; }
        public float MaxAngle { get => maxAngle;}

        protected static float _eps = 0.0415f;

        public abstract void GroundCheck();

        protected void SimpleRaycast(Ray ray)
        {
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, _radius + _length, _mask, QueryTriggerInteraction.Ignore))
            {
                if (TooSloped(hit)) return;

                float distance = hit.distance - _radius - _eps;
                if (distance < 0) distance = 0;
                Ground = new Ground(distance, hit.point, hit.normal, hit.collider);
                _isOnDirectGround = true;
            }
        }

        public bool IsOnGround(float groundedDistance)
        {
            return (Ground != null && Ground.Distance < groundedDistance && DirectGroundEvaluation());
        }

        private bool DirectGroundEvaluation()
        {
            return (!_demandDirectGround || _isOnDirectGround);
        }

        protected bool TooSloped(RaycastHit hit)
        {
            float slopeAngle = Vector3.Angle(transform.up, hit.normal);
            CollisionType coltype = hit.collider.GetComponent<CollisionType>();
            bool colTypeAngleCheck = false;
            if (coltype != null) colTypeAngleCheck = slopeAngle >= coltype.GroundAngle;

            return slopeAngle >= MaxAngle || colTypeAngleCheck;
        }
    }
}

// By Milplayza (20. März 2025)
