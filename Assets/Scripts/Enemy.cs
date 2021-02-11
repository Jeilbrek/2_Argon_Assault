using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;

    void Start()
    {
        Collider enemyCollider = gameObject.AddComponent<BoxCollider>();
        enemyCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        //print("Bullet particles collided with enemy " + gameObject.name);
        Instantiate(deathFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}