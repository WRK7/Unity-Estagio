using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoCirculo : MonoBehaviour
{
    public int Damage = 1;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerLife playerLife = other.GetComponent<PlayerLife>();
            if (playerLife != null)
            {
                playerLife.ReceberDano(Damage);
            }
        }
    }
}