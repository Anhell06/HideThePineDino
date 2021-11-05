using UnityEngine;

[CreateAssetMenu]
public class JokeSO : ScriptableObject
{
  private Result result;
    private string text;
    private string forPublic;

    public Result GetResult { get => result;}
    public string Text { get => text;}
}
