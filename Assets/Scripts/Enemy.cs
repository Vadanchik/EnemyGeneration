using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;

    private Vector3 _movementDirection;
    
    public void Init(Vector3 position, Vector3 direction)
    {
        transform.position = position;
        _movementDirection = direction;
        transform.rotation = Quaternion.LookRotation(direction);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + _movementDirection, _movementSpeed * Time.deltaTime);
    }
}
