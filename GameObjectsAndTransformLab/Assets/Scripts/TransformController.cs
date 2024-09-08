using UnityEngine;

public class TransformController : MonoBehaviour
{
    
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    
    private void Update()
    {
        // Move the target GameObject up and down
        var x = Mathf.PingPong(Time.time, 4);
        var y = Mathf.Cos(Time.time * 2);
        var p = new Vector3(x, y, 0);
        target1.transform.position = p;
        // Rotate the target GameObject
        target2.transform.Rotate(new Vector3(60, 30, 0) * Time.deltaTime);
        // Scale the target GameObject
        target3.transform.localScale = new Vector3(x, y, 1);
    }
}
