using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapTarget : MonoBehaviour
{
    public GameObject target;
    public GameObject source;
    public RectTransform pointerRectTransform;
    public RectTransform miniMapRectTransform;
    public Camera miniMapCamera;
    public Vector3 targetPosition;

    public static float GetAngleFromVectorFloat(Vector3 dir) {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }

    private void Awake() {
        pointerRectTransform = GetComponent<RectTransform>();
    }

    void Update() {
        
        targetPosition = target.transform.position;

        Vector3 fromPosition = source.transform.position;
        Vector3 dir = (targetPosition - fromPosition).normalized;
        float angle = GetAngleFromVectorFloat(dir);
        pointerRectTransform.localEulerAngles = new Vector3(0, 0, angle);

        Vector3 targetPositionViewportPoint = miniMapCamera.WorldToViewportPoint(targetPosition);
        Vector3 targetPositionLocalPoint = new Vector3(
            (targetPositionViewportPoint.x - 0.5f) * miniMapRectTransform.rect.width,
            (targetPositionViewportPoint.y - 0.5f) * miniMapRectTransform.rect.height,
            0f
        );

        float borderSize = 5f;
        float halfMinimapWidth = miniMapRectTransform.rect.width / 2f;
        float halfMinimapHeight = miniMapRectTransform.rect.height / 2f;

        targetPositionLocalPoint.x = Mathf.Clamp(targetPositionLocalPoint.x, -halfMinimapWidth + borderSize, halfMinimapWidth - borderSize);
        targetPositionLocalPoint.y = Mathf.Clamp(targetPositionLocalPoint.y, -halfMinimapHeight + borderSize, halfMinimapHeight - borderSize);

        pointerRectTransform.localPosition = targetPositionLocalPoint;
    }
}
