using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))] //prevent errors during setup
public class ScrollingBackground : Scrollable {
    
    private SpriteRenderer spriteRenderer;
    private float length;
    private Transform cameraPosition;
    
	// Start takes place after all Awake functions are finished
	protected override void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        length = spriteRenderer.bounds.extents.x * 2f;
        cameraPosition = Camera.main.transform;
	}
	
	// Update is called once per frame
	protected override void Update () {
        base.Update();
        float distFromCamera = Mathf.Abs(spriteRenderer.bounds.center.x - cameraPosition.position.x); //How far are we from the camera in the x direction
        if (distFromCamera >= length) //If we are a full length away from the camera reposition the background
        {
            Reposition(distFromCamera - length); //pass in a offset that accounts for the delay before repositioning
        }
    }

    //Repositions the background to the right of the camera
    private void Reposition(float Delay)
    {
        
        Vector3 Offset = new Vector3((length * 1.98f)-Delay, 0f,0f); //How far we will teleport the background
        if (scrollVelocity.x > 0)
        {
            transform.position -= Offset;
        }
        else
        {
            transform.position += Offset;
        }
    }
}
