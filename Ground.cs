using UnityEngine;


namespace MagicCharacterControllerPackage
{
    public class Ground
    {
        private Vector3 _point = Vector3.zero;
        private Vector3 _normal = Vector3.zero;
        private float _distance = 0;
        private Collider _collider;
        private CollisionType _collisionType;

        public Vector3 Point { get => _point; set => _point = value; }
        public Vector3 Normal { get => _normal; set => _normal = value; }
        public Collider Collider { get => _collider; set => _collider = value; }

        public CollisionType CollisionType { get => _collisionType; set => _collisionType = value; }

        public float Distance
        {
            get => _distance;
            set
            {
                if (value < 0)
                {
                    _distance = 0;
                }
                else
                {
                    _distance = value;
                }
            }
        }



        public Ground(float distance, Vector3 point, Vector3 normal, Collider collider)
        {
            Distance = distance;
            Point = point;
            Normal = normal;
            Collider = collider;
        }
    }
}

// By Milplayza (20. März 2025)
