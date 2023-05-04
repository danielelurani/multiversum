using UnityEngine;

public class Pistol : MonoBehaviour
{

    // variabili per caratteristiche della pistola
    public float damage = 10f;
    public float range = 100f;

    // punto dal quale escono i proiettili
    public Transform muzzle;

    public ParticleSystem muzzleFlash;

    // Update is called once per frame
    void Update(){

        // azione di sparo
        if(Input.GetButtonDown("Fire1")){

            Shoot();
        }
    }

    void Shoot(){

        muzzleFlash.Play();

        // memorizza l'informazione su cosa ho colpito
        RaycastHit hitInfo;

        // si spara dalla posizione della camera, nella direzione della camera, vengono prese le informazioni necessarie, definito il range
        // il metodo ritorna un booleano, se si è colpito qualcosa o meno
        if(Physics.Raycast(muzzle.transform.position, muzzle.transform.forward, out hitInfo, range)){
            
            Debug.Log(hitInfo.transform.name);
        }
    }
}
