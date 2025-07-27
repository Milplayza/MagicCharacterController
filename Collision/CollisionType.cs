using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicCharacterControllerPackage
{
    public class CollisionType : MonoBehaviour
    {
        [SerializeField]
        /// <summary>
        /// maximum angle at which a polygon is considered Ground.
        /// </summary>
        private float _groundAngle = 90f;

        public float GroundAngle { get => _groundAngle; set => _groundAngle = value; }
    }
}


// By Milplayza (20. März 2025)
