using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevel : MonoBehaviour
{
    private AudioSource endoflevelSound;

    private bool levelFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        endoflevelSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !levelFinished)
        {
            levelFinished = true;
            endoflevelSound.Play();
            Invoke("FinishLevel", 2f);
        }
    }

    private void FinishLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
