using UnityEditor;
using UnityEngine;

public class CHR_Enemy_Basic: MonoBehaviour
{
    public Rigidbody2D rb;
    public int playerLayer;
    public int wallLayer;

    public int force = 2;

    public bool left = true;

    void Start()
    {
        gameObject.TryGetComponent(out rb);
    }
    void Update()
    {
        if (left)
        {
            rb.AddForce(Vector2.left * force);
        }
        else
        {
            rb.AddForce(Vector2.right * force);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == playerLayer)
        {
            Destroy(collision.gameObject);
        }
    }
}