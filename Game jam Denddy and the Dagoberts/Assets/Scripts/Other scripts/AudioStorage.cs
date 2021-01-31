using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class AudioStorage : MonoBehaviour
{

    private static AudioStorage _i;

    public static AudioStorage i
    {
        get
        {
            if (_i == null)
            {
                _i = Instantiate(Resources.Load<AudioStorage>("AudioStorage"));
            }
            return _i;
        }
    }

}
