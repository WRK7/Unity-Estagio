using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerLife playerLife = other.GetComponent<PlayerLife>();
            if (playerLife != null)
            {
                playerLife.ReceberDano(-3); 
                Destroy(gameObject);
            }
        }
    }
}