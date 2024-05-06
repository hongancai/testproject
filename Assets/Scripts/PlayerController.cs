using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public int maxHealth = 3;
    private int currentHealth;
    public Text countText;
    public Text hpText;
    public Material normalMaterial;
    private Rigidbody rb;
    private int count;
    private Material originalMaterial;
    public GameObject restartButton;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalMaterial = GetComponent<Renderer>().material;
        currentHealth = maxHealth; 
        restartButton.SetActive(false);
        UpdateUI();
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
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            UpdateUI();
        }
        else if (other.gameObject.CompareTag("Storm"))
        {
            other.gameObject.SetActive(false);
            if (GetComponent<Renderer>().material.color == Color.red)
            {
                return; 
            }
            currentHealth = currentHealth - 1 ;
            UpdateUI();
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }
    
    void Update()
    {
        if (count >= 3 && Input.GetKeyDown(KeyCode.Space))
        {
            Material mat = GetComponent<Renderer>().material;
            mat.color = Color.red;
            count = count - 3;
            UpdateUI();
            StartCoroutine(ResetColorAfterDelay(5f, mat));
        }
    }

    void UpdateUI()
    {
        countText.text = "Energy : " + count.ToString();
        hpText.text = "HP : " + currentHealth.ToString();
    }

    void Die()
    {
        Debug.Log("Restart");
        restartButton.SetActive(true); 
    }

    IEnumerator ResetColorAfterDelay(float delay, Material mat)
    {
        yield return new WaitForSeconds(delay);
        GetComponent<Renderer>().material = normalMaterial;
    }
}
