using UnityEngine;


[CreateAssetMenu]
public class JokeSO : ScriptableObject
{
    [SerializeField] private Result result;
    [SerializeField] private string text;
    [SerializeField] private string forPublic;

    public Result GetResult { get => result;}
    public string Text { get => text;}
}
