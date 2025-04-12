using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TopDownMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movementInput;
    private SpriteRenderer spriteRenderer; // Для зеркалирования спрайта

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // Отключаем гравитацию
        spriteRenderer = GetComponentInChildren<SpriteRenderer>(); // Получаем SpriteRenderer
    }

    private void Update()
    {
        // Получаем ввод с клавиатуры
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        // Зеркалируем спрайт при движении влево
        if (movementInput.x != 0)
        {
            spriteRenderer.flipX = movementInput.x < 0;
        }
    }

    private void FixedUpdate()
    {
        // Движение персонажа
        rb.velocity = movementInput.normalized * moveSpeed;
    }
}