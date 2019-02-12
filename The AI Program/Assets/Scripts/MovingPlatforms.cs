using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DisallowMultipleComponent]
public class MovingPlatforms : MonoBehaviour {

    //todo remove from inspecter
    //movement vector where to move the gameobj to
    [SerializeField] Vector3 movementVector = new Vector3 (0,1f,0f);
    //movement vector 0%-100% away from movement vector
    [SerializeField] float period = 2f;
    float movementFactor;

    public GameObject Player;

    private void OnTriggerEnter (Collider other) {
        if(other.gameObject == Player){
                Player.transform.parent = transform;
        }

    }

    private void OnTriggerExit (Collider other) {
        if(other.gameObject == Player){
                Player.transform.parent = null;
        }
    }

    Vector3 startingPos;

	// Use this for initialization
	void Start () {
        //transform.postion is the current GameObj postion
        startingPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //Mathf.epsilon smallest number possible
        if (period <= Mathf.Epsilon) { return; }
        float cycle = Time.time * period; //grows from 0
        const float tau = Mathf.PI * 2; //const used when its not changing
        float rawSineWave = Mathf.Sin(cycle * tau);  //go from -1 to +1
        movementFactor = (rawSineWave * 2f) / 0.5f;
        Vector3 offset = movementFactor * movementVector;
        //alters the current position of the gameobj
        transform.position = startingPos + offset;
	}


        
}
