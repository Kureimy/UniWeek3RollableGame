using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;
    public float speed = 1;
    void Update()
    {
        Vector3 targetPos = Vector3.Lerp(transform.position, target.transform.position + offset, speed * Time.deltaTime);
        transform.position = targetPos;
        transform.LookAt(target.transform.position);
    }
}
