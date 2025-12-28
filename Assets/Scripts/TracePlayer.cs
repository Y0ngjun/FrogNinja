using UnityEngine;

public class TracePlayer : MonoBehaviour
{
    public GameObject target;
    public float offsetY;

    void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (target != null)
        {
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y + offsetY, transform.position.z);
        }
    }
}
