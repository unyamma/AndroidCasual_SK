using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hedgehog : MonoBehaviour
{
    public float speed = 8f;
    public GameObject target;
    public string TargetTag = "Mushroom";

    public void FixedUpdate()
    {
       if (!target)
        {
            target = GameObject.FindGameObjectWithTag(TargetTag);
        }
        // gameObject.transform.tr
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.gameObject.transform.position, step);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TargetTag))
        {
            Destroy(collision.gameObject);
        }
    }
}
