using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour {

    //Rigibody is the data type Rigidbody
    //rigidbody is the var Name
    //[SeralizedField] makes it changeable in inspector and not by other scripst
    //public           makes it changeable in inspector and by other scripst'
    Rigidbody rigidbody;
    AudioSource audioSource;
    [SerializeField] float rcsThrust = 85f;
    [SerializeField] float mainThrust = 185f;
    [SerializeField] float levelDelay = 1f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] AudioClip winSFX;

    [SerializeField] ParticleSystem engineParticle;
    [SerializeField] ParticleSystem deathParticle;
    [SerializeField] ParticleSystem winParticle;

    enum State { Alive, Dying, Transcending }
    State state = State.Alive;

	// Use this for initialization
	void Start () {
        //this can grab multiple types of components
        //this also gives script access to rigibody compo from the same GameObj
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
        //todo somewhere stop sound on death
        if (state == State.Alive){
            RespondToThrust();
            RespondToRotate(); 
        }

	}

    void OnCollisionEnter(Collision collision){

        if (state != State.Alive){return;} //ignore collisions
        switch(collision.gameObject.tag){
            case("Friendly"):
                break;
            case ("Finish"):
                WinSequence();
                break;
            default:
                DeathSequence();
                break;
        }
    }

    private void WinSequence()
    {   state = State.Transcending;
        audioSource.Stop();
        audioSource.PlayOneShot(winSFX);
        winParticle.Play();
        Invoke("LoadNextScene", levelDelay);
    }
    private void DeathSequence()
    {   state = State.Dying;
        audioSource.Stop();
        audioSource.PlayOneShot(deathSFX);
        deathParticle.Play();
        Invoke("LoadFirstScene", levelDelay);
    }

    private void LoadNextScene()
    {   //allow for more levels
        SceneManager.LoadScene(1);
    }

    private void LoadFirstScene()
    {   SceneManager.LoadScene(0);
    }

    private void RespondToThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {   ApplyThrust();}
        else
        {   audioSource.Stop();
            engineParticle.Stop();
        }
    }

    private void ApplyThrust()
    {rigidbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime );
        if (!audioSource.isPlaying)
        { //so it doesnt layer sound
            audioSource.PlayOneShot(mainEngine);
        }
        engineParticle.Play();
    }

    private void RespondToRotate()
    {   //Can Thrust while rotating
        //Can only Thrust in one direction
        rigidbody.freezeRotation = true; // get control of rotation
        float rotationThisFrame = rcsThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {   
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }
        rigidbody.freezeRotation = false; // resume physics control of rotation
    }

    //GetKey applies all the time
    //GetKeyDown returns true whe you first press the key down

}
