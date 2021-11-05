using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class RelaxSO : ScriptableObject
{
    private string text;
    private Result result;

    public Result Result { get => result; }
}
