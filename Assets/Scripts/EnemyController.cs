using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    
    private bool _isMoving;

    public void Init()
    {
        _isMoving = true;
    }
    
    private void Update()
    {
        if (_isMoving)
        {
            Move();
        }
    }

    private void Move()
    {
        transform.Translate(Vector3.up * (moveSpeed * Time.deltaTime));        
    }
}
