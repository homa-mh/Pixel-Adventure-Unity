using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    private PlayerAttack playerAttack;

    void Awake()
    {
        playerAttack = GetComponentInParent<PlayerAttack>();
    }

    public void ShootFireball()
    {
        playerAttack.ShootFireball();
    }

    public void EndAttack()
    {
        playerAttack.EndAttack();
    }
}