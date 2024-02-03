using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public Text scoreText;
    public Text timerText;
    
    public float timeLimit = 3; // ตั้งค่าเวลาจำกัด
    private float timer = 90; // ตัวแปรสำหรับเก็บเวลา
    public static int scoreCount;
    void Update()
    {
        // อัพเดตค่าเวลา
        timer -= Time.deltaTime;
        timerText.text = "" + timer;
        scoreText.text = "Score:" + Mathf.Round(scoreCount);

        // เช็คว่าหมดเวลาแล้วหรือไม่
        if (timer <= 0)
        {
            
                Cursor.lockState = CursorLockMode.None;

            // เช็คคะแนน
            if (scoreCount <= 1000)
            {
                SceneManager.LoadScene(2);
                

            }
             if (scoreCount > 1000)
            {
                SceneManager.LoadScene(3);
                
                // ไปหน้า Scene You Win

            }
        }

        // อัพเดตค่าคะแนนและแสดงผล
        scoreText.text = "Score:" + Mathf.Round(scoreCount);
    }
}
