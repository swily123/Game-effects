using UnityEngine;

public class Bonfire : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent(out Fireable fireableObject))
        {
            fireableObject.OnEnter();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.TryGetComponent(out Fireable fireableObject))
        {
            fireableObject.OnExit();
        }
    }
}
