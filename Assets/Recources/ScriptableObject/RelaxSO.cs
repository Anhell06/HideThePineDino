using UnityEngine;

[CreateAssetMenu]
public class RelaxSO : ScriptableObject
{
    private string text;
    private Result result;

    public Result Result { get => result; }
    public string Text { get => text; }
}
