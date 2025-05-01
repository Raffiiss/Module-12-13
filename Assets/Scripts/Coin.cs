using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();
        
        if(character != null )
        {
            character.AddCoin();
            gameObject.SetActive(false);
        }
    }
}
