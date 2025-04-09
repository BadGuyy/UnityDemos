using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerControler : MonoBehaviour
{
    public float speed = 10;
    float moveX,moveY;
    int score;

    Rigidbody rb;
    public TextMeshProUGUI scoreText;
    public GameObject winGameObj;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        SetScoreText(score);
        winGameObj.SetActive(false);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void OnMove(InputValue moveValue)
    {
        Vector2 move = moveValue.Get<Vector2>();
        moveX = move.x;
        moveY = move.y;
    }

    void OnJump(InputValue value)
    {
        if(transform.position.y == 0.5f)
            rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(moveX, 0, moveY) * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickupItem"))
        {
            other.gameObject.SetActive(false);
            ++score;
            SetScoreText(score);
            CheckPlayerWin();
        }
    }

    void SetScoreText(int score)
    {
        scoreText.text = "Score: " + score;
    }

    void CheckPlayerWin()
    {
        if(score >= 4)
        {
            winGameObj.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            winGameObj.SetActive(true);
            winGameObj.GetComponent<TextMeshProUGUI>().text = "Game Over";
        }
    }
}
