using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BouncyBall : MonoBehaviour
{
    public float bounceForce = 3f;
    public Color defaultColor = Color.white;
    public Color hurtColor = Color.red;
    public Color healColor = Color.green;
    private float colorResetTimer = 0;

    void Update()
    {
        if (colorResetTimer < 0.1 && GetComponent<Renderer>().material.color != defaultColor)
        {
            colorResetTimer += Time.deltaTime;
        }
        else
        {
            GetComponent<Renderer>().material.color = defaultColor;
            colorResetTimer = 0;
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
        if (collision.gameObject.CompareTag("DamageSurface"))
        {
            GetComponent<Renderer>().material.color = hurtColor;
        }
        else if (collision.gameObject.CompareTag("HealSurface"))
        {
            GetComponent<Renderer>().material.color = healColor;
            
        }
    }
    
}
