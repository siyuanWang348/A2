using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SmoothResetTransform : MonoBehaviour
{
    private Vector3 initialPosition;    // 记录初始位置
    private Quaternion initialRotation; // 记录初始旋转
    private Vector3 initialScale;       // 记录初始缩放

    public Button resetButton;          // 绑定的 UI 按钮
    public float resetDuration = 1.0f;  // 平滑过渡时间

    void Start()
    {
        // 记录 GameObject 的初始状态
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        initialScale = transform.localScale;

        // 绑定按钮点击事件
        if (resetButton != null)
        {
            resetButton.onClick.AddListener(() => StartCoroutine(SmoothReset()));
        }
    }

    IEnumerator SmoothReset()
    {
        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;
        Quaternion startRotation = transform.rotation;
        Vector3 startScale = transform.localScale;

        while (elapsedTime < resetDuration)
        {
            float t = elapsedTime / resetDuration; // 计算插值比例

            // 平滑插值
            transform.position = Vector3.Lerp(startPosition, initialPosition, t);
            transform.rotation = Quaternion.Lerp(startRotation, initialRotation, t);
            transform.localScale = Vector3.Lerp(startScale, initialScale, t);

            elapsedTime += Time.deltaTime; // 计时
            yield return null;
        }

        // 确保最终值正确
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        transform.localScale = initialScale;
    }
}
