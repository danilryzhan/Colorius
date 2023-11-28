using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // ������ �����
    public float spawnRadius = 5f; // ������������� ������ ��������� ������
    public int maxEnemies = 10; // ������������ ���������� ������
    public float spawnInterval = 2f; // �������� ����� ����������� ������

    private GameObject player;
    private float lastSpawnTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lastSpawnTime = Time.time;
    }

    void Update()
    {
        if (Time.time - lastSpawnTime > spawnInterval && GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemies)
        {
            SpawnEnemy();
            lastSpawnTime = Time.time;
        }
    }

    void SpawnEnemy()
    {
        Vector2 spawnPos;
        float angle = Random.Range(0f, 360f);
        spawnPos = player.transform.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * spawnRadius;

        if (!IsPositionOccupied(spawnPos))
        {
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }

    bool IsPositionOccupied(Vector2 position)
    {
        foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if ((enemy.transform.position - (Vector3)position).magnitude < 1.0f) // ���������, �� ������� �� ������ ������ �����
            {
                return true;
            }
        }
        return false;
    }
}
