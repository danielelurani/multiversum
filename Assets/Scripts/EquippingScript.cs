using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippingScript : MonoBehaviour
{

    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public int numberOfSlotActive;  // quante armi ho già addosso
    public int slotEquippedATM;     // quale slot ho equipaggiato al momento

    // prendo tutte le fonti audio dagli oggetti passati
    public AudioSource[] audio1;
    public AudioSource[] audio2;
    public AudioSource[] audio3;

    private bool isSlot1Active;
    private bool isSlot2Active;
    private bool isSlot3Active;

    // Start is called before the first frame update
    void Start()
    {
        audio1 = slot1.GetComponentsInChildren<AudioSource>();
        audio2 = slot2.GetComponentsInChildren<AudioSource>();
        audio3 = slot2.GetComponentsInChildren<AudioSource>();


        isSlot1Active = true;
        isSlot2Active = false;
        isSlot3Active = false;

        slotEquippedATM = 1;
        numberOfSlotActive = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1") && isSlot1Active){
            Equip1();
        }

        if(Input.GetKeyDown("2") && isSlot2Active){
            Equip2();
        }

        if(Input.GetKeyDown("3") && isSlot3Active){
            Equip3();
        }
    }

    public void Equip1(){

        slot1.SetActive(true);
        slot2.SetActive(false);
        slot3.SetActive(false);

        // quando equipaggio l'arma disattivo i suoni, verranno attivati solo nel momento dell'utilizzo effettivo
        foreach(AudioSource audio in audio1){
            audio.enabled = false;
        }

        slotEquippedATM = 1;
    }

    public void Equip2(){
        
        slot1.SetActive(false);
        slot2.SetActive(true);
        slot3.SetActive(false);

        // quando equipaggio l'arma disattivo i suoni, verranno attivati solo nel momento dell'utilizzo effettivo
        foreach(AudioSource audio in audio2){
            audio.enabled = false;
        }

        slotEquippedATM = 2;
    }

    public void Equip3(){

        slot1.SetActive(false);
        slot2.SetActive(false);
        slot3.SetActive(true);

        // quando equipaggio l'arma disattivo i suoni, verranno attivati solo nel momento dell'utilizzo effettivo
        foreach(AudioSource audio in audio3){
            audio.enabled = false;
        }

        slotEquippedATM = 3;
    }

    public void Slot1(bool tof){
        isSlot1Active = tof;
    }

    public void Slot2(bool tof){
        isSlot2Active = tof;
    }

    public void Slot3(bool tof){
        isSlot3Active = tof;
    }
}
