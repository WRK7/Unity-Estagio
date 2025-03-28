using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDown : MonoBehaviour
{
    private bool hasDamaged = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasDamaged)
        {
            PlayerLife playerLife = other.GetComponent<PlayerLife>();
            if (playerLife != null)
            {
                playerLife.ReceberDano(1);
                hasDamaged = true;
                Destroy(gameObject);
                Debug.Log("Dano aplicado e objeto destruído!");
            }
        }
    }
}