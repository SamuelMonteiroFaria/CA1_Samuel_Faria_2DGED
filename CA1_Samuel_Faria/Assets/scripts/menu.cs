using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    public void Quit()
    {
        Application.Quit();
    }
}
