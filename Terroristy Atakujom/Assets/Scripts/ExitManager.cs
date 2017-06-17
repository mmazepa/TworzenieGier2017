using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitManager : MonoBehaviour {

    Scene currentScene;
    string sceneName;
    public GameObject noMeme;

    public AudioClip killZemAll;
    public AudioClip wellDone;
    public AudioSource source;

    private bool allKilled = false;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        source = GetComponent<AudioSource>();
    }

	void Update () {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            GameObject.FindGameObjectWithTag("Finish")
                .transform.gameObject.GetComponent<Renderer>()
                .material.color = Color.green;
            if (allKilled == false)
            {
                allKilled = true;
                source.PlayOneShot(wellDone, 2f);
            }
        } else
        {
            GameObject.FindGameObjectWithTag("Finish")
                .transform.gameObject.GetComponent<Renderer>()
                .material.color = Color.red;
        }
	}

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && GameObject.FindGameObjectsWithTag("Enemy").Length != 0)
        {
            StartCoroutine(ExitNo());
            source.PlayOneShot(killZemAll, 1f);
        }

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            if (sceneName == "Level1")
            {
                SceneManager.LoadScene("Level2");
            }
            else if (sceneName == "Level2")
            {
                SceneManager.LoadScene("Level3");
            }
            else if (sceneName == "Level3")
            {
                Gun.EnemyHitCounter = 0;
                SceneManager.LoadScene("Credits");
            }
            PlayerHp.Health = 100;
        }
    }

    public IEnumerator ExitNo()
    {
        noMeme.transform.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        noMeme.transform.gameObject.SetActive(false);
    }
}
