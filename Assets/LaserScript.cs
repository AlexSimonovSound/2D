using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public float speed;
    public string LaserShot = "event:/laserShot";

    // Start is called before the first frame update

    void Start()
    {
        GetComponent<Rigidbody>().velocity = Vector3.forward * speed;

    }

    void start ()


    {


        FMODUnity.RuntimeManager.PlayOneShot(LaserShot);
        LaserShot.ToString();

    }

    
}
