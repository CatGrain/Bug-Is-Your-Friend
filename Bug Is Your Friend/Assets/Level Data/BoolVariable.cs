using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[CreateAssetMenu]
public class BoolVariable : ScriptableObject,ISerializationCallbackReceiver
{
    [NonSerialized]
    public bool runtimeValue;

    public bool Value;

    

    void ISerializationCallbackReceiver.OnAfterDeserialize()
    {
        runtimeValue = Value;
    }

    void ISerializationCallbackReceiver.OnBeforeSerialize()
    {
        Value = runtimeValue;
    }
}
