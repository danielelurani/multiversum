using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponHUD : MonoBehaviour
{
    [SerializeField] private Text MagazineSizeText;
    [SerializeField] private Text MagazineCountText;
    [SerializeField] private Image WeaponIcon;
    public Sprite pistolSprite;
    public Sprite rifleSprite;
    public Sprite shotgunSprite;

    public GameObject player;
    private Pistol pistol;
    private Rifle rifle;
    private Shotgun shotgun;
    private EquippingScript equip;

  


    void Start()
    {
        pistol = player.GetComponentInChildren<Pistol>(true);
        rifle = player.GetComponentInChildren<Rifle>(true);
        shotgun = player.GetComponentInChildren<Shotgun>(true);

        equip = player.GetComponent<EquippingScript>();

 
    }


    void Update()
    {
        if (equip.isSlot1Active)
        {
            //aggiorna testo su canvas
            MagazineSizeText.text = pistol.currentBullets.ToString();
            MagazineCountText.text = pistol.currentAmmo.ToString();
            WeaponIcon.sprite = pistolSprite;

        }

        if (equip.isSlot2Active)
        {
            //aggiorna testo su canvas
            MagazineSizeText.text = rifle.currentBullets.ToString();
            MagazineCountText.text = rifle.currentAmmo.ToString();
            WeaponIcon.sprite = rifleSprite;
        }

        if (equip.isSlot3Active)
        {
            //aggiorna testo su canvas
            MagazineSizeText.text = shotgun.currentBullets.ToString();
            MagazineCountText.text = shotgun.currentAmmo.ToString();
            WeaponIcon.sprite = shotgunSprite;
        }


    }

}
