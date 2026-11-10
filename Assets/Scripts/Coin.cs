using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (!other.CompareTag("Player"))
            return;

        ScoreManager.Instance.AddCoin(value);

        AudioManager.Instance.Play(AudioManager.Instance.coin);

        Destroy(gameObject);
    }
}