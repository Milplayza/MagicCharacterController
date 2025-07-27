using UnityEngine;

namespace MagicCharacterControllerPackage
{
    public class InputMapper : MonoBehaviour
    {

        [SerializeField]
        private Transform _camera;

        /// <summary>
        /// The transform, the Inputs should be mapped on (e.g the player's transform)
        /// </summary>
        [SerializeField]
        private Transform _mappingTransform;



        /*
        private void OnDrawGizmos()
        {
            Vector3 forward = Vector3.ProjectOnPlane((_mappingTransform.position - _camera.position), _mappingTransform.up);
            forward = forward.normalized;

            Vector3 right = Vector3.Cross(_mappingTransform.up, forward);

            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + forward * 2f);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + right * 2f);
        }*/


        public Vector3 MapInput(Vector2 input)
        {
            Vector3 forward = Vector3.ProjectOnPlane((_mappingTransform.position - _camera.position), _mappingTransform.up);
            forward = forward.normalized;

            Vector3 right = Vector3.Cross(_mappingTransform.up, forward);

            return (forward * input.y + right * input.x);
        }

    }
}

// By Milplayza (3. Mai 2022)
