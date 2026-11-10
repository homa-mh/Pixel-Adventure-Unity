using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float speed = 0.2f;

    public float leftLimit = -12f;
    public float rightLimit = 12f;

    void Update()
    {
        transform.localPosition += Vector3.left * speed * Time.deltaTime;

        if (transform.localPosition.x < leftLimit)
        {
            transform.localPosition = new Vector3(
                rightLimit,
                transform.localPosition.y,
                transform.localPosition.z);
        }
    }
}