using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketController : MonoBehaviour
{
    [SerializeField] float upThrust = 100f;
    [SerializeField] float rotateThrust = 100f;
    [SerializeField] AudioClip rocketThrust;
    [SerializeField] AudioClip SoundBgm;

    [SerializeField] ParticleSystem rocketThrustParticles;
    [SerializeField] ParticleSystem leftThrustParticles;
    [SerializeField] ParticleSystem rightThrustParticles;

    Rigidbody rocketRb;
    AudioSource source;
    


    void Start()
    {
        rocketRb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
        source.PlayOneShot(SoundBgm);
    }

    
    void Update()
    {
        PlayerUpThrust();
        RotateThrust();

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    void PlayerUpThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rocketRb.AddRelativeForce(Vector3.up * upThrust * Time.deltaTime);
            if (!source.isPlaying)
            {
                source.PlayOneShot(rocketThrust,0.2f);
            }
            if(!rocketThrustParticles.isPlaying)
            {
                rocketThrustParticles.Play();
            }
            
        }
        else
        {
            source.Stop();
            rocketThrustParticles.Stop();
        }
    }
    void RotateThrust()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateForce(rotateThrust);
            if (!leftThrustParticles.isPlaying)
            {
                leftThrustParticles.Play();
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateForce(-rotateThrust);
            if (!rightThrustParticles.isPlaying)
            {
                rightThrustParticles.Play();
            }
        }
        else
        {
            leftThrustParticles.Stop();
            rightThrustParticles.Stop();
        }
    }
    void RotateForce(float rotateThrust)
    {
        rocketRb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotateThrust * Time.deltaTime);
        rocketRb.freezeRotation = false;
    }

}
