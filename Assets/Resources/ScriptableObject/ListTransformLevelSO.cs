using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ListTransformLevelSO : ScriptableObject
{
    [SerializeField]
    private List<GameObject> levelList;
    private GameObject currentPlace;

    public GameObject CurrentPlace { get => currentPlace; }

    public Transform LoadPlace(Place place)
    {
        currentPlace = Instantiate(levelList[(int)place]);
        return currentPlace.transform;

    }
}
