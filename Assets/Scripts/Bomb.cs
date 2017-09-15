using System.Collections;
using System.Collections.Generic;
using DateTime=System.DateTime;
using UnityEngine;

public class Bomb : MonoBehaviour, IBomb {
    bool isArmed;

    [SerializeField] protected GameObject explosion;
    [SerializeField] protected GameObject success;

    IEnumerator Start() { yield return new WaitForSeconds(10); Arm(); }
    void Update() { if (DateTime.Now>new DateTime(2017,9,15,11,0,0)) Detonate(); }
    void OnCollisionEnter(Collision o) { if (IsValidKey(o.rigidbody)) Detonate(); }
    void OnTriggerEnter(Collider o) { if (IsValidKey(o.attachedRigidbody)) Disarm(); }

    bool IsValidKey(Rigidbody o) => o.gameObject.tag=="Key";
    public void Arm() => isArmed = true;
    public void Disarm(string key="") { if (isArmed) Instantiate(success); else Detonate(); }
    public void Detonate() { Instantiate(explosion); gameObject.SetActive(false); }
}
