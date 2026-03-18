using UnityEngine;

public class MenuParallax : MonoBehaviour
{
    public float offsetMultiplier = 20f;
    public float smoothTime = 0.2f;

    private Vector2 startPosition;
    private Vector2 velocity;

    private RectTransform rect;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        startPosition = rect.anchoredPosition;
    }

    void Update()
    {
        Vector2 offset = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        offset -= new Vector2(0.5f, 0.5f);

        Vector2 targetPosition = startPosition + offset * offsetMultiplier;

        rect.anchoredPosition = Vector2.SmoothDamp(
            rect.anchoredPosition,
            targetPosition,
            ref velocity,
            smoothTime
        );
    }
}