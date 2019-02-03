using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playercontroller : MonoBehaviour
{

    public float speed;

    private Rigidbody rb;
    private int point;
    public Text pointtext;
    private int count;
    public Text countText;
    public Text winText;
    private int danger;
    private int lives;
    public Text livestext;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        point = 0;
        Setpointtext();
        danger = 0;
        lives = 3;
        setlivestext();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            point = count - danger;
            Setpointtext();
        }
        else if (other.gameObject.CompareTag("danger"))
        {
            lives = lives - 1;
            setlivestext();
            danger = danger + 1;
            other.gameObject.SetActive(false);
            point = count - danger;
            Setpointtext();
        }
    }
    void SetCountText()
    {
        countText.text = "The Total Count:" + count.ToString();
        if (count == 12)
            rb.MovePosition(new Vector3(75, 0, 0));
    
    }
    void Setpointtext()
    {
        pointtext.text = "Points:" + point.ToString();
        if (point >= 20)
        {
            winText.text = "You Win! Horray!";
        }

    }
    void setlivestext ()
    {
        livestext.text = "Lives:" + lives.ToString();
        if (lives <= 0)
        {
            winText.text = "You Lose";
            Destroy(rb);
        }
          }

}