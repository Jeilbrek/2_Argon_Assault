using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructor : MonoBehaviour
{
    private float destructionDelay = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destructionDelay);
    }
}
