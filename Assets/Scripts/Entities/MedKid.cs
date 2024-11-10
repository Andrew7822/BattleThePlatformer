using UnityEngine;

public class MedKid : MonoBehaviour
{
    private string _tagHero = "Hero";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == _tagHero)
        {
            Destroy(gameObject);
        }
    }
}