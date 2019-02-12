using UnityEngine;

public class Target : MonoBehaviour {    

    public Material[] material;
    Renderer rend;
    public float health = 15f;

    void Start (){
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];

    }
    // Update is called once per frame
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
        else if (health == 10f)
        {
            rend.sharedMaterial = material[1];
        }
                else if (health == 5f)
        {
            rend.sharedMaterial = material[2];
        }
    }
     void Die()
    {
        DestroyObject(gameObject);
    }
}
