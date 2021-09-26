using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerPosOffset : MonoBehaviour
{
    private int offset;

    private void Start()
    {
        offset = gameObject.GetComponent<SpriteRenderer>().sortingOrder;
    }

    private void FixedUpdate()
    {
        int result = (Mathf.RoundToInt(gameObject.transform.position.y) * -1) + offset;
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = result;
    }
}
