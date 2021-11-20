using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CatalogAnimation : ScriptableObject
{
    [SerializeField]
    private List<AnimationForCatalog> animations;
    private List<AnimationForCatalog> randomAnimation = new List<AnimationForCatalog>();

    public AnimationForCatalog GetAnimation(animationType type)
    {
        randomAnimation.Clear();
        foreach (var animation in animations)
        {
            if (type == animation.typeAnimation)
            {
                randomAnimation.Add(animation);
            }
        }
        return randomAnimation[Random.Range(0, randomAnimation.Count)];

    }
}
