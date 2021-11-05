using System;
using UnityEngine;

[Serializable]
public class Bar : Iplace
{
    
    private JokeCatalogSO jokeCatalog;
    private JokeSO[] joke = new JokeSO[3];
    public Bar()
    {
        jokeCatalog = Resources.Load<JokeCatalogSO>("ScriptableObject/ListJoke.asset");
    }
    public string[] GetTextForButton()
    {
        string[] stringsForButtton = new string[3];
        for (int i = 0; i < stringsForButtton.Length; i++)
        {
            stringsForButtton[i] = joke[i].Text;
        }
        return stringsForButtton;
    }

    public Result ResultRelaxing(int number)
    {
        Result resultTemp;
        resultTemp = joke[number].GetResult;
        joke = jokeCatalog.ReturnThreeRandomJoke();
        return resultTemp;
    }
}
