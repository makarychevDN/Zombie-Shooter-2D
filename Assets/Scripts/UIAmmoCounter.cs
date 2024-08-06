using TMPro;
using UnityEngine;

public class UIAmmoCounter : MonoBehaviour
{
    [SerializeField] private Human player;
    [SerializeField] private TMP_Text textField;

    private void Awake()
    {
        player.OnAmmoUpdated.AddListener(UpdateUiCounter);
        UpdateUiCounter(player.Ammo);
    }

    private void UpdateUiCounter(int ammo)
    {
        textField.text = ammo.ToString();
    }
}
