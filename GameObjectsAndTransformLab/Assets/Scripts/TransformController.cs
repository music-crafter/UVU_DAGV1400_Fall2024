using UnityEngine;

public class TransformController : MonoBehaviour
{
    
    public GameObject target;
    
    private void Update()
    {
        // Move the target GameObject up and down
        var x = Mathf.PingPong(Time.time, 3);
        var p = new Vector3(0, x, 0);
        target.transform.position = p;
        // Rotate the target GameObject
        target.transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
        // Scale the target GameObject
    }
}
