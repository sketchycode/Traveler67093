using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(PlayerInteractable))]
[RequireComponent(typeof(Portal))]
public class Glyph : MonoBehaviour
{
    public Transform target;
    //sdouble[] GlyphAry = { "Translation1", "Translation2", "Translation3" };
    List<string> TranslationAry = new List<string>(new string[] { "Translation1", "Translation2", "Translation3", "Translation4", "Translation5", "Translation6", "Translation8", "Translation10", "Translation12", "Translation15", "Translation18" });
    List<string> GlyphAry = new List<string>(new string[] { "Glyph1", "Glyph2", "Glyph3", "Glyph4", "Glyph5", "Glyph6", "Glyph8", "Glyph10", "Glyph12", "Glyph15", "Glyph18" });

    public MeshRenderer translatedTextRenderer;

    private void Start()
    {
        PlayerInteractable glyphinteractive = GetComponent<PlayerInteractable>();
        glyphinteractive.PlayerInteracted += Glyphinteractive_PlayerInteracted;
    }

    private void Glyphinteractive_PlayerInteracted(object sender, System.EventArgs e)
    {
        translatedTextRenderer.enabled = true;
        var translations = GameObject.FindObjectsOfType<GlyphTranslation>();
        var finalTextIsVisible = false;
        if (translations.All(t => t.GetComponent<MeshRenderer>().enabled))
        {
            var finalMessage = GameObject.Find("Final Translation").GetComponent<MeshRenderer>();
            finalMessage.enabled = true;
            var portal = GameObject.Find("Portal").GetComponent<Portal>();
            portal.ActivatePortal();
        }
        transform.LookAt(target);
    }

    private void ShowFinalTranslation_PlayerInteracted(object sender, System.EventArgs e)
    {
        Debug.Log("test show final translation");
    }

    void Update()
    {

    }
}
