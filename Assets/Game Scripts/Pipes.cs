using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour {

    [Header("Setup")]
    public GameObject pipePrefab; //Will hold the prefab for pipes
    public GameObject[] pipes; //Array of pipes that will be positioned
    public int numberOfPipes; //Number of pipes that will be in the array

    [Header("Layout Spacing")]
    [Tooltip("Minimum height of where the gap will be centered")] public float minHeight;
    [Tooltip("Max height of where the gap will be centered")] public float maxHeight;
    public float startingDistance = 2f;

    [Header("Speed")]
    public float spawnTimer = 4f;
    public Vector2 moveVelocity = new Vector2(-3f,0); //The direction and speed pipes will move at

    private int index = 0; //keeps track of the current pipe
    private Vector3 spawnSpot;

    // Use this for initialization
    void Start () {
        index = 0;
        pipes = new GameObject[numberOfPipes];
        spawnSpot = GameObject.FindGameObjectWithTag("Player").transform.position;
        spawnSpot.x += startingDistance;

        for(int i = 0; i < pipes.Length; i++) //loop through all the pipes 
        {
            pipes[i] = GameObject.Instantiate(pipePrefab, gameObject.transform); //parent the pipes to this gameobject for organization
            pipes[i].GetComponent<Scrollable>().scrollVelocity = moveVelocity; //Set the speed pipes will move at
            pipes[i].SetActive(false);
        }

        StartCoroutine(Spawn());// Could also use invoke or use an update loop
	}
	
	public IEnumerator Spawn()
    {
        //Basically an infinite loop while the game is running
        while (Application.isPlaying)
        {
            spawnSpot.y = Random.Range(minHeight, maxHeight);//pick a random height for the pipes to spawn

            //Make pipe visible and teleport it into place
            pipes[index].SetActive(true); 
            pipes[index].transform.position = spawnSpot;

            index = (index + 1) % numberOfPipes;//Increment the index this formula wraps around at the end

            yield return new WaitForSeconds(spawnTimer);//yields to other processes until spawnRate number of seconds has passed
        }
    }
}
