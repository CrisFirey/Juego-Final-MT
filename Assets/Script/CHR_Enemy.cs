using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] positions;
    private int index = 0;
    private Vector2 objective = new Vector2();

    public float speed = 3;

    private float trueSpeed;

    private float t = 0;

    public int playerLayer = 3;

    private void Start()
    {
        if (positions == null || positions.Length == 0 || positions[0] == null)
        {
            Debug.Log("HOE");
            positions = new Transform[2];
            positions[0] = Instantiate(new GameObject(), transform.position + (Vector3.right * 4), Quaternion.identity).transform;
            positions[1] = Instantiate(new GameObject(), transform.position, Quaternion.identity).transform;
        }

        objective = positions[index].position;
        trueSpeed = speed / 1000;
    }

    private void Update()
    {
        t += Time.deltaTime * trueSpeed;

        transform.position = Vector3.Lerp(transform.position, objective, t);

        if(Vector3.Distance(transform.position, objective) < 0.1f)
        {
            index = (index + 1) % positions.Length;
            objective = positions[index].position;
            t = 0;
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
