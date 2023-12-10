using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyBird : MonoBehaviour
{
    public float speed = 0.4f;
    public float rotation_damping = 4f;
    public Transform MamaBird;


    // Start is called before the first frame update
    void Start()
    {
        // MamaBird = GameObject.FindGameObjectWithTag("MamaBird").GetComponent<Transform>();

        // baby bird, sahnedeki anne kuşların herhangi biri arasından rastgele seçim yapması
        GameObject[] MamaBirds = GameObject.FindGameObjectsWithTag("MamaBird");
        // anne kuşların arasından rastgele seçim yapalım
        int ChosenMamaBird = Random.Range(0, MamaBirds.Length);
        MamaBird = MamaBirds[ChosenMamaBird].GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // rotate towards mama bird
        var rotation = Quaternion.LookRotation(MamaBird.transform.position - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotation_damping);

        // baby bird will follow mama
        float step = speed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(this.transform.position, MamaBird.position, step);

    }
}


