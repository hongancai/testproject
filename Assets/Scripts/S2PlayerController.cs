using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class S2PlayerController : MonoBehaviour
{
    public List<GameObject> capsules;
    public float speed;
    public float interactDistance = 5f; // 與Capsule互動的最大距離
    public Text successText; 
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
		successText.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            RemoveNearestCapsule();
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    private void RemoveNearestCapsule()
    {
        if (capsules.Count == 0)
        {
			successText.enabled = true;
            successText.text = "成功"; 
            return;
        }

        GameObject nearestCapsule = capsules[0];
        float minDistance = Vector3.Distance(transform.position, nearestCapsule.transform.position);

        foreach (GameObject capsule in capsules)
        {
            float distance = Vector3.Distance(transform.position, capsule.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestCapsule = capsule;
            }
        }

        if (minDistance <= interactDistance)
        {
            capsules.Remove(nearestCapsule);
            Destroy(nearestCapsule);
        }
    }
}
