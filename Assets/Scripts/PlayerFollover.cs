using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerFollover : MonoBehaviour
{
    [SerializeField] private Hero _hero;

    private void Update()
    {
        Vector3 _watchPoint = new Vector3(0, 0, -10);

        transform.position = Vector3.Lerp(transform.position, _hero.transform.position + _watchPoint, Time.deltaTime);
    }
}
