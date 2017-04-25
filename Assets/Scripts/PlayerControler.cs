using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;
    private bool pause = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        if (other.gameObject.CompareTag("Pick Up") && pause == false)
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Bad Guy"))
        {
            //rb.gameObject.SetActive(false);
            pause = true;
            winText.text = "You Have Lost";
            StartCoroutine(Load(5, "MiniGamePlusSeek"));
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count == 8)
        {
            winText.text = "You Have Won";
            StartCoroutine(Load(5, "MiniGamePlusSeek"));
        }
    }
    IEnumerator Load(int delay, string level)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(level);
        if (pause == true)
            pause = false;
    }

}
