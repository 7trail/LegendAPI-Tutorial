using BepInEx;
using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using UnityEngine;
using LegendAPI;
namespace WOLModTemplate {
    [BepInPlugin("com.NewDeveloper.WolModTemplate", "WoLModTemplate", "0.1.0")]
    public class WoLModPlugin : BaseUnityPlugin {

        void Awake() {
            OutfitInfo outfit = new OutfitInfo();
            outfit.name = "Cool Guy";
            outfit.outfit = new Outfit("ModName::OutfitName", 1, new List<OutfitModStat>()
            {
                new OutfitModStat(OutfitModStat.OutfitModType.Health,100,0,0,false),
                new OutfitModStat(OutfitModStat.OutfitModType.Speed,0,0.2f,0,false)
            }, false, false);

            Outfits.Register(outfit);

            ItemInfo item = new ItemInfo();
            item.name = NewDamageUp.staticID;
            item.text = new TextManager.ItemInfo()
            {
                itemID = NewDamageUp.staticID,
                displayName = "Super Necklace",
                description = "Increases damage greatly!"
            };
            item.tier = 1;
            item.priceMultiplier = 1;
            item.icon = ImageHandler.LoadSprite("Super Necklace");
            item.item = new NewDamageUp();
            Items.Register(item);
        }
    }
}
