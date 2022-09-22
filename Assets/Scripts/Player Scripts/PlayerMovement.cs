using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myBody;
    private bool leftButton, rightButton;

    public float moveSpeed = 2f;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        leftButton = false;
        rightButton = false;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetAxisRaw(MyStrings.movementX) > 0f || (leftButton == false && rightButton == true))
        {
            MoveRight();
        }
        if (Input.GetAxisRaw(MyStrings.movementX) < 0f || (leftButton == true && rightButton == false))
        {
            MoveLeft();
        }
    }

    private void MoveLeft()
    {
        myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
    }

    private void MoveRight()
    {
        myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
    }

    public void PlatformMove(float x)
    {
        myBody.velocity = new Vector2(x, myBody.velocity.y);
    }

    public void LeftButtonDown()
    {
        leftButton = true;
    }

    public void LeftButtonUp()
    {
        leftButton = false;
    }

    public void RightButtonDown()
    {
        rightButton = true;
    }

    public void RightButtonUp()
    {
        rightButton = false;
    }
}