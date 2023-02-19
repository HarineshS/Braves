using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{

    public Computer computer;
    public GameObject computerobject;
    public AudioSource ASource;
    // Start is called before the first frame update
    void Start()
    {
        computer = computerobject.GetComponent<Computer>();


    }

    // Update is called once per frame
    void Update()
    {

        if (computer.isHoldingKey == true)
        {
            ASource.Play();

        }
        // else
        // {
        //     ASource.Stop();
        // }

    }
}
