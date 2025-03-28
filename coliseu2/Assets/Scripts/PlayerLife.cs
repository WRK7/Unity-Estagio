using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{   
    public Slider Vida;
    private bool isDead = false;
    private PlayerController playerController;

    void Start()
    {
        Vida.value = 100f;
        Vida.maxValue = 100f;
        playerController = GetComponent<PlayerController>();
        if (playerController == null)
        {
            Debug.LogError("PlayerController não encontrado no mesmo objeto!");
        }
    }

    void Update()
    {
        if (Vida.value <= 0 && !isDead)
        {
            Die();
        }
    }

    public void ReceberDano(int dano)
    {
        if (isDead) return;

        Vida.value -= dano;
        Vida.value = Mathf.Clamp(Vida.value, 0, 100f);
        Debug.Log("Vida atual: " + Vida.value);
    }

    void Die()
    {
        isDead = true;
        if (playerController != null)
        {
            playerController.Die();
        }
        Debug.Log("Personagem morreu no PlayerLife!");
    }
}