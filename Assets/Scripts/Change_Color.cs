//using System;
using UnityEngine;
using System.Collections;
using System.IO.Ports;
using UnityEngine.UI;

public class Change_Color : MonoBehaviour {

	public float player_1 = 0;
    public float player_2 = 0;
    public float player_3 = 0;
    public float player_4 = 0;
    public float player_5 = 0;
    public float player_6 = 0;

    public float duration = 1.0F;

    public float colorIncrement;

	public GameObject team1_1;
	public GameObject team1_2;
	public GameObject team1_3;
	public GameObject team2_1;
	public GameObject team2_2;	
	public GameObject team2_3;

	public GameObject team1_blend;
	public GameObject team2_blend;

	private bool player_1_UP = true;
	private bool player_2_UP = true;
	private bool player_3_UP = true;
	private bool player_4_UP = true;
	private bool player_5_UP = true;
	private bool player_6_UP = true;

	private float targetRed;
	private float targetGreen;
	private float targetBlue;
	private float swapInterval = 10.0F;
	private float nextSwap = 0.0F;
	public AudioSource buzzer;
	private bool winner;
	private int team1Score;
	private int team2Score;
	private float increments = 5f;
	public AudioSource change;
	public AudioSource success;
	public GameObject team1Label;
	public GameObject team2Label;


	// Use this for initialization
	void Start () {

		winner = false;
		team1Score = 0;
		team2Score = 0;


		colorIncrement = 1 / increments;

		Random.seed = (int)System.DateTime.Now.Ticks;

		targetRed = Mathf.Round(Random.Range(0, increments)) * colorIncrement;
		targetGreen = Mathf.Round(Random.Range(0, increments)) * colorIncrement;
		targetBlue = Mathf.Round(Random.Range(0, increments)) * colorIncrement;
	
	}
	
