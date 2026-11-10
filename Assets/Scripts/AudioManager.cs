using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource audioSource;

    [Header("Sound Effects")]
    public AudioClip jump;
    public AudioClip fireball;
    public AudioClip fireballHit;
    public AudioClip coin;
    public AudioClip food;
    public AudioClip playerHurt;
    public AudioClip enemyHurt;
    public AudioClip enemyDeath;
    public AudioClip gameOver;
    public AudioClip portal;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    public void Play(AudioClip clip)
    {
        if (clip != null)
            audioSource.PlayOneShot(clip);
    }
}