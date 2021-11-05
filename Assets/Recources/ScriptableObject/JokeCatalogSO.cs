using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class JokeCatalogSO : ScriptableObject
{
    private List<JokeSO> jokeList;

    public JokeSO[] ReturnThreeRandomJoke()
    {
        JokeSO[] threeRandomJoke = new JokeSO[3];

        int randomOne, randomTwo, randomThree;

        randomOne = Random.Range(0, jokeList.Count);

        threeRandomJoke[0] = jokeList[randomOne];
        do
        {
            randomTwo = Random.Range(0, jokeList.Count);
        } while (randomOne == randomTwo);
        threeRandomJoke[1] = jokeList[randomTwo];

        do
        {
            randomThree = Random.Range(0, jokeList.Count);
        } while (randomTwo == randomThree && randomOne == randomThree);
        threeRandomJoke[2] = jokeList[randomThree];


        return threeRandomJoke;

    }
}