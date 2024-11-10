using UnityEngine;

public class MedKid : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Hero")
        {
            Destroy(gameObject);
        }
    }
}