using Unity.VisualScripting;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public int hazardDamage = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("player collided");
            collision.gameObject.GetComponent<Player>().TakeDamage(hazardDamage);
        }
    }
}