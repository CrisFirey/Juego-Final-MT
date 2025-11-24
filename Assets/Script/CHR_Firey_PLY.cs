using UnityEngine;
using UnityEngine.InputSystem;





public class CHR_Firey_PLY : MonoBehaviour
{
    public float force = 50;
    public Rigidbody2D rb;
    public int playerLayer;
    public int wallLayer;
    public int layer = 3;

    public bool left = true;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.down * force, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Destroy(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
    }
    void Start()
    {
        gameObject.TryGetComponent(out rb);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == layer)
            Destroy(collision.gameObject);
    }
}

