using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;
	private int pointsToWin;
	public Transform pivot;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
		pointsToWin = 64;

		pivot.transform.position = transform.position;
		//pivot.transform.parent = player.transform;
    }

    void FixedUpdate()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
		float moveHorizontal = Input.GetAxis("Horizontal");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		Vector3 relativeMovement = pivot.transform.TransformVector(movement);
		//relativeMovement *= Vector3.right + Vector3.forward;
       rb.AddForce(relativeMovement * speed);

		//rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
		if (count >= pointsToWin)
        {
            winText.text = "You Win!";
        }
    }
}