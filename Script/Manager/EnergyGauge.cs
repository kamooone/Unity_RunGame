using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class EnergyGauge : MonoBehaviour
{
    [SerializeField]
    private Image addGauge;

    private PlayerMove player;
    private Tween redGaugeTween;

    public void GaugeReduction(float reducationValue, float time = 1f)
    {
        var valueFrom = PlayerMove.GetEnergyLife() / PlayerMove.GetMaxEnergyLife();
        var valueTo = (PlayerMove.GetEnergyLife());

        // 緑ゲージ
        addGauge.fillAmount = valueTo;
    }

    public void SetPlayer(PlayerMove player)
    {
        this.player = player;
    }
}
