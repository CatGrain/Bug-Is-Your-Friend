using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    public Text PlayerPoints;  
    public Text AiPoints;

    public int playerPointsInfo;
    public int aiPointsInfo;

    private void Start()
    {
        MemoryGameEvents.current.addAiPoints += AddAiPoints;
        MemoryGameEvents.current.addPlayerPoints += AddPlayerPoints;
    }

    void AddPlayerPoints()
    {
        int playerPoints = int.Parse(PlayerPoints.text);
        playerPoints++;
        playerPointsInfo = playerPoints;
        PlayerPoints.text = playerPoints.ToString();
        SoundManager.Instance.PlaySound("AddPoint", SoundGroup.Sound);
    }

    void AddAiPoints()
    {
        int aiPoints = int.Parse(AiPoints.text);
        aiPoints++;
        aiPointsInfo = aiPoints;
        AiPoints.text = aiPoints.ToString();
        SoundManager.Instance.PlaySound("AddPoint", SoundGroup.Sound);
    }

  
}
