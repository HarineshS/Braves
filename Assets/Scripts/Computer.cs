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

    public bool isHoldingKey = false;

    public AudioSource ASource;

    public AudioClip[] clips;

    public bool isplayingaudio = false;

    public void Awake()
    {
        //lights = GetComponent<Light>();
        PlayerPrefs.SetInt("Obj1Status", 0);
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


            if (isHoldingKey)
            {
                if (!isplayingaudio)
                {
                    ASource.clip = clips[0];
                    ASource.Play();
                    isplayingaudio = true;
                }

            }
            else
            {
                ASource.Stop();
            }





            if (PlayerPrefs.GetInt("Obj1Status") == 0)
            {

                if (Input.GetKey(KeyCode.F))
                {
                    isHoldingKey = true;
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

                else
                {
                    isHoldingKey = false;
                }







            }






        }



    }

    private void LateUpdate()
    {
        if (isplayingaudio && !ASource.isPlaying)
        {
            isplayingaudio = false;
        }

    }


    public IEnumerator ShowComputerUI()
    {
        PlayerPrefs.SetInt("Obj1Status", 1);
        ComputerUI.SetActive(true);
        fillImage.fillAmount = 0;
        isHoldingKey = false;
        yield return new WaitForSeconds(showComputerUIfor);
        ComputerUI.SetActive(false);
        PlayerPrefs.SetInt("Obj1Status", 0);


    }
}
