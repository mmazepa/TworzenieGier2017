using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float Speed = 0.5f;
    public Vector3 direction;

    void Start()
    {
        direction = new Vector3(Speed * 10, 0, 0);
    }

    void Update()
    {
        if(Time.timeScale != 0) {
            transform.Translate(direction * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag == "Enemy"
            || coll.gameObject.tag == "Wall"
            || coll.gameObject.tag == "Finish"
            || coll.gameObject.tag == "Player")
        {
            direction = direction * -1;
        }
    }
}
