using System.Collections;
using UnityEngine;

public class Fireable : MonoBehaviour
{
    [SerializeField] private GameObject _effect;

    private const float Delay = 2;
    private Coroutine _coroutine;
    
    public void OnEnter()
    {
        _effect.SetActive(true);
    }

    public void OnExit()
    {
        if(_coroutine != null)
            StopCoroutine(_coroutine);
        
        _coroutine = StartCoroutine(StoppingEffect());
    }

    private IEnumerator StoppingEffect()
    {
        WaitForSeconds delay = new WaitForSeconds(Delay);
        yield return delay;
        _effect.SetActive(false);
    }
}
