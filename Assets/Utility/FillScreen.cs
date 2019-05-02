using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    [ExecuteInEditMode] // Run while editing
    [RequireComponent(typeof(SpriteRenderer))] //require a sprite renderer to avoid errors
    [AddComponentMenu("Utility/FillScreen")] //Helps designer find scripts when they need it
    
    public class FillScreen : MonoBehaviour
    {
        // Use this for initialization
        void Awake()
        {
            //Calculate Camera height and width
            float cameraHeight = Camera.main.orthographicSize * 2f; // Orthorgraphic size is only half the Cameras Screen height
            float cameraWidth = Camera.main.aspect*cameraHeight;

            //Get the sprites width and height
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            float width = spriteRenderer.bounds.size.x;
            float height = spriteRenderer.bounds.size.y;

            //Scale using localscale
            if (cameraHeight > cameraWidth) //if we're in portrait view scale by height
            {
                transform.localScale *= cameraHeight / height;
                transform.localPosition *= cameraHeight / height;
            }
            else //otherwise scale by width
            {
                transform.localScale *= cameraWidth / width ;
                transform.localPosition *= cameraWidth / width;
            }

            
                
        }
    }
}
