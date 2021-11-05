using System.Collections.Generic;
using UnityEngine;

public class ListTransformLevelSO : MonoBehaviour
{
    private List<GameObject> levelList;
    public Transform LoadPlace(Place place)
    {
        return levelList[(int)place].transform;

    }
}
