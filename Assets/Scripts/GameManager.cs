using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Play()
    {
        StartCoroutine(Playgame());

    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);

    }

    public void restart()
    {
        SceneManager.LoadScene("GetCurrentScene.BuildIndex");
    }

    public void Quit()
    {
        Application.Quit();

    }

    public IEnumerator Playgame()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
        yield break;
    }
}
