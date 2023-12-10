using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ContentManager : MonoBehaviour
{
    public Toggle BirdToggle;
    public GameObject MamaBirdPrefab;
    public GameObject BabyBirdPrefab;
    private GameObject SpawnedBird;
    public Camera ARCamera;

    private List<RaycastResult> raycastResults = new List<RaycastResult>();






    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Down!!!!");

            // telefon ekranında nereye tıkladığımızı bulmak için
            Ray ray = ARCamera.ScreenPointToRay(Input.mousePosition);
            Debug.Log(ray);

            // eğer UI elementine tıklarsam kuş oluşmasın
            if (IsPointerOverUI(Input.mousePosition))
            {
                Debug.Log("Do nothing!");

            }
            else
            {
                // tıkladığımız yere kuş oluşturmak için
                // purple ise baby red ise mama bird oluşur
                SpawnedBird = Instantiate(WhichBird(), ray.origin, Quaternion.identity);

                // kuşlar oluştuğunda sağa - sola fırlaması için
                SpawnedBird.GetComponent<Rigidbody>().AddForce(ray.direction * 100);
            }





        }

    }

    public GameObject WhichBird()
    {
        if (BirdToggle.isOn)
        {
            return MamaBirdPrefab;

        }
        else
        {
            return BabyBirdPrefab;
        }

    }

    // telefon ekranında tıkladığımız nokta iki boyutludur.
    private bool IsPointerOverUI(Vector2 fingerPosition)
    {
        PointerEventData eventDataPosition = new PointerEventData(EventSystem.current);
        eventDataPosition.position = fingerPosition;

        EventSystem.current.RaycastAll(eventDataPosition, raycastResults);
        return raycastResults.Count > 0; // sıfırdan büyükse bu, bir kullanıcı arayüzü öğesine rastladığımız anlamına gelir

    }



}
