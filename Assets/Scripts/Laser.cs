using UnityEngine;

public class Laser : MonoBehaviour
{

    [SerializeField] float speed = 10;

    private Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(0, speed);
    }

}
