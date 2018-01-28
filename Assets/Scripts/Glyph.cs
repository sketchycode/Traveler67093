using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInteractable))]
[RequireComponent(typeof(Portal))]
public class Glyph : MonoBehaviour
{
    public Transform target;
    //sdouble[] GlyphAry = { "Translation1", "Translation2", "Translation3" };
    List<string> TranslationAry = new List<string>(new string[] { "Translation1", "Translation2", "Translation3", "Translation4", "Translation5", "Translation6", "Translation8", "Translation10", "Translation12", "Translation15", "Translation18" });
    List<string> GlyphAry = new List<string>(new string[] { "Glyph1", "Glyph2", "Glyph3", "Glyph4", "Glyph5", "Glyph6", "Glyph8", "Glyph10", "Glyph12", "Glyph15", "Glyph18" });

    private void Start()
    {
        PlayerInteractable glyphinteractive = GetComponent<PlayerInteractable>();
        glyphinteractive.PlayerInteracted += Glyphinteractive_PlayerInteracted;
    }

    private void Glyphinteractive_PlayerInteracted(object sender, System.EventArgs e)
    {
        int GlyphPosition = GlyphAry.IndexOf(this.name);
        string TranslationVar = TranslationAry[GlyphPosition];
        MeshRenderer visibleTranslation = GetComponent<MeshRenderer>();
        var transformtext = GameObject.Find(TranslationVar).GetComponent<MeshRenderer>();
        visibleTranslation.enabled = true;
        transformtext.enabled = true;
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