	// Update is called once per frame
	void Update () {

		if ((player_1 == targetRed) && (player_2 == targetGreen) && (player_3 == targetBlue)) {
			team1Score += 1;
			success.Play ();
			team1Label.GetComponent<Text>().text = team1Score.ToString();
			targetRed = Mathf.Round(Random.Range(0, increments)) * colorIncrement;
			targetGreen = Mathf.Round(Random.Range(0, increments)) * colorIncrement;
			targetBlue = Mathf.Round(Random.Range(0, increments)) * colorIncrement;
			
		}
		if ((player_4 == targetRed) && (player_5 == targetGreen) && (player_6 == targetBlue)) {
			team2Score += 1;
			success.Play ();
			team2Label.GetComponent<Text>().text = team2Score.ToString();
			targetRed = Mathf.Round(Random.Range(0, increments)) * colorIncrement;
			targetGreen = Mathf.Round(Random.Range(0, increments)) * colorIncrement;
			targetBlue = Mathf.Round(Random.Range(0, increments)) * colorIncrement;
		}

		team1_blend.GetComponent<Renderer>().material.color = new Color(player_1, player_2, player_3);
		team2_blend.GetComponent<Renderer>().material.color = new Color(player_4, player_5, player_6);
		this.GetComponent<Renderer>().material.color = new Color(targetRed, targetGreen, targetBlue);

		if (!winner) {
			if (Input.GetKeyDown(KeyCode.W)) {
				if (player_1_UP){
					player_1 += colorIncrement;
					 if (player_1 >= 1.0F){
					 	player_1 = 1.0F;
					 	player_1_UP = false;
					 }
				} else {
					player_1 -= colorIncrement;
					if (player_1 <= 0.0F){
						player_1 = 0.0F;
					 	player_1_UP = true;
					}
				}
				team1_1.GetComponent<Renderer>().material.color = new Color(player_1, 0.0F, 0.0F);
			}
			if (Input.GetKeyDown(KeyCode.B)) {
				if (player_2_UP){
					player_2 += colorIncrement;
					 if (player_2 >= 1.0F){
					 	player_2 = 1.0F;
					 	player_2_UP = false;
					 }
				} else {
					player_2 -= colorIncrement;
					 if (player_2 <= 0.0F){
						player_2 = 0.0F;
					 	player_2_UP = true;
					 }
				}
	        	team1_2.GetComponent<Renderer>().material.color = new Color(0.0F, player_2, 0.0F);
			}
			if (Input.GetKeyDown(KeyCode.L)) {

				if (player_3_UP){
					player_3 += colorIncrement;
					 if (player_3 >= 1.0F){
					 	player_3 = 1.0F;
					 	player_3_UP = false;
					 }
				} else {
					player_3 -= colorIncrement;
					 if (player_3 <= 0.0F){
					 	player_3 = 0.0F;
					 	player_3_UP = true;
					 }
				}
	        	team1_3.GetComponent<Renderer>().material.color = new Color(0.0F, 0.0f, player_3);
			}
			if (Input.GetKeyDown(KeyCode.Q)) {
				if (player_4_UP){
					player_4 += colorIncrement;
					 if (player_4 >= 1.0F){
					 	player_4 = 1.0F;
					 	player_4_UP = false;
					 }
				}
				else {
					player_4 -= colorIncrement;
					 if (player_4 <= 0.0F){
					 	player_4 = 0.0F;
					 	player_4_UP = true;
					 }
				}
		       	team2_1.GetComponent<Renderer>().material.color = new Color(player_4, 0.0f, 0.0F);
			}
	        if (Input.GetKeyDown(KeyCode.C)) {
				if (player_5_UP){
					player_5 += colorIncrement;
					 if (player_5 >= 1.0F){
					 	player_5 = 1.0F;
					 	player_5_UP = false;
					 }
				} else {
					player_5 -= colorIncrement;
					 if (player_5 <= 0.0F){
					 	player_5 = 0.0F;
					 	player_5_UP = true;
					 }
				}
		       	team2_2.GetComponent<Renderer>().material.color = new Color(0.0F, player_5, 0.0F);
	 		}
	        if (Input.GetKeyDown(KeyCode.K)){
	        	if (player_6_UP){
					player_6 += colorIncrement;
					 if (player_6 >= 1.0F){
					 	player_6 = 1.0F;
					 	player_6_UP = false;
					 }
				} else {
					player_6 -= colorIncrement;
					 if (player_6 <= 0.0F){
					 	player_6 = 0.0F;
					 	player_6_UP = true;
					 }
				}
	        	team2_3.GetComponent<Renderer>().material.color = new Color(0.0F, 0.0F, player_6);
			}

			if (Input.GetKeyDown (KeyCode.S) && (player_1 != targetRed)) {
				buzzer.Play ();
			}
			if (Input.GetKeyDown (KeyCode.N) && (player_2 != targetGreen)) {
				buzzer.Play ();
			}
			if (Input.GetKeyDown (KeyCode.P) && (player_3 != targetBlue)) {
				buzzer.Play ();
			}
			if (Input.GetKeyDown (KeyCode.A) && (player_4 != targetRed)) {
				buzzer.Play ();
			}
			if (Input.GetKeyDown (KeyCode.V) && (player_5 != targetGreen)) {
				buzzer.Play ();
			}
			if (Input.GetKeyDown (KeyCode.O) && (player_6 != targetBlue)) {
				buzzer.Play ();
			}
	        
			if (((Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.V) && Input.GetKey(KeyCode.O)) || (Input.GetKey(KeyCode.S) && Input.GetKey (KeyCode.N) && Input.GetKey (KeyCode.P))) && (Time.time > nextSwap)) {
//				float tempR = player_1;
//				float tempG = player_2;
//				float tempB = player_3;
//				player_1 = player_4;
//				player_2 = player_5;
//				player_3 = player_6;
//				player_4 = tempR;
//				player_5 = tempG;
//				player_6 = tempB;
				change.Play ();

				targetRed = Mathf.Round(Random.Range(0, increments)) * colorIncrement;
				targetGreen = Mathf.Round(Random.Range(0, increments)) * colorIncrement;
				targetBlue = Mathf.Round(Random.Range(0, increments)) * colorIncrement;

				team1_1.GetComponent<Renderer>().material.color = new Color(player_1, 0.0F, 0.0F);
				team1_2.GetComponent<Renderer>().material.color = new Color(0.0F, player_2, 0.0F);
				team1_3.GetComponent<Renderer>().material.color = new Color(0.0F, 0.0f, player_3);
				team2_1.GetComponent<Renderer>().material.color = new Color(player_4, 0.0f, 0.0F);
				team2_2.GetComponent<Renderer>().material.color = new Color(0.0F, player_5, 0.0F);
				team2_3.GetComponent<Renderer>().material.color = new Color(0.0F, 0.0F, player_6);
				nextSwap = Time.time + swapInterval;
			}
		}


       if (Input.GetKeyDown (KeyCode.Return)) {
			Application.LoadLevel (0);
		}

		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}
}
