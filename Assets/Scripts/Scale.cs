using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    public GameObject objectA; // ������� A
    public GameObject[] objectsB; // ���ڴ洢 B �ڵĶ�����

    private Vector3 originalScaleA; // ���ڴ洢 objectA ��ԭʼ��С
    private bool isScaled = false; // ״̬�����������Ƿ��ѷŴ�

    private void Start()
    {
        objectA.SetActive(true);
        SetActiveForObjects(objectsB, true);
        originalScaleA = objectA.transform.localScale;
    }
    public void OnUiScale()
    {
        isScaled = !isScaled;
        ScaleObjectAAndHideObjectsB();
    }
    public void ScaleObjectAAndHideObjectsB()
    {
        if (!isScaled)
        {
            StartCoroutine(ScaleObject(objectA, originalScaleA, 1.0f));
            SetActiveForObjects(objectsB, true);
            isScaled = false;
        }
        else
        {
            SetActiveForObjects(objectsB, false);
            Vector3 targetScale = originalScaleA * 1.5f; // �Ŵ�ߴ�
            StartCoroutine(ScaleObject(objectA, targetScale, 1.0f));
            isScaled = true;
        }
    }
    private IEnumerator ScaleObject(GameObject obj, Vector3 targetScale, float duration)
    {
        Vector3 initialScale = obj.transform.localScale;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            obj.transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.transform.localScale = targetScale;
    }
    private void SetActiveForObjects(GameObject[] objects, bool isActive)
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(isActive);
        }
    }
}
