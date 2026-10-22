using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingWall : MonoBehaviour
{
    public float speed = 1f;
    public float minimum = -1.0F;
    public float maximum = 1.0F;
    static float t = 0.0f;

    private void Awake()
    {
        minimum = gameObject.transform.position.x;
    }
    private void Update()
    {
        
        //Vector3.Lerp(transform.position.x, Vector3.left, speed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Lerp(minimum, maximum, t), transform.position.y, 0);

        t += 0.5f * Time.deltaTime;

        if (t > 1.0f)
        {
            float temp = maximum;   
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }

    }
}
