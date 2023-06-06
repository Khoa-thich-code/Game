using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;

        // Lấy hướng hiện tại của player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerScale = player.transform.localScale;

        // Kiểm tra hướng của player và quay viên đạn tương ứng
        if (playerScale.x < 0)
        {
            // Quay viên đạn 180 độ
            transform.Rotate(0f, 0f, 180f);
        }
    }
}
