using UnityEngine;
using UnityEngine.UI;

public class cutterz : MonoBehaviour
{
    public Slider slider; // Reference to the slider
    public GameObject building; // Reference to the model
    public Material[] cuttingMaterials; // Array of cutting materials

    // Start is called before the first frame update
    void Start()
    {
        SetSliderMaxValue();
        slider.onValueChanged.AddListener(UpdateCutoff);
    }

    // Update is called once per frame
    void UpdateCutoff(float value)
    {
        foreach (Material mat in cuttingMaterials)
        {
            mat.SetFloat("_Cutoff", value);
        }
    }

    void SetSliderMaxValue()
    {
        if (building != null)
        {
            Renderer renderer = building.GetComponent<Renderer>();
            if (renderer != null)
            {
                float depth = renderer.bounds.size.z; // ��ȡģ�͵����
                slider.maxValue = renderer.bounds.max.z; // ���û��˵����ֵΪģ����Z���ϵ����ֵ
                slider.minValue = renderer.bounds.min.z; // ���û��˵���СֵΪģ����Z���ϵ���Сֵ
                slider.value = slider.maxValue; // �����˳�ʼֵ����Ϊ���ֵ
                Debug.Log("Building depth: " + depth);
            }
            else
            {
                Debug.Log("No Renderer Component found");
            }
        }
    }
}

