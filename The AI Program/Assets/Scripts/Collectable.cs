using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectable : MonoBehaviour {


public int health = 5;
public int damageAmount = 5; 
public int ammo = 50; 
private bool hasKey = false;
private int coinsCollected = 0;

void OnTriggerEnter(Collider other){
	
	if (other.tag ==  "Coin" ){
		//Effect is the name of the particle effect on the coin
		//Instantiate(Resources.Load("Effect"),other.transform.position,transform.rotation);
		Destroy(other.gameObject);
		coinsCollected++;
		Debug.Log(coinsCollected);
	}

	if (other.tag ==  "Key"){
		Destroy(other.gameObject);
		Debug.Log(hasKey);
		hasKey = true;
	}

	if (other.tag ==  "Door")
	{
		if(hasKey){
			//other.GetComponent<Animator>().SetTrigger("Open");
			Destroy(other.gameObject);
		}

	}
		/* 
		
		if (other.tag ==  "Health" && health != 100 ){
		Destroy(other.gameObject);
		health = health + 10;
		if (health >100){
			health = 100;
		}
		Debug.Log(health);
	}
	else{Debug.Log(health);}
		
		if (other.tag ==  "Damage" && health>0){
		health = health - damageAmount;
		Debug.Log(health);

		if (health <=0 ){
			Debug.Log(health);
			SceneManager.LoadScene("Battleground 2");
			
		}
	}*/
	

}

}
