using UnityEngine;
using DG.Tweening;


public class S2StormController : MonoBehaviour
{
    public float minX = -3.52f;
    public float maxX = 3.52f;
    public float minZ = -2.74f;
    public float maxZ = 2.74f;
    public float moveDuration = 1f;

    private void Start()
    {
        SetRandomTargetPosition();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SetRandomTargetPosition();
        }
    }

    private void SetRandomTargetPosition()
    {
        Vector3 randomTargetPosition = new Vector3(Random.Range(minX, maxX), transform.position.y, Random.Range(minZ, maxZ));
        transform.DOMove(randomTargetPosition, moveDuration).SetEase(Ease.Linear).OnComplete(SetRandomTargetPosition);
    }
}
