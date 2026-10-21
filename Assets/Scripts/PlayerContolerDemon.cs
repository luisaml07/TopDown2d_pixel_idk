using UnityEngine;
using TMPro;

public class PlayerContolerDemon : MonoBehaviour
{
    public float speed = 5f;
    public int score = 0;
    public bool hasColectableKey = false;
    public bool hascentipede = false;
    public TextMeshProUGUI textScore;
	public TextMeshProUGUI notificationText;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        UpdateTextScore();
    }

    // Update is called once per frame
    void Update()
    {
       // Leemos la entrada del teclado WASD o Flechas
       float moveHorizontal = Input.GetAxis("Horizontal");
       float moveVertical = Input.GetAxis("Vertical");

       Vector3 direction = new Vector3(moveHorizontal, moveVertical, 0);
       transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
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
		if (other.CompareTag("centipede"))
		{
			hascentipede = true;
			Debug.Log("You has touched the Centipede and cannot win");
			ShowNotification("You has touched the Centipede and cannot win");
		}


		// WIN condition
		if (score >= 3 && hasColectableKey == true && !hascentipede)
		{
			Debug.Log("You Won!");
			ShowNotification("You Won!");
		}
		

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
