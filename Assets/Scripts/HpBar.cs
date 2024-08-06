using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private Slider slider;

    private void Awake()
    {
        slider.maxValue = character.Hp;
        UpdateValueOfSlider(character.Hp);
        character.OnHealthDecreased.AddListener(UpdateValueOfSlider);
    }

    private void UpdateValueOfSlider(int valueOfSlider)
    {
        slider.value = valueOfSlider;
    }
}
