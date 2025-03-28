using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuraCirculo : MonoBehaviour
{
    public int Heal = 1;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerLife playerLife = other.GetComponent<PlayerLife>();
            if (playerLife != null)
            {
                playerLife.ReceberDano(-Heal);
            }
        }
    }
}