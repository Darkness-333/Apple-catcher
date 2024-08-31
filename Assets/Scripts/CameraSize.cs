using UnityEngine;

public class CameraSize : MonoBehaviour {
    private Camera cam;

    private void Start() {
        cam = GetComponent<Camera>();
        AdjustViewportAndSize();
    }

    void Update() {
        AdjustViewportAndSize();
    }

    void AdjustViewportAndSize() {
        float targetAspect = 16.0f / 9.0f; // ������� ����������� ������
        float windowAspect = (float)Screen.width / Screen.height; // ������� ����������� ������ ����

        if (windowAspect > targetAspect) // ���� ����� �������
        {
            float scaleHeight = targetAspect / windowAspect;
            cam.rect = new Rect((1.0f - scaleHeight) / 2.0f, 0.0f, scaleHeight, 1.0f);
        }
        else // ���� ����� ����� ��� ������ ��������
        {
            float scaleWidth = windowAspect / targetAspect;
            cam.rect = new Rect(0.0f, (1.0f - scaleWidth) / 2.0f, 1.0f, scaleWidth);
        }

    }
}
