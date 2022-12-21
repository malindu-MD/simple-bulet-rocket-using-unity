using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControl : MonoBehaviour
{

   
    private Rigidbody _rbody;
    private AudioSource _sound;
    public AudioClip clip;
    public float RotationTrust;
    public float MainTrust;
    public float volume = 0.25f;
    public float volumemute = 0.0f;




    private void Awake()
    {
        _rbody = GetComponent<Rigidbody>();
        _sound = GetComponent<AudioSource>();

        
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        Playercontroal();
        Playerrotaion();

    }
    

    private void Playerrotaion()
    {
        _rbody.freezeRotation = true;  //take manual rotation of control        
        if (Input.GetKey(KeyCode.A))
        {

            transform.Rotate(Vector3.forward*RotationTrust* Time.deltaTime);


        }
        else if (Input.GetKey(KeyCode.D))
        {

            transform.Rotate(-Vector3.forward*RotationTrust*Time.deltaTime);

        }

        _rbody.freezeRotation = false; //resume manual rotation


    }

    private void Playercontroal()
    {
        if ((Input.GetKey(KeyCode.Space))==true)
        {
            _rbody.AddRelativeForce(Vector3.up);
            _sound.PlayOneShot(clip, volume);

        }
        else if((Input.GetKey(KeyCode.Space)) == false)
        {
            _sound.PlayOneShot(null, 0);

        }

       
    }


}
