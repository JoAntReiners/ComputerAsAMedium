using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    private Rigidbody rb;
    private int count;
    private int score;
    public Text pickupText;
    public GameObject Player;
    public bool moved;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        moved = false;
        SetAllText();
        winText.text = "";
        
    }

    private void Update()
    {
        if(Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float red = Mathf.Abs(Player.transform.position.x / 10);
        float green = Mathf.Abs(Player.transform.position.y / 20);
        float blue = Mathf.Abs(Player.transform.position.z / 10);
        Color colornow = new Vector4(red, green, blue, 0.0f);

        Player.GetComponent<Renderer>().material.color = colornow;
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement*speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score + 1;
            SetAllText();
        }
        else if(other.gameObject.CompareTag("Bad Pick Up"))
        {
            other.gameObject.SetActive(false);
            score = score - 1;
            SetAllText();
        }
       /* else if(other.gameObject.CompareTag("Bad Wall"))
        {
            score = score - 1;
            SetAllText();
            StartCoroutine(Pause());
        }*/

        if (count == 12 && moved == false)
        {
            moved = true;
            transform.position = new Vector3(-7.0f, -19.5f, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bad Wall"))
        {
            score = score - 1;
            SetAllText();
        }
    }

    void SetAllText()
    {
        countText.text = "Score : " + score.ToString();
        pickupText.text = "Pickups Collected: " + count.ToString();
        if (count >= 24)
        {
            winText.text = "You won the game with a score of: " + score.ToString() ;
        }
    }

    //-8 -9.5 -3
    
}
