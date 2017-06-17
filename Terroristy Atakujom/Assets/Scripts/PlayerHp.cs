using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHp : MonoBehaviour
{
    public static int Health;
    public bool Invisible = false;

    public AudioClip ouchSound;
    private AudioSource source;

    public void Awake()
    {
        Health = 100;
        source = GetComponent<AudioSource>();
    }

    public void TakeHealth(int hp)
    {
        Health -= hp;

        if (Health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy" && Invisible == false)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHp>().TakeHealth(10);
            source.PlayOneShot(ouchSound, 1f);
            StartCoroutine(Wait());
        }
    }

    public IEnumerator Wait()
    {
        Invisible = true;
        yield return new WaitForSeconds(0.5f);
        Invisible = false;
    }
}
