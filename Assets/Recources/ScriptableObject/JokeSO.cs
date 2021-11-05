using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu]
public class JokeSO : ScriptableObject
{
  private Result result;
    private string text;
    private string forPublic;

    public Result GetResult { get => result;}
    public string Text { get => text;}
}
