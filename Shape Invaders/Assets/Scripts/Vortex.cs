using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vortex : MonoBehaviour
{
    public float radius;
    public float strength;
    
    public void FixedUpdate()
    {
        foreach(Collider2D collider in Physics2D.OverlapCircleAll(transform.position, radius))
        {
            // calculate direction from target to me
            Vector3 forceDirection = transform.position - collider.transform.position;

            // apply force on target towards me
            if (collider.attachedRigidbody && !collider.CompareTag("Player"))
                collider.attachedRigidbody.AddForce(forceDirection.normalized * strength);
        }
    }
}
