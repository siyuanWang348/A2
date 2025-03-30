using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 80f;

    public void MoveLeft()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    public void MoveRight()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }
}
