using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    GameManager gameManager;
    public GameObject particleDead ;
    bool istachedPlayer = false;
    private GameObject player;
    private Vector2 directionToPlayer;
    private Color[] colors = { Color.red, Color.blue, Color.white, Color.yellow };

    private void Awake()
    {
          gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();   
    }
    void Start()
    {
       
        particleDead = GameObject.Find("Particle System");
        player = GameObject.FindGameObjectWithTag("Player");
        AssignRandomColor();
        SetDirectionToPlayer();
    }

    void Update()
    {
        MoveInDirection();
    }

    void AssignRandomColor()
    {
        Color randomColor = colors[Random.Range(0, colors.Length)];
        GetComponent<SpriteRenderer>().color = randomColor;
    }

    void SetDirectionToPlayer()
    {
        if (player != null)
        {
            // ”станавливаем направление движени€ к игроку в момент создани€ врага
            directionToPlayer = (player.transform.position - transform.position).normalized;
        }
    }

    void MoveInDirection()
    {
        // ƒвигаем врага в установленном направлении
        transform.position += (Vector3)directionToPlayer * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            istachedPlayer = true;
            Color playerColor = player.GetComponent<SpriteRenderer>().color;
            Color enemyColor = GetComponent<SpriteRenderer>().color;
            if (playerColor != enemyColor)
            {
                player.GetComponent<SpriteRenderer>().enabled = false;
                particleDead.GetComponent<ParticleDead>().OnPlay(directionToPlayer,playerColor);
                gameManager.EndGame();
                // «десь код дл€ обработки смерти игрока
            }
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Playground") && istachedPlayer == true)
        {
            Destroy(gameObject); // ”ничтожаем врага при столкновении с границей
        }
    }


}
