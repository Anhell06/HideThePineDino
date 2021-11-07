using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CatalogAnimation : ScriptableObject
{
    [SerializeField]
    private List<AnimationForCatalog> animations;
    private List<AnimationForCatalog> randomAnimation;

    public AnimationForCatalog GetAnimation(animationType type)
    {
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
