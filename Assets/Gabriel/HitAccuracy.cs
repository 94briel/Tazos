using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HitAccuracy : MonoBehaviour
{
    public Slider hitbar;
    public RectTransform hitTexture, rtHandle;
    public float strength = 100f, speed = 1f;
    public Coroutine coroutineSlider;

    private void Start()
    {
        ModifyHitTexture();
        coroutineSlider = StartCoroutine(LerpSlider());
    }

    private void OnEnable()
    {
        EventController.singleton.moveSlide += MakeHit;
    }

    private bool MakeHit()
    {
        EventController.singleton.moveSlide -= MakeHit;
        StopCoroutine(coroutineSlider);
        return rectOverlaps(hitTexture, rtHandle);
    }

    private IEnumerator LerpSlider()
    {
        while (true)
        {
            yield return null;

            hitbar.value = Mathf.PingPong(Time.time * speed, 1);
        }
    }

    private bool rectOverlaps(RectTransform rectTransform1, RectTransform rectTransform2)
    {
        var corners = new Vector3[4];
        rectTransform1.GetWorldCorners(corners);
        var rec = new Rect(corners[0].x, corners[0].y, corners[2].x - corners[0].x, corners[2].y - corners[0].y);

        rectTransform2.GetWorldCorners(corners);
        var rec2 = new Rect(corners[0].x, corners[0].y, corners[2].x - corners[0].x, corners[2].y - corners[0].y);

        return rec.Overlaps(rec2);
    }

    private void ModifyHitTexture()
    {
        var hitRatio = CombatManager.singleton.hitRatio;
        hitTexture.offsetMin = new Vector2(hitRatio * strength, hitTexture.offsetMin.y);
        hitTexture.offsetMax = new Vector2(-hitRatio * strength, hitTexture.offsetMax.y);
    }
}