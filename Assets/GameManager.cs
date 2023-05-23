using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Ambiance1");
        FindObjectOfType<AudioManager>().Play("Ambiance2");
        FindObjectOfType<AudioManager>().Play("Ambiance3");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
        }
    }
}
