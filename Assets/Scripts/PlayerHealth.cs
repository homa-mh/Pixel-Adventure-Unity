using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("UI")]
    public HeartUI heartUI;

    [Header("Health")]
    public int maxHealth = 5;

    [Header("Damage")]
    public float damageCooldown = 1f;

    private int currentHealth;
    private Animator animator;

    private bool isDead = false;
    private bool canTakeDamage = true;

    public bool IsDead
    {
        get { return isDead; }
    }

    void Start()
    {
        currentHealth = maxHealth;

        animator = GetComponentInChildren<Animator>();

        heartUI.UpdateHearts(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        if (isDead || !canTakeDamage)
            return;

        currentHealth -= damage;
        

        if (currentHealth < 0)
            currentHealth = 0;

        heartUI.UpdateHearts(currentHealth);


        animator.SetTrigger("Hurt");

        canTakeDamage = false;
        Invoke(nameof(ResetDamage), damageCooldown);

        if (currentHealth <= 0)
        {
            Die();
        }else{
            AudioManager.Instance.Play(AudioManager.Instance.playerHurt);
        }

    }

    void ResetDamage()
    {
        canTakeDamage = true;
    }

    void Die()
    {
        isDead = true;

        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerAttack>().enabled = false;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;

        animator.SetBool("Death", true);
        AudioManager.Instance.Play(AudioManager.Instance.gameOver);
        Invoke(nameof(ShowGameOver), 2f);
    }

    void ShowGameOver()
    {
        GameManager.Instance.GameOver();
    }

    public void Heal(int amount)
    {
        if (isDead)
            return;

        currentHealth += amount;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        heartUI.UpdateHearts(currentHealth);

    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
    public bool IsFullHealth()
    {
        return currentHealth >= maxHealth;
    }
}