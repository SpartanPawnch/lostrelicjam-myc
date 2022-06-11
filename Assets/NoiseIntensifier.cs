using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseIntensifier : MonoBehaviour
{

    [SerializeField] private EffectStackController effectStackController;

    [SerializeField] private float nearRadius;
    [SerializeField] private float effectRadius;
    [SerializeField] private Transform player;
    [SerializeField] private EffectStackController.EffectStack effectStack;

    // Start is called before the first frame update
    void Start()
    {
        
        //player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position,
            player.position);
        
        // either nothing happens or a lot happens
        if (distance <= nearRadius)
        {
            effectStackController.Stack = EffectStackController.EffectStack.None;
        }
        else if (distance <= effectRadius)
        {
            float effectPercentage = 1 - (distance - nearRadius) / (effectRadius - nearRadius);
            effectStackController.Stack = effectStack;
            effectStackController.Intensity = effectPercentage;
        }
        else
        {
            effectStackController.Stack = EffectStackController.EffectStack.None;
        }
    }
}
