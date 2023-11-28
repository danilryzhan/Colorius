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
    public TMP_Text scoreText; // Ссылка на текстовый UI элемент для отображения счёта
    private float score; // Текущий счёт
    private float timer; // Таймер для отслеживания времени
    private float interval = 4f; // Интервал времени для вызова метода (4 секунды)

    void Update()
    {
        UpdateScore(Time.deltaTime); // Обновляем счёт
        DisplayScore(); // Отображаем счёт

        // Обновляем таймер и проверяем, не пора ли вызвать метод
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            timer = 0f; // Сброс таймера
            EveryFourSeconds(); // Вызов метода каждые 4 секунды
        }
    }

    void UpdateScore(float time)
    {
        if (isend!=true)
        {
            score += time;  // Например, 1 очко за каждую секунду
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
        // Код, который нужно выполнить каждые 4 секунды
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Перезагрузка текущей сцены
    }


}
