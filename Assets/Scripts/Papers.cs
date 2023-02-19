using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Papers : MonoBehaviour
{

    [Header("papers ui Assigh Things")]

    public GameObject Player;
    public GameObject obj2;

    public float radius = 2.5f;

    public int showComputerUIfor = 5;




    public float fillSpeed = 0.5f;
    private float currentFill = 0f;
    //private bool isHoldingKey = false;
    public Image fillImage;

    public bool isHoldingKey = false;

    public AudioSource ASource;

    public AudioClip[] clips;

    public bool isplayingaudio = false;


    private void Awake()
    {
        PlayerPrefs.SetInt("Obj2Status", 0);
        obj2.SetActive(false);
    }
    void Start()
    {
        fillImage.fillAmount = currentFill;

    }

    // Update is called once per frame
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





            if (PlayerPrefs.GetInt("Obj2Status") == 0)
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
                        StartCoroutine(DisableChildObjectsCoroutine());
                        //lightsOn = false;
                        //lights.intensity = 0;
                        //objective completed
                        print("objective completed");

                        //this.gameObject.SetActive(false);





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
        PlayerPrefs.SetInt("Obj2Status", 1);
        obj2.SetActive(true);
        //ComputerUI.SetActive(true);
        fillImage.fillAmount = 0;
        isHoldingKey = false;
        yield return new WaitForSeconds(showComputerUIfor);
        PlayerPrefs.SetInt("Obj2Status", 0);
        obj2.SetActive(false);

        Destroy(this.gameObject);
        //ComputerUI.SetActive(false);



    }

    public IEnumerator DisableChildObjectsCoroutine()
    {
        // Get the parent object
        GameObject parentObject = GameObject.Find("Paper & Envelope");

        // Loop through all of its child objects
        for (int i = 0; i < parentObject.transform.childCount; i++)
        {
            // Get the child object at index i
            GameObject childObject = parentObject.transform.GetChild(i).gameObject;

            // Disable the child object
            childObject.SetActive(false);

            // Wait for 1 second before disabling the next child object
            yield return new WaitForSeconds(0.3f);
        }
    }
}
