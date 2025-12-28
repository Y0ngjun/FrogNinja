using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    public float moveDistance;
    public float moveSpeed;

    private float maxHeight;
    private float minHeight;
    private int direction;

    void Start()
    {
        maxHeight = transform.position.y + moveDistance / 2f;
        minHeight = maxHeight - moveDistance;
        direction = 1;
    }

    void Update()
    {
        transform.position += new Vector3(0, direction * moveSpeed * Time.deltaTime, 0);

        if(transform.position.y > maxHeight)
        {
            direction = -1;
        }
        else if(transform.position.y < minHeight)
        {
            direction = 1;
        }
    }
}
