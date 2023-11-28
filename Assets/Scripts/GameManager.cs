using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public EnemySpawner spawner;
    int level = 0;
    private bool isend = false;
    public GameObject endgame;
    public TMP_Text scoreText; // ������ �� ��������� UI ������� ��� ����������� �����
    private float score; // ������� ����
    private float timer; // ������ ��� ������������ �������
    private float interval = 4f; // �������� ������� ��� ������ ������ (4 �������)

    void Update()
    {
        UpdateScore(Time.deltaTime); // ��������� ����
        DisplayScore(); // ���������� ����

        // ��������� ������ � ���������, �� ���� �� ������� �����
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            timer = 0f; // ����� �������
            EveryFourSeconds(); // ����� ������ ������ 4 �������
        }
    }

    void UpdateScore(float time)
    {
        if (isend!=true)
        {
            score += time;  // ��������, 1 ���� �� ������ �������
        }
        
    }

    void DisplayScore()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + Mathf.RoundToInt(score).ToString()+"         Level:"+level;
        }
    }

    void EveryFourSeconds()
    {
        // ���, ������� ����� ��������� ������ 4 �������
        score += level;
        if(level<=30 && isend ==false)
        {
         level++;
        
         spawner.spawnInterval -= 0.05f;

        }
        
    }

    public void EndGame()
    {

        endgame.SetActive(true);
        endgame.GetComponentInChildren<TMP_Text>().text= scoreText.text; 
        isend= true;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // ������������ ������� �����
    }


}
