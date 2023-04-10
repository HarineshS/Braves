using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelicopterScript : MonoBehaviour
{

    public GameObject Propeller1;
    public GameObject Propeller2;

    public Rotateobject ro1;
    public Rotateobject ro2;

    public GameObject[] objectstodisable;



    [Header("Helicopter ui Assigh Things")]

    public GameObject Player;
    public GameObject Obj3;

    public float radius = 2.5f;

    public int showComputerUIfor = 5;




    public float fillSpeed = 0.5f;
    private float currentFill = 0f;
    //private bool isHoldingKey = false;
    public Image fillImage;

    public bool isHoldingKey = false;

    public AudioSource ASource;

    public AudioSource heliidle;

    public AudioClip[] clips;

    public bool isplayingaudio = false;

    public bool alreadyplayed = false;


    //for slowing the propeller

    public float duration = 10.0f;  // the time it should take to reduce speed to zero
    //private float timer = 0.0f;

    private float initialSpeed;


    private void Awake()
    {
        PlayerPrefs.SetInt("Obj3Status", 0);
        Obj3.SetActive(false);
    }

    void Start()
    {
        ro1 = Propeller1.GetComponent<Rotateobject>();
        ro2 = Propeller2.GetComponent<Rotateobject>();
        fillImage.fillAmount = currentFill;

        initialSpeed = ro1.speed;

    }


    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) < radius)
        {


            if (isHoldingKey)
            {
                // if (!isplayingaudio)
                // {
                //     ASource.clip = clips[0];
                //     ASource.Play();
                //     isplayingaudio = true;
                //     heliidle.Stop();
                // }

            }
            else
            {
                //ASource.Stop();
            }





            if (PlayerPrefs.GetInt("Obj3Status") == 0)
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
        PlayerPrefs.SetInt("Obj3Status", 1);

        Obj3.SetActive(true);
        //ComputerUI.SetActive(true);
        fillImage.fillAmount = 0;
        isHoldingKey = false;

        if (!isplayingaudio)
        {
            if (!alreadyplayed)
            {
                ASource.clip = clips[0];
                ASource.Play();
                isplayingaudio = true;
                heliidle.Stop();
                alreadyplayed = true;

            }

        }


        float timer = 0.0f;

        while (ro1.speed > 0)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / duration);
            ro1.speed = Mathf.Lerp(initialSpeed, 0, t);
            ro2.speed = Mathf.Lerp(initialSpeed, 0, t);
            yield return new WaitForSeconds(.05f);
        }




        yield return new WaitForSeconds(showComputerUIfor);
        //PlayerPrefs.SetInt("Obj3Status", 0);
        Obj3.SetActive(false);

        //Destroy(this.gameObject);
        //ComputerUI.SetActive(false);



    }

    public IEnumerator DisableChildObjectsCoroutine()
    {




        foreach (GameObject go in objectstodisable)
        {
            go.SetActive(false);
            yield return new WaitForSeconds(0.3f);
        }
    }



}
