using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBuilding1: MonoBehaviour
{
    [System.Serializable]
    public class ObjectMovement
    {
        public GameObject objectToMove; // 要移动的物件
        public float moveMultiplier = 1.0f; // 移动倍数
        [HideInInspector]
        public Vector3 originalPosition; // 原始位置
    }

    public ObjectMovement[] objectsToMove; // 用于存储要移动的物件及其移动倍数
    public float moveDuration = 1.0f; // 移动持续时间

    private bool isMoved = false; // 状态变量，跟踪物体是否已移动

    private void Start()
    {
        // 记录每个物体的原始位置
        foreach (ObjectMovement objMovement in objectsToMove)
        {
            objMovement.originalPosition = objMovement.objectToMove.transform.position;
        }
    }

    // 方法用于启动或还原物件移动
    public void ToggleMove()
    {
        if (isMoved)
        {
            // 如果物体已移动，则还原到原始位置
            foreach (ObjectMovement objMovement in objectsToMove)
            {
                StartCoroutine(MoveAlongYAxis(objMovement.objectToMove, objMovement.originalPosition, moveDuration));
            }
        }
        else
        {
            // 如果物体未移动，则移动到目标位置
            foreach (ObjectMovement objMovement in objectsToMove)
            {
                Vector3 targetPosition = objMovement.originalPosition + new Vector3(0, objMovement.moveMultiplier, 0);
                StartCoroutine(MoveAlongYAxis(objMovement.objectToMove, targetPosition, moveDuration));
            }
        }

        // 切换状态
        isMoved = !isMoved;
    }

    // 协程用于平滑移动物件
    private IEnumerator MoveAlongYAxis(GameObject obj, Vector3 targetPosition, float duration)
    {
        Vector3 initialPosition = obj.transform.position;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            obj.transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.transform.position = targetPosition;
    }
}
