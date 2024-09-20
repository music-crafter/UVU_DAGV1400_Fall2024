using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipTransformBehavior : MonoBehaviour
{
    public KeyCode keyRArrow = KeyCode.RightArrow, keyLArrow = KeyCode.LeftArrow, keyA = KeyCode.A, keyD = KeyCode.D;
    public float direction1 = 0, direction2 = 180;
    
    private void Update()
    {
        if (Input.GetKeyDown(keyRArrow) || Input.GetKeyDown(keyD))
        {
            transform.rotation = Quaternion.Euler(0, direction1, 0);
        }

        if (!Input.GetKeyDown(keyLArrow) && !Input.GetKeyDown(keyA)) return;
        transform.rotation = Quaternion.Euler(0, direction2, 0);
    }
}
