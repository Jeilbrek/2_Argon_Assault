using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Start()
    {
        gameObject.AddComponent<BoxCollider>();
    }
    void OnParticleCollision(GameObject other)
    {
        //print("Bullet particles collided with enemy " + gameObject.name);
        Destroy(gameObject);
    }
}
