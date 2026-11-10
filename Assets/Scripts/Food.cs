using UnityEngine;

public class Food : MonoBehaviour
{
    [Header("Food")]
    public int healAmount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth == null)
            return;

        if (playerHealth.IsFullHealth())
            return;

        playerHealth.Heal(healAmount);

        AudioManager.Instance.Play(AudioManager.Instance.food);

        Destroy(gameObject);
    }
}