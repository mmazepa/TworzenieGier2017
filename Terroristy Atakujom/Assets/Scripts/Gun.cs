using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Gun : MonoBehaviour
{
    public Text EnemyHitText;
    public static int EnemyHitCounter;
    public GameObject MuzzleFlash;

    public int ammoCount = 5;
    public bool emptyMagazine = false;
    public Text AmmoText;

    public AudioClip shootSound;
    public AudioClip reloadSound;
    public AudioClip emptyGunSound;
    public AudioClip ouchSound;
    public AudioClip deadSound;
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        EnemyHitText.text = "TERRORISTS HITS : " + EnemyHitCounter + "\nPLAYER HP: " + PlayerHp.Health;
    }

    void Update()
    {
        if (Time.timeScale != 0)
        {
            RaycastHit hit;

            EnemyHitText.text = "TERRORISTS HITS : " + EnemyHitCounter + "\nPLAYER HP: " + PlayerHp.Health;

            if (Physics.Raycast(transform.position, transform.right, out hit))
            {
                if (Input.GetMouseButtonDown(0) && !emptyMagazine)
                {
                    StartCoroutine(MuzzleFlashEnumerator());
                    float vol = 1.0f;
                    source.PlayOneShot(shootSound, vol);
                    ammoCount--;
                    AmmoText.text = ammoCount.ToString();

                    if (hit.transform.gameObject.tag == "Enemy")
                    {
                        EnemyHitCounter++;
                        hit.transform.gameObject.GetComponent<EnemyHp>().TakeHealth(50);
                        if (hit.transform.gameObject.GetComponent<EnemyHp>().Health > 0)
                        {
                            source.PlayOneShot(ouchSound, 2 * vol);
                        }
                        else
                        {
                            source.PlayOneShot(deadSound, vol);
                        }

                        if(hit.transform.gameObject.GetComponent<EnemyHp>().Health <= 50)
                        {
                            hit.transform.gameObject.GetComponent<EnemyMovement>().direction *= 2;
                        }
                    }

                    if (ammoCount <= 0)
                    {
                        emptyMagazine = true;
                    }
                }
                else if (Input.GetMouseButtonDown(0) && emptyMagazine)
                {
                    source.PlayOneShot(emptyGunSound, 2f);
                }

                if (Input.GetKeyDown(KeyCode.R) && emptyMagazine)
                {
                    Reload();
                }
            }
        }
    }

    void Reload()
    {
        ammoCount = 5;
        emptyMagazine = false;
        source.PlayOneShot(reloadSound, 2f);
        AmmoText.text = ammoCount.ToString();
    }

    public IEnumerator MuzzleFlashEnumerator()
    {
        MuzzleFlash.transform.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        MuzzleFlash.transform.gameObject.SetActive(false);
    }
}
