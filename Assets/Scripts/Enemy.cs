using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public int maxHealth = 3;
    public float moveSpeed = 2f;
    public float patrolDistance = 3f;

    private int currentHealth;
    private Animator animator;

    private Vector3 startPosition;
    private bool movingRight = true;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponentInChildren<Animator>();

        startPosition = transform.position;
    }

    void Update()
    {
        if (isDead)
            return;

        Patrol();
    }

    void Patrol()
    {
        float direction = movingRight ? 1 : -1;

        transform.Translate(Vector2.right * direction * moveSpeed * Time.deltaTime);

        animator.SetFloat("Speed", 1);

        if (movingRight &&
            transform.position.x >= startPosition.x + patrolDistance)
        {
            movingRight = false;
            Flip();
        }

        if (!movingRight &&
            transform.position.x <= startPosition.x - patrolDistance)
        {
            movingRight = true;
            Flip();
        }
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
            return;

        currentHealth -= damage;
        AudioManager.Instance.Play(AudioManager.Instance.enemyHurt);

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        animator.SetBool("Dead", true);
        AudioManager.Instance.Play(AudioManager.Instance.enemyDeath);
        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        PlayerHealth player =
            collision.gameObject.GetComponent<PlayerHealth>();

        if (player != null)
            player.TakeDamage(1);
    }
}
}