using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public int healamount = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().Heal(healamount);
            Destroy(gameObject);
        }

    }

}
