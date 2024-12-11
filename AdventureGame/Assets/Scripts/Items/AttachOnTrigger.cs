using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachOnTrigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider other)
    {
        transform.parent = other.transform;
    }
}
