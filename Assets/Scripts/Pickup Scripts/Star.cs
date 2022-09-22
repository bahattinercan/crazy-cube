using UnityEngine;

public class Star : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore(25);
            SoundManager.instance.StarSound();
            Destroy(this.gameObject);
        }
    }
}