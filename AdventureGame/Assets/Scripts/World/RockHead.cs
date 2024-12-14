using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RockHead : MonoBehaviour
{
    public ID id;
    public UnityEvent onMatch, onNoMatch;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<SimpleIdBehavior>() != null)
        {
            var collisionID = collision.GetComponent<SimpleIdBehavior>();

            if (collisionID.id == id)
            {
                //Debug.Log("Matched ID: " + id);
                onMatch.Invoke();
            }
        }
        else
        {
            //Debug.Log("Failed to Match ID: " + id);
            onNoMatch.Invoke();
        }
    }
}
