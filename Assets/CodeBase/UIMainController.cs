using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace CodeBase
{
  public class UIMainController : MonoBehaviour
  {
    [SerializeField] private FootballersInformation _footballersInformation;
    [SerializeField] private Button _startButton;
    // [SerializeField] private Button _previousActorButton;
    [SerializeField] private Button _previousArrowButton;
    [SerializeField] private Button _nextFootballerButton;
    [SerializeField] private Button _lobbyExitButton;
    [SerializeField] private Image _background;
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private Sprite _secondBackground;

    private int _counter;
    private Action _loadFirstScene;

    private void Awake()
    {
      _counter = 0;
      _startButton.onClick.AddListener(OnActorsButtonClicked);
      _lobbyExitButton.onClick.AddListener(Application.Quit);
    }

    public void Initialize(Action loadFirstScene) => _loadFirstScene = loadFirstScene;

    private void OnActorsButtonClicked()
    {
      _startButton.gameObject.SetActive(false);
      _lobbyExitButton.gameObject.SetActive(false);
      
      _background.sprite = _secondBackground;
      MoveNextActor();
      // _previousActorButton.gameObject.SetActive(true);
      _previousArrowButton.gameObject.SetActive(true);
      _nextFootballerButton.gameObject.SetActive(true);
      _image.gameObject.SetActive(true);
      _title.gameObject.SetActive(true);
      _text.gameObject.SetActive(true);
      _nextFootballerButton.onClick.AddListener(MoveNextActor);
      // _previousActorButton.onClick.AddListener(MovePreviousActor);
      _previousArrowButton.onClick.AddListener(MovePreviousActor);
    }

    private void MovePreviousActor()
    {
      if (_counter >= _footballersInformation.Data.Count)
      {
        _nextFootballerButton.GetComponentInChildren<TextMeshProUGUI>().text = "Next";
        _nextFootballerButton.onClick.RemoveListener(BackToMenu);
        _nextFootballerButton.onClick.AddListener(MoveNextActor);
      }
      
      _counter -= 1;
      if (_counter <= 0)
      {
        _loadFirstScene.Invoke();
        return;
      }

      _title.text = _footballersInformation.Data[_counter - 1].Title;
      _image.sprite = _footballersInformation.Data[_counter - 1].Image;
      _text.text = _footballersInformation.Data[_counter - 1].Text;
    }

    private void MoveNextActor()
    {
      _title.text = _footballersInformation.Data[_counter].Title;
      _image.sprite = _footballersInformation.Data[_counter].Image;
      _text.text = _footballersInformation.Data[_counter].Text;

      if (_counter >= _footballersInformation.Data.Count - 1)
      {
        _nextFootballerButton.GetComponentInChildren<TextMeshProUGUI>().text = "To menu";
        _nextFootballerButton.onClick.RemoveListener(MoveNextActor);
        _nextFootballerButton.onClick.AddListener(BackToMenu);
      }

      _counter += 1;
    }

    private void BackToMenu() => _loadFirstScene.Invoke();
  }
}