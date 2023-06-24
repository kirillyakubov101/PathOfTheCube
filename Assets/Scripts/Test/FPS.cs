using TMPro;
using UnityEngine;

public class FPS : MonoBehaviour
{
    [SerializeField] TMP_Text m_FpsText;

    private float deltaTime;

    private void Update()
    {
        // Calculate the frame time
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        m_FpsText.text = Mathf.RoundToInt(fps).ToString();
    }


}
