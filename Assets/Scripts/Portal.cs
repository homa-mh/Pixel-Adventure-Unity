using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [Header("Next Scene")]
    public string nextScene;

    [Header("Delay")]
    public float loadDelay = 2f;

    [Header("Effect")]
    public GameObject disappearEffect;

    private bool entered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (entered)
            return;

        if (!other.CompareTag("Player"))
            return;

        entered = true;

        PlayerMovement movement = other.GetComponent<PlayerMovement>();
        if (movement != null)
            movement.enabled = false;

        PlayerAttack attack = other.GetComponent<PlayerAttack>();
        if (attack != null)
            attack.enabled = false;

        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.velocity = Vector2.zero;

        AudioManager.Instance.Play(AudioManager.Instance.portal);

        if (disappearEffect != null)
        {
            Instantiate(
                disappearEffect,
                other.transform.position,
                Quaternion.identity);
        }

        SpriteRenderer[] renderers =
            other.GetComponentsInChildren<SpriteRenderer>();

        foreach (SpriteRenderer sr in renderers)
        {
            sr.enabled = false;
        }

        TrailRenderer trail = other.GetComponentInChildren<TrailRenderer>();
        if (trail != null)
            trail.enabled = false;

        StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(loadDelay);

        Time.timeScale = 1f;
        SceneManager.LoadScene(nextScene);
    }
}