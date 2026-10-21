using UnityEngine;
using TMPro;

public class PlayerContolerDemon : MonoBehaviour
{
    public float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
       float moveVertical = Input.GetAxis("Vertical");

       Vector3 direction = new Vector3(moveHorizontal, moveVertical, 0);
       transform.Translate(direction * speed * Time.deltaTime);
    }
}
