using UnityEngine;

[CreateAssetMenu]
public class RelaxSO : ScriptableObject
{

    [SerializeField] private string text;
    [SerializeField] private Result result;

    public Result Result { get => result; }
    public string Text { get => text; }
}
