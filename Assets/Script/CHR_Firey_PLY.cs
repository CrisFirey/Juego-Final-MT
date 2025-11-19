using UnityEngine;

public class CHR_Firey_PLY : MonoBehaviour
{
    public float force = 100;
    public Rigidbody2D rb;
    public int layer = 3;

    void start()
    {
        if (Input.GetKeyDown((KeyCode.D)))
        {
            gameObject.Component<Rigidbody2D>().AddForce(Vector2.right * force);
        }
        if (Input.GetKeyDown((KeyCode.S)))
        {
            gameObject.Component<Rigidbody2D>().AddForce(Vector2.down * force);
        }
        if (Input.GetKeyDown((KeyCode.A)))
        {
            gameObject.Component<Rigidbody2D>().AddForce(Vector2.left * force);
        }
        if (Input.GetKeyDown((KeyCode.W)))
        {
            gameObject.Component<Rigidbody2D>().AddForce(Vector2.up);
        }
        if (Input.GetKeyDown((KeyCode.Space)))
        {
            gameObject.Component<Rigidbody2D>().AddForce(Vector2.jump * force);
        }
        if (Input.GetKeyDown((KeyCode.Shift + A)))
        {
            gameObject.Component<Rigidbody2D>().AddForce(Vector2.left - 50);
        }
        if (Input.GetKeyDown((KeyCode.Shift + D)))
        {
            gameObject.Component<Rigidbody2D>().AddForce(Vector2.right - 50);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision);
    {
        if (collision.gameObject.layer ==layer)
            Destroy(collision.gameObject)
    }
}
