using System.Collections;
using UnityEngine;

namespace CodeBase
{
  public class Curtain : MonoBehaviour
  {
    [SerializeField] CanvasGroup _curtain;

    private void Awake()
    {
      DontDestroyOnLoad(this);
    }

    public void Show()
    {
      gameObject.SetActive(true);
      _curtain.alpha = 1;
    }
    
    public void Hide() => StartCoroutine(DoFadeIn());
    
    private IEnumerator DoFadeIn()
    {
      yield return new WaitForSeconds(0.4f);
      while (_curtain.alpha > 0)
      {
        _curtain.alpha -= 0.03f;
        yield return new WaitForSeconds(0.03f);
      }
      
      gameObject.SetActive(false);
    }
  }
}