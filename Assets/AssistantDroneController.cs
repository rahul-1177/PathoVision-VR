using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AssistantDroneController : MonoBehaviour
{
    public float appearDuration = 2f;
    public float disappearDuration = 2f;
    public float hoverAmplitude = 0.05f;
    public float hoverSpeed = 2f;

    private AudioSource audioSource;
    private Renderer droneRenderer;
    private Color baseColor;
    private float baseY;

    void Awake()
    {
        // Get components
        audioSource = GetComponent<AudioSource>();
        droneRenderer = GetComponentInChildren<Renderer>();

        if (droneRenderer != null)
        {
            // Make sure we have our own instance of the material
            droneRenderer.material = new Material(droneRenderer.material);
            baseColor = droneRenderer.material.color;
            SetAlpha(0f);
        }

        baseY = transform.position.y;
        transform.localScale = Vector3.zero; // start invisible
    }

    IEnumerator Start()
    {
        // APPEAR (fade + scale up)
        float t = 0f;
        while (t < appearDuration)
        {
            t += Time.deltaTime;
            float k = Mathf.Clamp01(t / appearDuration);
            SetAlpha(k);
            transform.localScale = Vector3.one * k;
            yield return null;
        }

        // TALK (wait for audio, or fallback wait)
        float fallbackTalkTime = 6f;

        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
        }
        else
        {
            // If something is wrong with audio, still stay visible for a bit
            yield return new WaitForSeconds(fallbackTalkTime);
        }

        // DISAPPEAR (fade + scale down)
        t = 0f;
        while (t < disappearDuration)
        {
            t += Time.deltaTime;
            float k = 1f - Mathf.Clamp01(t / disappearDuration);
            SetAlpha(k);
            transform.localScale = Vector3.one * k;
            yield return null;
        }

        Destroy(gameObject);
    }

    void Update()
    {
        // Hover up and down a little
        float newY = baseY + Mathf.Sin(Time.time * hoverSpeed) * hoverAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Glow while talking
        if (audioSource != null && audioSource.isPlaying && droneRenderer != null)
        {
            float pulse = (Mathf.Sin(Time.time * 15f) + 1f) * 0.5f;
            float glow = Mathf.Lerp(0f, 0.5f, pulse);
            Color c = baseColor * (1f + glow);
            c.a = droneRenderer.material.color.a;
            droneRenderer.material.color = c;
        }
    }

    private void SetAlpha(float a)
    {
        if (droneRenderer == null) return;
        Color c = droneRenderer.material.color;
        c.a = a;
        droneRenderer.material.color = c;
    }
}
