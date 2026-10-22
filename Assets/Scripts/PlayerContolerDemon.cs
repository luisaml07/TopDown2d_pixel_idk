using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerContolerDemon : MonoBehaviour
{
    public float speed = 5f;
    public int score = 0;
    public bool hasColectableKey = false;
    // public bool hascentipede = false;
    public TextMeshProUGUI textScore;
	public TextMeshProUGUI notificationText;
    public GameObject gameOverPanel;
    public GameObject winPanel;

    private bool gameEnded = false;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
        UpdateTextScore();
    }

    // Update is called once per frame
    void Update()
    {
        // Si el juego terminó, solo permitimos reiniciar con R
        if (gameEnded)
        {
            if (Input.GetKeyDown(KeyCode.R)) RestartLevel();
            return;
        }
       // Leemos la entrada del teclado WASD o Flechas
       float moveHorizontal = Input.GetAxis("Horizontal");
       float moveVertical = Input.GetAxis("Vertical");

       Vector3 direction = new Vector3(moveHorizontal, moveVertical, 0);
       transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameEnded) return;

        // Muerte por el Centipede
        if (other.CompareTag("centipede"))
        {
            Die();
            return;
        }
                /* Aquí se guardrán los puntos ganados*/
        int pointsGained = CalculatePointByTag (other.tag);

        if (pointsGained > 0)
        {
            score = score + pointsGained;
            /*o puede ser-> score += pointGained;*/
            UpdateTextScore();
            ShowNotification("+" + pointsGained + "points!");
            Destroy(other.gameObject);
        }



		if (other.CompareTag("ColectableKey"))
        {
            hasColectableKey = true;
			Debug.Log("You got the Key!");
			ShowNotification("You got the Key!");
			Destroy(other.gameObject);
		}
		/* if (other.CompareTag("centipede"))
		{
			hascentipede = true;
			Debug.Log("You has touched the Centipede and cannot win");
			ShowNotification("You has touched the Centipede and cannot win");
		} Inhabilitamos para que se pueda reiniciar si lo toca */


		// WIN condition
		/*if (score >= 40 && hasColectableKey == true && !hascentipede)
		{
			Debug.Log("You Won!");
			ShowNotification("You Won!");
		} */
        if (score >= 40 && hasColectableKey)
        {
            Debug.Log("You Won!");
			ShowNotification("You Won!");
            Win();
        }
	}
    void Die()
    {
        gameEnded = true;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f; // Congela el juego
    }
    void Win()
    {
        gameEnded = true;
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    // "Reintentar"
    public void RestartLevel()
    {
        Time.timeScale = 1f; // restaurar antes de recargar
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void UpdateTextScore ()
    {
        textScore.text = "Score: " + score;
    }

    void ShowNotification(string message)
    {
        notificationText.text = message;
    }

    int CalculatePointByTag (string objectTag)
    {
        if (objectTag == "Colectable")
        {
            return 1;
        }
        else if (objectTag == "Colectable2")
        {
           return 2; 
        }
        else if (objectTag == "Colectable3")
        {
            return 3;
        }
        else
        {
           return 0; 
        }
        
    }

}
