using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform firePoint;

    private Animator animator;

    private bool isFacingRight = true;
    private bool isAttacking = false;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        if (move > 0)
            isFacingRight = true;
        else if (move < 0)
            isFacingRight = false;

        if (Input.GetKeyDown(KeyCode.F) && !isAttacking)
        {
            isAttacking = true;
            animator.SetTrigger("Attack");
        }
    }

    public void ShootFireball()
    {
        GameObject fireball = Instantiate(
            fireballPrefab,
            firePoint.position,
            Quaternion.identity);

        Fireball projectile = fireball.GetComponent<Fireball>();

        projectile.SetDirection(isFacingRight);
        AudioManager.Instance.Play(AudioManager.Instance.fireball);

        Destroy(fireball, 1f);
    }

    public void EndAttack()
    {
        isAttacking = false;
    }
}