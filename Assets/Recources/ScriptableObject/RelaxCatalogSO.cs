using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RelaxCatalogSO : ScriptableObject
{
    private List<RelaxSO> relaxList;

    public RelaxSO[] ReturnThreeRandomRelax()
    {
        RelaxSO[] threeRandomRelax = new RelaxSO[3];

        int randomOne, randomTwo, randomThree;

        randomOne = Random.Range(0, relaxList.Count);

        threeRandomRelax[0] = relaxList[randomOne];

        do
        {
            randomTwo = Random.Range(0, relaxList.Count);
        }
        while (randomOne == randomTwo);

        threeRandomRelax[1] = relaxList[randomTwo];

        do
        {
            randomThree = Random.Range(0, relaxList.Count);
        }
        while (randomTwo == randomThree && randomOne == randomThree);

        threeRandomRelax[2] = relaxList[randomThree];

        return threeRandomRelax;
    }
}
