using UnityEngine;

public class PlayerContact : MonoBehaviour
{
    public GameObject hit;

    private PlayerHP playerHP;
    private Animator anim;
    private PlayerMovement playerMovement;

    void Start()
    {
        playerHP = GetComponent<PlayerHP>();
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerHP.Damaged(1);
            GameObject go = Instantiate(hit, transform.position, Quaternion.identity);
            Destroy(go, 1.0f);
            anim.SetTrigger("isHit");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            GameManager.Instance.GameClear();
        }
        else if (collision.gameObject.CompareTag("Tram"))
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("isTram");
            playerMovement.Tram();
        }
        else if (collision.gameObject.CompareTag("DeadZone"))
        {
            GameManager.Instance.GameOver();
        }
        else if (collision.gameObject.CompareTag("Fruit"))
        {
            Destroy(collision.gameObject);
            playerHP.Damaged(-1);
        }
    }
}
