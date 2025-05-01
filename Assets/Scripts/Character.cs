using UnityEngine;

public class Character : MonoBehaviour
{
    private string HorizontalAxis = "Horizontal";
    private string VerticalAxis = "Vertical";

    private KeyCode JumpKey = KeyCode.Space;

    private Rigidbody _rigidbody;

    [SerializeField] private float _jumpForce;
    [SerializeField] private float _moveForce;
    [SerializeField] private float _rotationForce;

    private float _xInput;
    private float _yInput;
    private float _deadZone = 0.05f;
    private float timer = 0f;

    private int _maxCoinsCount = 4;
    private int _coinsCount = 0;
    private int _seconds = 25;

    private bool _isJumped;
    private bool _isGrounded;
    private bool _isWin;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_coinsCount == _maxCoinsCount & _seconds > 0)
            Win();

        if (_coinsCount < _maxCoinsCount & _seconds <= 0)
            Lose();

        timer += Time.deltaTime;

        if (_isWin == false)
        {
            if (timer >= 1f & _seconds > 0)
            {
                _seconds--;
                timer -= 1f;

                Debug.Log($"Осталось {_seconds} секунд!");
            }
        }

        _xInput = Input.GetAxis(HorizontalAxis);
        _yInput = Input.GetAxis(VerticalAxis);

        if (Input.GetKeyDown(JumpKey))
            _isJumped = true;    
    }

    private void FixedUpdate()
    {
       
        if (Mathf.Abs(_xInput) > _deadZone)
            _rigidbody.AddTorque(Vector3.up * _rotationForce * _xInput);

        if(Mathf.Abs(_yInput) > _deadZone)
            _rigidbody.AddForce(transform.forward * _moveForce * _yInput, ForceMode.Force);
        
        if (_isJumped & _isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isJumped = false;
        }          
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
            _isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            _isGrounded = false;
    }

    public void AddCoin()
    {
        _coinsCount++;
        Debug.Log($"Количество монет = {_coinsCount}");
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
