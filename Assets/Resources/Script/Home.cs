using System;
using UnityEngine;

[Serializable]
public class Home : Iplace
{
    private RelaxCatalogSO relaxCatalog;
    private RelaxSO[] relax = new RelaxSO[3];
    public Home()
    {
        relaxCatalog = Resources.Load<RelaxCatalogSO>("ScriptableObject/RelaxList");
        relax = relaxCatalog.ReturnThreeRandomRelax();
    }
    public string[] GetTextForButton()
    {
        string[] stringsForButton = new string[3];

        for (int i = 0; i < stringsForButton.Length; i++)
        {
            stringsForButton[i] = relax[i].Text;
        }

        return stringsForButton;
    }

    public Result ResultRelaxing(int number)
    {
        Result resultTemp;
        resultTemp = relax[number].Result;
        relax = relaxCatalog.ReturnThreeRandomRelax();
        return resultTemp;
    }
}
