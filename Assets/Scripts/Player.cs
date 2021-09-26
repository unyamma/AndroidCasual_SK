using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public FixedJoystick joystick;
    public float speed;
    public bool canMove;

    private void Update()
    {
        if (!canMove) { return; }
        gameObject.transform.Translate(joystick.Horizontal * speed * Time.deltaTime, joystick.Vertical * speed * Time.deltaTime, 0);
        if (joystick.Horizontal > 0)
        {
            gameObject.transform.localScale = new Vector3(2, 2, 0);
        }
        if (joystick.Horizontal < 0)
        {
            gameObject.transform.localScale = new Vector3(-2, 2, 0);
        }
    }

}
