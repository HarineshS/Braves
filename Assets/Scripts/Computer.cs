using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    [Header("Computer ON/OFF")]
    public bool lightsOn = true;
    public float radius = 2.5f;
    public Light lights;

    [Header("Computer Assigh Things")]

    public GameObject Player;
    public GameObject ComputerUI;

    public int showComputerUIfor = 5;

    public void Awake()
    {
        //lights = GetComponent<Light>();
    }

    void Start()
    {

    }


    void Update()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) < radius)
        {
            if (Input.GetKeyDown("f"))
            {
                StartCoroutine(ShowComputerUI());
                lightsOn = false;
                lights.intensity = 0;
                //objective completed
                print("objective completed");

            }




        }

    }


    public IEnumerator ShowComputerUI()
    {
        ComputerUI.SetActive(true);
        yield return new WaitForSeconds(showComputerUIfor);
        ComputerUI.SetActive(false);
    }
}
