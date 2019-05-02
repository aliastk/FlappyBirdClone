using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody2D))] //Prevent errors during setup
public class PlayerController : MonoBehaviour {
    [Header("Physics")]
    private Rigidbody2D rgbd;
    [SerializeField] private ForceMode2D typeOfForce = ForceMode2D.Force; //Exposing force mode in the editor lets designers tweak it
    [Tooltip("How much force to add every time we press space")][SerializeField] private float amountOfForce;

    [Header("Score")]
    public Text text;
    private int score;

    [Header("Gameover")]
    public GameObject gameover;
    public Text finalScore;

	// Use this for initialization
	void Start () {
        rgbd = GetComponent<Rigidbody2D>();
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rgbd.AddForce(Vector2.up * amountOfForce, typeOfForce);
        }
        text.text = "Score:" + score;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Time.timeScale = 0;
        gameover.SetActive(true);
        finalScore.text = "Score:" + score;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        score++;
    }


}
