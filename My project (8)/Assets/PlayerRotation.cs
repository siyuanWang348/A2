using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerRotation : MonoBehaviour
{
    public Button rotateLeftButton;  // 左旋转按钮
    public Button rotateRightButton; // 右旋转按钮
    public Button resetButton;       // 恢复原样按钮
    public float rotationSpeed = 300f; // 旋转速度
    private Quaternion initialRotation; // 记录初始旋转角度

    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;

    void Start()
    {
        // 记录角色的初始旋转角度
        initialRotation = transform.rotation;

        // 绑定按钮事件
        if (rotateLeftButton != null)
        {
            AddEventTrigger(rotateLeftButton.gameObject, EventTriggerType.PointerDown, (data) => isRotatingLeft = true);
            AddEventTrigger(rotateLeftButton.gameObject, EventTriggerType.PointerUp, (data) => isRotatingLeft = false);
        }

        if (rotateRightButton != null)
        {
            AddEventTrigger(rotateRightButton.gameObject, EventTriggerType.PointerDown, (data) => isRotatingRight = true);
            AddEventTrigger(rotateRightButton.gameObject, EventTriggerType.PointerUp, (data) => isRotatingRight = false);
        }

        if (resetButton != null)
        {
            resetButton.onClick.AddListener(ResetRotation);
        }
    }

    void Update()
    {
        if (isRotatingLeft)
            transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime, Space.Self); // 逆时针旋转

        if (isRotatingRight)
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self); // 顺时针旋转
    }

    // 恢复原始角度
    void ResetRotation()
    {
        transform.rotation = initialRotation;
    }

    // 给按钮添加 EventTrigger 事件
    void AddEventTrigger(GameObject target, EventTriggerType eventType, System.Action<BaseEventData> action)
    {
        EventTrigger trigger = target.GetComponent<EventTrigger>();
        if (trigger == null)
            trigger = target.AddComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry { eventID = eventType };
        entry.callback.AddListener(new UnityEngine.Events.UnityAction<BaseEventData>(action));
        trigger.triggers.Add(entry);
    }
}
