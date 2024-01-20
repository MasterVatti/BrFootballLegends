using System.Collections.Generic;
using UnityEngine;

namespace CodeBase
{
  [CreateAssetMenu(menuName = "Footballers/Data", fileName = "Footballers")]
  public class FootballersInformation : ScriptableObject
  {
    [SerializeField] private List<FootballersData> _data;

    public List<FootballersData> Data => _data;
  }
}