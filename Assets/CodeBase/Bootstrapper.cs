using System.Threading.Tasks;
using UnityEngine;

namespace CodeBase
{
  public class Bootstrapper : MonoBehaviour
  {
    [SerializeField] private GameObject _curtainPrefab;
    [SerializeField] private SceneLoader _sceneLoader;

    private const string Initial = "Initial";
    private const string Game = "Game";

    private Curtain _curtain;

    private void Awake()
    {
      _curtain = Instantiate(_curtainPrefab).GetComponent<Curtain>();
      LoadFirstScene();
      DontDestroyOnLoad(this);
    }

    private void LoadFirstScene() => _sceneLoader.Load(Initial, EnterLoadLevel);

    private void EnterLoadLevel()
    {
      _curtain.Show();
      _sceneLoader.Load(Game, OnLoaded);
    }

    private async void OnLoaded()
    {
      await InitDependencies();
      _curtain.Hide();
    }

    private async Task InitDependencies() => FindObjectOfType<UIMainController>().Initialize(LoadFirstScene);
  }
}