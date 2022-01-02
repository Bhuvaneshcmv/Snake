using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    private int score = 0;

    [SerializeField]
    TMP_Text text;

    private void OnEnable()
    {
        Food.ateFood += IncreaseScore;
    }
    private void OnDisable()
    {
        Food.ateFood -= IncreaseScore;
    }
    void IncreaseScore(FoodType foodType)
    {
        if(foodType == FoodType.normal)
            score++;
        text.text = score.ToString();
    }
}
