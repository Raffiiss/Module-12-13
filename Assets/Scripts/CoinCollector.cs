using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private Character character;

    private void Awake()
    {
        character = GetComponent<Character>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Coin coin = other.GetComponent<Coin>();

        if (coin != null)
        {
            character.AddCoin();
            coin.gameObject.SetActive(false);
        }
    }
}
