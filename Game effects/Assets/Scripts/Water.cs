using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private GameObject _effect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector2 contactPoint = other.ClosestPoint(transform.position);
        Instantiate(_effect, contactPoint, Quaternion.identity);
    }
    
    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     Physics2D.IgnoreCollision(other.collider, other.otherCollider);
    //     Instantiate(_effect, other.GetContact(0).point, Quaternion.identity);
    // }
}