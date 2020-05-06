using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FOVScript : MonoBehaviour
{

    public Slider fovSlider;

    public TMP_Text fovText;

    [Range(30, 120), SerializeField] private float fieldOfViewNum = 60;
    // Start is called before the first frame update
    void Start()
    {
        fovSlider = GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {

        fieldOfViewNum = Camera.main.fieldOfView;
        
        fovText.text = "Field of View: " + fovSlider.value;

        Debug.Log ("" + fieldOfViewNum);
    }

    public void changeSliderValue() {
        fieldOfViewNum = fovSlider.value;
    }
}
