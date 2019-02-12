using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{

    public float damage = 10f;
    public float range = 1000f;
    public float fireRate = 15f; 
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public float impactForce = 30f;
    public GameObject impactEffect;
    public AudioClip gunClip;
    public AudioSource gunSource;

    private float nextTimeToFire = 1f; 

	Text text; 
    public int ammoStart = 0;
    public int reloadValue = 15;
    public Transform ammoText;
     
    //public int shotText = ammoStart;
    void Awake(){

    }

    // Update is called once per frame
    void Start(){
        ammoText.GetComponent<Text> ().text = "Ammo:"+ ammoStart.ToString();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && ammoStart >= 1)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            gunSource.Play();
            ammoStart -= 1;
            Debug.Log("fire button pressed");
        }
        
        ammoText.GetComponent<Text> ().text = "Ammo:"+ ammoStart.ToString();

    }

    void  OnTriggerEnter(Collider other){
        if ( other.tag == "Ammo"){
            ammoStart = ammoStart + reloadValue;
            Destroy(other.gameObject);
            Debug.Log(ammoStart);
        }

    }

    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){

            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null){
                target.TakeDamage(damage);
            }

            //if(hit.rigidbody != null){
            //if(hit.rigidbody == target){
                //hit.rigidbody.AddForce(-hit.normal * impactForce);
            //}
            //GameObject impactGO = (impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            //Destroy(impactGO, 2f);
        }
    }
}
