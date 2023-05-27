using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippingScript : MonoBehaviour
{

    public GameObject slot1;
    public GameObject slot2;

    // prendo tutte le fonti audio dagli oggetti passati
    public AudioSource[] audio1;
    public AudioSource[] audio2;

    private bool isSlot1Active;
    private bool isSlot2Active;
    //private bool isSlot3Active;
    private int slotEquippedATM; // quale slot ho equipaggiato al momento

    // Start is called before the first frame update
    void Start()
    {
        audio1 = slot1.GetComponentsInChildren<AudioSource>();
        audio2 = slot2.GetComponentsInChildren<AudioSource>();

        isSlot1Active = true;
        isSlot2Active = false;
        //isSlot3Active = false;

        slotEquippedATM = 1;
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
    }

    void Equip1(){

        slot1.SetActive(true);
        slot2.SetActive(false);

        // quando equipaggio l'arma disattivo i suoni, verranno attivati solo nel momento dell'utilizzo effettivo
        foreach(AudioSource audio in audio1){
            audio.enabled = false;
        }

        slotEquippedATM = 1;
    }

    void Equip2(){
        
        slot1.SetActive(false);
        slot2.SetActive(true);

        // quando equipaggio l'arma disattivo i suoni, verranno attivati solo nel momento dell'utilizzo effettivo
        foreach(AudioSource audio in audio2){
            audio.enabled = false;
        }

        slotEquippedATM = 2;
    }

    public void ActiveSlot1(){
        isSlot1Active = true;
    }

    public void ActiveSlot2(){
        isSlot2Active = true;
    }
}
