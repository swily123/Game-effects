using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _effect;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = _camera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, 100f))
            {
                var effect = Instantiate(_effect, hit.point, Quaternion.identity); //Quaternion.LookRotation(hit.normal)
                effect.transform.rotation = Quaternion.FromToRotation(effect.transform.forward, hit.normal) * effect.transform.rotation;
            }
        }
    }
}
