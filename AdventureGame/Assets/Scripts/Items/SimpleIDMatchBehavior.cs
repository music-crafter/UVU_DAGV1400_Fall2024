using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleIDMatchBehavior : MonoBehaviour
{
    public ID id;
    public UnityEvent onMatch, onNoMatch;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var otherID = other.GetComponent<SimpleIdBehavior>();

        if (otherID.id == id)
        {
            onMatch.Invoke();
            Debug.Log("Matched ID: " + id);
        }
        else
        {
            onNoMatch.Invoke();
            Debug.Log("No Match ID: " + id);
        }
    }
}
