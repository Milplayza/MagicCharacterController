using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicCharacterControllerPackage
{
    public class RayGroundSensor : GroundSensor
    {
        private void FixedUpdate()
        {
            GroundCheck();
        }

        public override void GroundCheck()
        {
            _isOnDirectGround = false;
            Ground = null;
            Ray ray = new Ray(transform.position + transform.up * _eps, transform.up * -1);

            SimpleRaycast(ray);
        }
    }
}

// By Milplayza (16. Dez 2022)