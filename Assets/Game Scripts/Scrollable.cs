using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrollable : MonoBehaviour {

    [Tooltip("The velocity that this object will move at")]
    public Vector2 scrollVelocity;
    private Rigidbody2D rgbd; //We will deal with objects with rigidbodies slightly differently
	// Use this for initialization
	protected virtual void Start () {
        rgbd = GetComponent<Rigidbody2D>();  
        if(rgbd != null)
        {
            rgbd.velocity = scrollVelocity; //Set an initial velocity
        }
    }

    /// <summary>
    /// Moves the object using translation if theres no rigidbody.
    /// This is so we can reference what this script does when we inherit from it
    /// </summary>
    protected virtual void Update()
    {
        if(rgbd == null) //if theres no rigidbody we have to move with our transform
        {
            Vector3 scaledVelocity = scrollVelocity * Time.deltaTime; //Scale by delta for to move the same regardless of framerate
            transform.Translate(scaledVelocity); //Move the transform 
        }
    }
}
