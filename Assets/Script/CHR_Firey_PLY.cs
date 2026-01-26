using UnityEngine;
using UnityEngine.InputSystem;





public class CHR_Firey_PLY : MonoBehaviour
{
    public float force = 200;
    public float jumpForce = 200;
    public Rigidbody2D rb;
    public int playerLayer;
    public int wallLayer;
    public int layer = 3;

    public GameObject menu;
    float dir = 0;

    public bool left = true;
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force, ForceMode2D.Force);
            dir += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force, ForceMode2D.Force);

            dir -= 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.down);
        }
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up);
        }
        if (Input.GetKey(KeyCode.O))
        {
            Destroy(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.Return))
        {
            menu.SetActive(!menu.activeInHierarchy);
        }
        dir = Mathf.Clamp(dir,-1,1);
        gameObject.GetComponent<SpriteRenderer>().flipX = dir < 0;
        gameObject.GetComponent<Animator>().SetBool("IsWalking", Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D));
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

