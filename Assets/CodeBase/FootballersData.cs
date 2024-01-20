using UnityEngine;
using System;

namespace CodeBase
{
  [Serializable]
  public class FootballersData
  {
    public Sprite Image;
    public string Title;
    public string Text;

    public FootballersData(Sprite image, string title, string text)
    {
      Image = image;
      Title = title;
      Text = text;
    }
  }
}