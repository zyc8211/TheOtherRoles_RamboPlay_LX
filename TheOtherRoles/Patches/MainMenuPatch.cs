﻿using System;
using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Button;
using Object = UnityEngine.Object;
using TheOtherRoles.Patches;

namespace TheOtherRoles.Modules {
    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start))]
    public class MainMenuPatch {
        private static bool horseButtonState = MapOptions.enableHorseMode;
        private static Sprite horseModeOffSprite = null;
        private static Sprite horseModeOnSprite = null;
        private static GameObject bottomTemplate;
        private static AnnouncementPopUp popUp;

        private static void Prefix(MainMenuManager __instance) {
            CustomHatLoader.LaunchHatFetcher();
            var template = GameObject.Find("ExitGameButton");
            if (template == null) return;

            var buttonDiscord = UnityEngine.Object.Instantiate(template, null);
            buttonDiscord.transform.localPosition = new Vector3(buttonDiscord.transform.localPosition.x, buttonDiscord.transform.localPosition.y + 0.6f, buttonDiscord.transform.localPosition.z);

            var textDiscord = buttonDiscord.transform.GetChild(0).GetComponent<TMPro.TMP_Text>();
            __instance.StartCoroutine(Effects.Lerp(0.1f, new System.Action<float>((p) => {
                textDiscord.SetText("兰博玩");
            })));

            PassiveButton passiveButtonDiscord = buttonDiscord.GetComponent<PassiveButton>();
            SpriteRenderer buttonSpriteDiscord = buttonDiscord.GetComponent<SpriteRenderer>();

            passiveButtonDiscord.OnClick = new Button.ButtonClickedEvent();
            passiveButtonDiscord.OnClick.AddListener((System.Action)(() => Application.OpenURL("https://ramboplay.com")));

            Color discordColor = new Color32(59, 116, 213, byte.MaxValue);
            buttonSpriteDiscord.color = textDiscord.color = discordColor;
            passiveButtonDiscord.OnMouseOut.AddListener((System.Action)delegate {
                buttonSpriteDiscord.color = textDiscord.color = discordColor;
            });

            CustomHatLoader.LaunchHatFetcher();
            var template2 = GameObject.Find("ExitGameButton");
            if (template2 == null) return;

            var button汉化组QQ群 = UnityEngine.Object.Instantiate(template2, null);
            button汉化组QQ群.transform.localPosition = new Vector3(button汉化组QQ群.transform.localPosition.x, button汉化组QQ群.transform.localPosition.y + 1.8f, button汉化组QQ群.transform.localPosition.z);

            var text汉化组QQ群 = button汉化组QQ群.transform.GetChild(0).GetComponent<TMPro.TMP_Text>();
            __instance.StartCoroutine(Effects.Lerp(0.1f, new System.Action<float>((p) => {
                text汉化组QQ群.SetText("加入\n汉化组QQ群");
            })));

            PassiveButton passiveButton汉化组QQ群 = button汉化组QQ群.GetComponent<PassiveButton>();
            SpriteRenderer buttonSprite汉化组QQ群 = button汉化组QQ群.GetComponent<SpriteRenderer>();

            passiveButton汉化组QQ群.OnClick = new Button.ButtonClickedEvent();
            passiveButton汉化组QQ群.OnClick.AddListener((System.Action)(() => Application.OpenURL("https://jq.qq.com/?_wv=1027&k=7ZcKOOLT")));

            Color 汉化组QQ群Color = new Color32(255, 255, 0, byte.MaxValue);
            buttonSprite汉化组QQ群.color = text汉化组QQ群.color = 汉化组QQ群Color;
            passiveButton汉化组QQ群.OnMouseOut.AddListener((System.Action)delegate {
                buttonSprite汉化组QQ群.color = text汉化组QQ群.color = 汉化组QQ群Color;
            });

            CustomHatLoader.LaunchHatFetcher();
            var template3 = GameObject.Find("ExitGameButton");
            if (template3 == null) return;

            var button四个憨批汉化组 = UnityEngine.Object.Instantiate(template2, null);
            button四个憨批汉化组.transform.localPosition = new Vector3(button四个憨批汉化组.transform.localPosition.x, button四个憨批汉化组.transform.localPosition.y + 1.2f, button四个憨批汉化组.transform.localPosition.z);

            var text四个憨批汉化组 = button四个憨批汉化组.transform.GetChild(0).GetComponent<TMPro.TMP_Text>();
            __instance.StartCoroutine(Effects.Lerp(0.1f, new System.Action<float>((p) => {
                text四个憨批汉化组.SetText("憨批小站\n汉化组官网");
            })));

            PassiveButton passiveButton四个憨批汉化组 = button四个憨批汉化组.GetComponent<PassiveButton>();
            SpriteRenderer buttonSprite四个憨批汉化组 = button四个憨批汉化组.GetComponent<SpriteRenderer>();

            passiveButton四个憨批汉化组.OnClick = new Button.ButtonClickedEvent();
            passiveButton四个憨批汉化组.OnClick.AddListener((System.Action)(() => Application.OpenURL("https://amonguscn.club")));

            Color 四个憨批汉化组Color = new Color32(255, 0, 0, byte.MaxValue);
            buttonSprite四个憨批汉化组.color = text四个憨批汉化组.color = 四个憨批汉化组Color;
            passiveButton四个憨批汉化组.OnMouseOut.AddListener((System.Action)delegate {
                buttonSprite四个憨批汉化组.color = text四个憨批汉化组.color = 四个憨批汉化组Color;
            });







            // Horse mode stuff
            var horseModeSelectionBehavior = new ClientOptionsPatch.SelectionBehaviour("Enable Horse Mode", () => MapOptions.enableHorseMode = TheOtherRolesPlugin.EnableHorseMode.Value = !TheOtherRolesPlugin.EnableHorseMode.Value, TheOtherRolesPlugin.EnableHorseMode.Value);

            bottomTemplate = GameObject.Find("InventoryButton");
            if (bottomTemplate == null) return;
            var horseButton = Object.Instantiate(bottomTemplate, bottomTemplate.transform.parent);
            var passiveHorseButton = horseButton.GetComponent<PassiveButton>();
            var spriteHorseButton = horseButton.GetComponent<SpriteRenderer>();

            horseModeOffSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.HorseModeButtonOff.png", 75f);
            horseModeOnSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.HorseModeButtonOn.png", 75f);

            spriteHorseButton.sprite = horseButtonState ? horseModeOnSprite : horseModeOffSprite;

            passiveHorseButton.OnClick = new ButtonClickedEvent();

            passiveHorseButton.OnClick.AddListener((System.Action)delegate {
                horseButtonState = horseModeSelectionBehavior.OnClick();
                if (horseButtonState) {
                    if (horseModeOnSprite == null) horseModeOnSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.HorseModeButtonOn.png", 75f);
                    spriteHorseButton.sprite = horseModeOnSprite;
                }else {
                    if (horseModeOffSprite == null) horseModeOffSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.HorseModeButtonOff.png", 75f);
                    spriteHorseButton.sprite = horseModeOffSprite;
                }
                CredentialsPatch.LogoPatch.updateSprite();
                // Avoid wrong Player Particles floating around in the background
                var particles = GameObject.FindObjectOfType<PlayerParticles>();
                if (particles != null) {
                    particles.pool.ReclaimAll();
                    particles.Start();
                }
            });
            
            // TOR credits button
            if (bottomTemplate == null) return;
            var creditsButton = Object.Instantiate(bottomTemplate, bottomTemplate.transform.parent);
            var passiveCreditsButton = creditsButton.GetComponent<PassiveButton>();
            var spriteCreditsButton = creditsButton.GetComponent<SpriteRenderer>();

            spriteCreditsButton.sprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.CreditsButton.png", 75f);

            passiveCreditsButton.OnClick = new ButtonClickedEvent();

            passiveCreditsButton.OnClick.AddListener((System.Action)delegate {
                // do stuff
                if (popUp != null) Object.Destroy(popUp);
                popUp = Object.Instantiate(Object.FindObjectOfType<AnnouncementPopUp>(true));
                popUp.gameObject.SetActive(true);
                popUp.Init();
                //SelectableHyperLinkHelper.DestroyGOs(popUp.selectableHyperLinks, "test");
                string creditsString = @$"<align=""center"">Github Contributors:
Gendelo
Alex2911    amsyarasyiq    MaximeGillot
Psynomit    probablyadnf    JustASysAdmin
";
                creditsString += $@"<size=60%> Other Credits & Resources:
OxygenFilter - For all the version v2.3.0 to v2.6.1, we were using the OxygenFilter for automatic deobfuscation
Reactor - The framework used for all version before v2.0.0
BepInEx - Used to hook game functions
Essentials - Custom game options by DorCoMaNdO:
Before v1.6: We used the default Essentials release
v1.6-v1.8: We slightly changed the default Essentials. The changes can be found on this branch of our fork.
v2.0.0 and later: As we're not using Reactor anymore, we are using our own implementation, inspired by the one from DorCoMaNdO
Jackal and Sidekick - Original idea for the Jackal and Sidekick comes from Dhalucard
Among-Us-Love-Couple-Mod - Idea for the Lovers role comes from Woodi-dev
Jester - Idea for the Jester role comes from Maartii
ExtraRolesAmongUs - Idea for the Engineer and Medic role comes from NotHunter101. Also some code snippets come of the implementation were used.
Among-Us-Sheriff-Mod - Idea for the Sheriff role comes from Woodi-dev
TooManyRolesMods - Idea for the Detective and Time Master roles comes from Hardel-DW. Also some code snippets of the implementation were used.
TownOfUs - Idea for the Swapper, Shifter, Arsonist and a similar Mayor role come from Slushiegoose
Ottomated - Idea for the Morphling, Snitch and Camouflager role come from Ottomated
Crowded-Mod - Our implementation for 10+ player lobbies is inspired by the one from the Crowded Mod Team
Goose-Goose-Duck - Idea for the Vulture role come from Slushygoose</size>";
                creditsString += "</align>";
                popUp.AnnounceTextMeshPro.text = creditsString;
                __instance.StartCoroutine(Effects.Lerp(0.01f, new Action<float>((p) => {
                    if (p == 1) {
                        var titleText = GameObject.Find("Title_Text").GetComponent<TMPro.TextMeshPro>();
                        if (titleText != null) titleText.text = "Credits and Contributors";
                    }
                })));
            });

        }

        public static void Postfix(MainMenuManager __instance) {
            __instance.StartCoroutine(Effects.Lerp(0.01f, new Action<float>((p) => {
                if (p == 1) {
                    bottomTemplate = GameObject.Find("InventoryButton");
                    foreach (Transform tf in bottomTemplate.transform.parent.GetComponentsInChildren<Transform>()) {
                        tf.localPosition = new Vector2(tf.localPosition.x * 0.8f, tf.localPosition.y);
                    }
                }
            })));

        }
    }

    [HarmonyPatch(typeof(AnnouncementPopUp), nameof(AnnouncementPopUp.UpdateAnnounceText))]
    public static class Announcement
    {
        public static ModUpdateBehaviour.UpdateData updateData = null;
        public static bool Prefix(AnnouncementPopUp __instance)
        {
            if (ModUpdateBehaviour.showPopUp || updateData == null) return true;

            var text = __instance.AnnounceTextMeshPro;            
            text.text = $"<size=150%><color=#FC0303>THE OTHER ROLES </color> {(updateData.Tag)}\n{(updateData.Content)}";

            return false;
        }
    }
}