using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using UniRx;
using UniRx.Triggers;
using TMPro;

public class PlayerUIManager : SerializedMonoBehaviour
{
    private PlayerCore _Core = null;

    [SerializeField] private TMP_Text _HpText = null;
    [SerializeField] private Slider _HpSlider = null;

    void Start()
    {
        _Core = GameObject.FindWithTag("Player").GetComponent<PlayerCore>();

        _Core.CurrentHealth
            .Subscribe(_ => UpdateHPData())
            .AddTo(_Core);
    }

    private void UpdateHPData()
    {
        _HpText.text = _Core.CurrentHealth.Value.ToString() + " / " + _Core.MaxHealth.Value.ToString();
        _HpSlider.maxValue = _Core.MaxHealth.Value;
        _HpSlider.value = _Core.CurrentHealth.Value;
    }
}
