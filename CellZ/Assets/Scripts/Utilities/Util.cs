using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    public class UtilsClass : MonoBehaviour
    {
        public static float GetAngleFromVector(Vector3 dir)
        {
            dir = dir.normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            if (angle < 0)
            {
                angle += -90;
            }
            else
            {
                angle -= 90;
            }

            return angle;
        }
    }
}
