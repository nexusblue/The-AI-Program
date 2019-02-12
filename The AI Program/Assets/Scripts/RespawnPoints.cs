using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RespawnPoints : MonoBehaviour {

	[SerializeField]private Transform player;
	public Transform [] respawnPoints;
	

	public int health = 5;
	public int damageAmount = 5; 

	public bool activated  = false;
	public static GameObject[] CheckPointList;

	// Use this for initialization
	void Start () {
		CheckPointList = GameObject.FindGameObjectsWithTag("Checkpoint");
	}
	
	// Update is called once per frame
	void Update () {


	}

	
	void OnTriggerEnter(Collider other){
		if (other.tag ==  "Damage" && health > 0 ){
			health = health - damageAmount;
			if (health <=0 ){
				SceneManager.LoadScene("RestartLevel");
				//transform.position = respawnPoints[0].position;
				//transform.rotation = respawnPoints[0].rotation;
			}
			if(other.tag == "Checkpoint"){
			Debug.Log("Player has entered checkpoint 1");
			}
	}

	
}
}