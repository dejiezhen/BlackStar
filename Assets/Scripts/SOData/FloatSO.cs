using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatSO : ScriptableObject
{
    // Credits to https://www.youtube.com/watch?v=MBM_4zrQHao
    [SerializeField]
    private float _value;

    public float Value
    {
        get { return _value; }
        set { _value = value; }
    }

}
