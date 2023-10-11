using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSystem : MonoBehaviour
{
    public int level;
    public float currentXp;
    public float requierdXp;

    private float lerpTimer;
    private float delayTimer;
    [Header("UI")]
    public Image FrontXp;
    public Image BackXp;
    public TextMeshProUGUI levelText;

    [Header("Muiltiples")]
    [Range(1f,300f)]
    public float additionMuiltipler = 300;
    [Range(2f, 4f)]
    public float PowerMuiltipler = 2;
    [Range(7f, 14f)]
    public float DivisionMuiltipler = 7;
    // Start is called before the first frame update
    void Start()
    {
        FrontXp.fillAmount = currentXp / requierdXp;
        BackXp.fillAmount = currentXp / requierdXp;
        requierdXp = CalculateRequiredXP();
        levelText.text = "Level " + level;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateXpUi();
        if (Input.GetKeyDown(KeyCode.Equals))
            GainExperienceFlatRate(20);
        if (currentXp > requierdXp)
            LevelUp();
    }

    public void UpdateXpUi()
    {
        float xpFraction = currentXp / requierdXp;
        float FXP = FrontXp.fillAmount;
        if(FXP < xpFraction)
        {
            delayTimer += Time.deltaTime;
            BackXp.fillAmount = xpFraction;
            if(delayTimer > 3)
            {
                lerpTimer += Time.deltaTime;
                float percentComplete = lerpTimer / 4;
                FrontXp.fillAmount = Mathf.Lerp(FXP, BackXp.fillAmount, percentComplete);
            }
        }
    }
    public void GainExperienceFlatRate(float xpGained)
    {
        currentXp += xpGained;
        lerpTimer = 0f;
    }

    public void LevelUp()
    {
        level++;
        FrontXp.fillAmount = 0f;
        BackXp.fillAmount = 0f;
        currentXp = Mathf.RoundToInt(currentXp - requierdXp);
        // Can upgrade stats like health here
        requierdXp = CalculateRequiredXP();
        levelText.text = "Level " + level;

        gameObject.GetComponent<CameraShake>().shakeDuration = 0.0f;
        GameObject.Find("GameManager").GetComponent<UpgradeSystem>().ShowPanel();
    }
    private int CalculateRequiredXP()
    {
        int solveForRequierdXp = 0;
        for(int levelCycle = 1; levelCycle <= level; levelCycle++)
        {
            solveForRequierdXp += (int)Mathf.Floor(levelCycle + additionMuiltipler * Mathf.Pow(PowerMuiltipler, levelCycle / DivisionMuiltipler));
        }
        return solveForRequierdXp / 4;
    }
}
