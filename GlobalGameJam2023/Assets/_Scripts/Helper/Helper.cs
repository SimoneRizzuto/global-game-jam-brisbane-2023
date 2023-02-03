using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    
    public static Vector2 DiagonalOff(Vector2 _v2)
    {
        if (Mathf.Abs(_v2.x) > 0.5 && Mathf.Abs(_v2.y)  > 0.5)
        {
            _v2.y = 0;
        }
        return new Vector2(_v2.x, _v2.y);
    }

}
