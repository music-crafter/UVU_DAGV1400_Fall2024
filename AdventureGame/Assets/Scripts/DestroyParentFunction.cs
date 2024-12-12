using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParentFunction : MonoBehaviour
{
    public void DestroyParent()
    {
        //Debug.Log("Destroyed " + gameObject.name);
        Destroy(gameObject);
    }
}
