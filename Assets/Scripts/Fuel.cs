using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    public bool randomize;
    public float seconds;
    public float PRange;
    public GameObject prefab;

    void Start()
    {
        if (randomize)
        {
            seconds = seconds + Random.Range(seconds / 100 * PRange * -1, seconds / 100 * PRange);
        }
    }
}
