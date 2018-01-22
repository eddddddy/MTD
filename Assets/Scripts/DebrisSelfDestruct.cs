using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisSelfDestruct : MonoBehaviour
{

    ParticleSystem debris;

    void Start()
    {
        debris = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (debris)
        {
            if (!debris.IsAlive())
            {
                Destroy(gameObject);
            }
        }
    }
}
