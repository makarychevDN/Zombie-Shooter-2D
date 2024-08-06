using TMPro;
using UnityEngine;

public class UIAmmoCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text textField;

    public void Init(Human player)
    {
        player.OnAmmoUpdated.AddListener(UpdateUiCounter);
        UpdateUiCounter(player.Ammo);
    }

    private void UpdateUiCounter(int ammo)
    {
        textField.text = ammo.ToString();
    }
}
