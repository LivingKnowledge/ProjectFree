using UnityEngine;
using System.Collections;

namespace SP_PhysicsUtils
{
    class PhysicsUtilities
    {
        public static float TimeToReachDistAtVel(float startpt, float endpt, float initvel)
        {
            return ((endpt - startpt) / initvel);
        }
    }
}
