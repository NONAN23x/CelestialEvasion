using UnityEngine;

public class Movement : MonoBehaviour
{

    public Joystick lestjoystick;
    public Joystick thursterstick;
    public float mainThrust = 1000f;
    public float rotaionThrust = 100f;
    public ParticleSystem mainThrusterParticles;
    public ParticleSystem leftThrusterParticles;
    public ParticleSystem rightThrusterParticles;
    Rigidbody rb;
    AudioSource audioSource;
    public AudioClip mainEngine;

    void Start() 
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
       
        ProcessThrust();
        ProcessRotation();
    }
    

    void ProcessThrust()
    {
        if ((Input.GetKey(KeyCode.Space)) || (thursterstick.Vertical >= .1f)) 
        {
            rb.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }
            if (!mainThrusterParticles.isPlaying){
            mainThrusterParticles.Play();}
        }
        else
        {
            audioSource.Stop();
            mainThrusterParticles.Stop();
        }
    }
    

    public void ProcessRotation()
    {
    //     if ((Input.GetKey(KeyCode.A)) || (lestjoystick.Vertical >= .2f))
    //     {
    //         mvleft();
    //     }
    //    else if ( (Input.GetKey(KeyCode.D)) || (lestjoystick.Vertical <= .2f))
    //     {
    //         mvright();
    //     }
    //     else
    //     {
    //         rightThrusterParticles.Stop();
    //         leftThrusterParticles.Stop();
    //     }
        switch(lestjoystick.Vertical)
        {
            case >0.5f:
                mvright();
                break;
            case <-0.5f:
                mvleft();
                break;
            default:
                rightThrusterParticles.Stop();
                leftThrusterParticles.Stop();
                break;
        }
    }

    void Rotation(float x)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * Time.deltaTime * x * 1.5f);
        rb.freezeRotation = false;  
    }




    public void mvleft(){
        Rotation(rotaionThrust);
        if (!leftThrusterParticles.isPlaying){
        leftThrusterParticles.Play();}
    }

    public void mvright(){
        Rotation(-rotaionThrust);
        if (!rightThrusterParticles.isPlaying){
        rightThrusterParticles.Play();}
    }


}

