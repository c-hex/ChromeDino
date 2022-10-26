using UnityEngine;

public class GameOverCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.CompareTag("Hurdle"))
        {
            GameStateManager.Instance.GameOver();
        }
    }
}