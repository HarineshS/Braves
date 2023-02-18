using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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




    public float fillSpeed = 0.5f;
    private float currentFill = 0f;
    //private bool isHoldingKey = false;
    public Image fillImage;

    public void Awake()
    {
        //lights = GetComponent<Light>();
    }

    void Start()
    {

        //fillImage = GetComponent<Image>();
        fillImage.fillAmount = currentFill;

    }


    void Update()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) < radius)
        {
            // if (Input.GetKeyDown("f"))
            // {
            //     StartCoroutine(ShowComputerUI());
            //     lightsOn = false;
            //     lights.intensity = 0;
            //     //objective completed
            //     print("objective completed");

            // }

            if (Input.GetKey(KeyCode.F))
            {
                currentFill += fillSpeed * Time.deltaTime;
                currentFill = Mathf.Clamp01(currentFill);
                fillImage.fillAmount = currentFill;

                if (fillImage.fillAmount == 1)
                {
                    StartCoroutine(ShowComputerUI());
                    lightsOn = false;
                    lights.intensity = 0;
                    //objective completed
                    print("objective completed");

                }
            }




        }

    }


    public IEnumerator ShowComputerUI()
    {
        ComputerUI.SetActive(true);
        fillImage.fillAmount = 0;
        yield return new WaitForSeconds(showComputerUIfor);
        ComputerUI.SetActive(false);

    }
}
