using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Character character;

    private int _seconds = 25;

    private float timer = 0f;

    private bool _isWin;

    
    private void Awake()
    {
        character = GameObject.Find("Character").GetComponent<Character>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (character.CoinsCount == character.MaxCoinsCount & _seconds > 0)
            Win();

        if (character.CoinsCount < character.MaxCoinsCount & _seconds <= 0)
            Lose();

        if (_isWin == false)
        {
            if (timer >= 1f & _seconds > 0)
            {
                _seconds--;
                timer -= 1f;

                Debug.Log($"Осталось {_seconds} секунд!");
            }
        }
    }
    void Win()
    {
        _isWin = true;
        Debug.Log("Ура, победа!");
    }

    void Lose()
    {
        Debug.Log("Поражение :(");
    }
}
