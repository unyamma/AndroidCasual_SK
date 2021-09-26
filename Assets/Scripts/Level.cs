using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public float hungerlosspm = 200f;
    public float hunger = 100f;
    public float sTimer = 30f;

    public void FixedUpdate()
    {
        hunger -= hungerlosspm / 60 * Time.deltaTime;
        sTimer -= Time.deltaTime;

        if (hunger <= 0 || sTimer <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void feed(Mushroom mushm)
    {
        if (!mushm.reference.edible)
        {
            Debug.Log("U fed kids with poison are u fool?");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (mushm.poison >= 25)
        {
            float f = Random.Range(0, 100);
            if (f < mushm.poison)
            {
                Debug.Log("Very sad but them... ");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        if (mushm.friedon > mushm.tempo_need + mushm.tempo_need / 5)
        {
            Debug.Log("Baked too hard");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (mushm.friedon < mushm.tempo_need - mushm.tempo_need / 5)
        {
            Debug.Log("Too not baked");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        //Debug.Log("Oh.. Well that match");
        hunger += mushm.satiety + Random.Range(mushm.satiety / 2 * -1, mushm.satiety);
    }
}
