using UnityEngine;

[CreateAssetMenu(fileName = "GameStats", menuName = "Game Stats")]
public class GameStatsSO:ScriptableObject
{
    [field:SerializeField] public string PlayerName { get; set; }
    [field:SerializeField]  public int PlayerScore { get; set; }
    [field:SerializeField]  public int CurrentMapIndex { get; set; }
    [field:SerializeField] public int TotalMaps { get; set; } = 2; 
  
    public void ResetStats()
    {
        PlayerScore = 0;
        CurrentMapIndex = 0;
    }
}
