using UnityEngine;

[RequireComponent(typeof(ParticleSystemRenderer))]

public class ParticlesRotator : MonoBehaviour
{
    private ParticleSystemRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<ParticleSystemRenderer>();
    }

    private void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");

        if (inputX > 0)
            _renderer.flip = Vector3.right;
        else if (inputX < 0)
            _renderer.flip = Vector3.zero;
    }
}
