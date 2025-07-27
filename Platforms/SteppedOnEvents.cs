using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MagicCharacterControllerPackage
{
    public class SteppedOnEvents : MonoBehaviour
    {
        public UnityEvent<CharacterController> OnSteppedOn;
        public UnityEvent OnSteppedOff;
        public UnityEvent OnStaying;

    }
}

// By Milplayza (11. Aug. 2024)