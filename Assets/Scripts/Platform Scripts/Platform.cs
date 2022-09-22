using UnityEngine;

public enum EPlatform
{
    normal,
    movingLeft,
    movingRight,
    breakable,
    spike
}

public class Platform : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float boundY = 6f;
    public EPlatform ePlatform;

    private Animator anim;

    private void Awake()
    {
        if (ePlatform == EPlatform.breakable)
            anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 temp = transform.position;
        temp.y += moveSpeed * Time.deltaTime;
        transform.position = temp;
        if (temp.y >= boundY)
        {
            gameObject.SetActive(false);
        }
    }

    private void BreakableDeactive()
    {
        Invoke("DeactivateGameObject", .5f);
    }

    private void DeactivateGameObject()
    {
        SoundManager.instance.IceBreakSound();
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Player"))
        {
            if (ePlatform == EPlatform.spike)
            {
                target.transform.position = new Vector2(1000f, 1000f);
                SoundManager.instance.GameOverSound();
                GameManager.instance.RestartGame();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Player"))
        {
            if (ePlatform == EPlatform.breakable)
            {
                SoundManager.instance.LandSound();
                anim.Play("break");
            }
            else if (ePlatform == EPlatform.normal || ePlatform == EPlatform.movingLeft || ePlatform == EPlatform.movingRight)
            {
                SoundManager.instance.LandSound();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Player"))
        {
            if (ePlatform == EPlatform.movingLeft)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(-1f);
            }
            else if (ePlatform == EPlatform.movingRight)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(1f);
            }
        }
    }
}