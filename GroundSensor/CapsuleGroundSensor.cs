using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicCharacterControllerPackage
{
    public class CapsuleGroundSensor : GroundSensor
    {
        #region FieldsForVisualization

        private Vector3 prev;

        #endregion


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

            //Spherecast
            RaycastHit hit;
            if (Physics.SphereCast(ray, _radius, out hit, _length + _eps, _mask, QueryTriggerInteraction.Ignore))
            {
                if (TooSloped(hit))
                {
                    return;
                }

                Ground = new Ground(hit.distance - _eps, hit.point, hit.normal, hit.collider);
                Ray simpleRay = new Ray(hit.point + transform.up * _eps, transform.up * -1);
                if (Physics.Raycast(simpleRay, out hit, _eps * 2f, _mask, QueryTriggerInteraction.Ignore))
                {
                    Ground.Normal = hit.normal;
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(prev, _radius);

            if (Ground != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(Ground.Point, Ground.Point + transform.up * Ground.Distance);
                Gizmos.DrawLine(Ground.Point, Ground.Point + Ground.Normal);
            }
        }
    }
}

// By Milplayza (20. März 2025)

/*
namespace MagicCharacterControllerPackage
{
    public class CapsuleGroundSensor : GroundSensor
    {
        #region FieldsForVisualization

        private Vector3 prev;

        #endregion


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

            //Spherecast
            RaycastHit hit;
            if (Physics.SphereCast(ray, _radius, out hit, _length + _eps, _mask, QueryTriggerInteraction.Ignore))
            {
                if (TooSloped(hit)) return;

                Ground = new Ground(hit.distance - _eps, hit.point, hit.normal, hit.collider);
                Ray simpleRay = new Ray(hit.point + transform.up * _eps, transform.up * -1);
                if (Physics.Raycast(simpleRay, out hit, _eps * 2f, _mask, QueryTriggerInteraction.Ignore))
                {
                    Ground.Normal = hit.normal;
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(prev, _radius);

            if (Ground != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(Ground.Point, Ground.Point + transform.up * Ground.Distance);
                Gizmos.DrawLine(Ground.Point, Ground.Point + Ground.Normal);
            }
        }
    }
}*/