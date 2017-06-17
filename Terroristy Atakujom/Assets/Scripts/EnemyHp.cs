using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    public int Health = 100;

    public void TakeHealth(int hp)
    {
        Health -= hp;

        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }


}
