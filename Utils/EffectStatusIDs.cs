﻿using System;
using System.ComponentModel;

namespace _4RTools.Utils
{

    [Flags]
    public enum EffectStatusIDs : uint
    {
        //Status
        [Description("Provoke")]
        PROVOKE = 0,
        [Description("Endure")]
        ENDURE = 1,
        [Description("Two Hand Quicken")]
        TWOHANDQUICKEN = 2,
        [Description("Concentration")]
        CONCENTRATION = 3,
        [Description("Hiding")]
        HIDING = 4,
        [Description("Cloaking")]
        CLOAKING = 5,
        [Description("Poison React")]
        POISONREACT = 7,
        QUAGMIRE = 8,
        [Description("Angelus")]
        ANGELUS = 9,
        [Description("Blessing")]
        BLESSING = 10,
        [Description("Increase AGI")]
        INC_AGI = 12,
        [Description("Impositio Manus")]
        IMPOSITIO = 15,
        [Description("Aspersio")]
        ASPERSIO = 17,
        [Description("Magnificat")]
        MAGNIFICAT = 20,
        [Description("Gloria")]
        GLORIA = 21,
        [Description("Adrenaline Rush")]
        ADRENALINE = 23,
        [Description("Weapon Perfection")]
        WEAPONPERFECT = 24,
        [Description("Overthrust")]
        OVERTHRUST = 25,
        [Description("Maximize")]
        MAXIMIZE = 26,
        PECO_RIDING = 27,
        FALCON_ON = 28,
        [Description("Crazy Uproar")]
        CRAZY_UPROAR = 30,
        [Description("Energy Coat")]
        ENERGYCOAT = 31,
        HALLUCINATION = 34,
        //POTIONS
        CONCENTRATION_POTION = 37,
        AWAKENING_POTION = 38,
        BERSERK_POTION = 39,
        ASPDPOTIONINFINITY = 40,
        SPEED_POT = 41,
        STRIPWEAPON = 51,
        STRIPSHIELD = 52,
        STRIPARMOR = 53,
        STRIPHELM = 54,
        PROTECTARMOR = 56,
        [Description("Autoguard")]
        AUTOGUARD = 58,
        [Description("Reflect Shield")]
        REFLECTSHIELD = 59,
        [Description("Providence")]
        PROVIDENCE = 61,
        [Description("Defender")]
        DEFENDER = 62,
        WEAPONPROPERTY = 64,
        [Description("Auto Spell")]
        AUTOSPELL = 65,
        [Description("Spear Quicken")]
        SPEARQUICKEN = 68,
        [Description("A Poem of Bragi")]
        POEMBRAGI = 72,
        [Description("The Apple of Idun")]
        APPLEIDUN = 73,
        [Description("Fury")]
        FURY = 86,
        //ELEMENTAL CONVERTERS
        [Description("Elemental Converter (Fire)")]
        PROPERTYFIRE = 90,
        [Description("Elemental Converter (Water)")]
        PROPERTYWATER = 91,
        [Description("Elemental Converter (Wind)")]
        PROPERTYWIND = 92,
        [Description("Elemental Converter (Earth)")]
        PROPERTYGROUND = 93,
        [Description("Undead Property")]
        PROPERTYUNDEAD = 97,
        [Description("Aura Blade")]
        AURABLADE = 103,
        [Description("Parrying")]
        PARRYING = 104,
        [Description("Concentration")]
        LKCONCENTRATION = 105,
        [Description("Berserk")]
        BERSERK = 107,
        [Description("Assumptio")]
        ASSUMPTIO = 110,
        [Description("Mystical Amplification")]
        MYST_AMPLIFY = 113,
        [Description("Enchant Deadly Poison")]
        EDP = 114,
        [Description("True Sight")]
        TRUESIGHT = 115,
        [Description("Wind Walk")]
        WINDWALK = 116,
        [Description("Meltdown")]
        MELTDOWN = 117,
        [Description("Cart Boost")]
        CARTBOOST = 118,
        [Description("Reject Sword")]
        SWORDREJECT = 120,
        [Description("Mind Breaker")]
        MINDBREAKER = 126,
        [Description("Memorize")]
        MEMORIZE = 127,
        [Description("Magnum Break")]
        MAGNUM = 131,
        [Description("Autoberserk")]
        AUTOBERSERK = 132,
        [Description("Dodge On")]
        DODGE_ON = 143,
        [Description("Running")]
        RUN = 145,
        [Description("Elemental Converter (Dark)")]
        PROPERTYDARK = 146,
        [Description("Full Adrenaline Rush")]
        ADRENALINE2 = 147,
        [Description("Elemental Converter (Ghost)")]
        PROPERTYTELEKINESIS = 148,
        SOULLINK = 149,
        // Resentment Box is also:
        // - Tasty Pink Ration (10 min)
        // - Chewy Ricecake (30 min)
        RESENTMENT_BOX = 150,
        // Drowisness Box is also:
        // - Tasty White Ration (10 mins)
        DROWSINESS_BOX = 151,
        [Description("Kaizel")]
        KAIZEL = 156,
        [Description("Kaahi")]
        KAAHI = 157,
        [Description("Kaupe")]
        KAUPE = 158,
        [Description("One Hand Quicken")]
        ONEHANDQUICKEN = 161,
        [Description("Solar, Lunar, Stellar Heat")]
        WARM = 165,
        [Description("Comfort of the Sun")]
        SUN_COMFORT = 169,
        [Description("Comfort of the Moon")]
        MOON_COMFORT = 170,
        [Description("Comfort of the Stars")]
        STAR_COMFORT = 171,
        [Description("Preserve")]
        PRESERVE = 181,
        [Description("Chase Walk")]
        CHASEWALK = 182,
        SUNLIGHT_BOX = 184,
        [Description("Double Casting")]
        DOUBLECASTING = 186,
        [Description("Maximum Overthrust")]
        OVERTHRUSTMAX = 188,
        [Description("Homunculus Avoid")]
        HOM_AVOID = 192,
        [Description("Shrink")]
        CR_SHRINK = 197,
        [Description("Sight Blaster")]
        SIGHTBLASTER = 198,
        [Description("Madness Canceller")]
        MADNESSCANCEL = 203,
        GATLINGFEVER = 204,
        [Description("Peel Change")]
        PEEL_CHANGE = 206,
        [Description("Bunshin no Jutsu")]
        BUNSINJYUTSU = 207,
        [Description("Aura Ninja")]
        AURA_NINJA = 208,
        [Description("Adjustment")]
        ADJUSTMENT = 209,
        [Description("Accuracy")]
        ACCURACY = 210,
        //FOODS
        FOOD_STR = 241,
        FOOD_AGI = 242,
        FOOD_VIT = 243,
        FOOD_DEX = 244,
        FOOD_INT = 245,
        FOOD_LUK = 246,
        // Flee Scroll is also:
        // -- Spray of Flowers (flee +10, 5 mins) 
        FLEE_SCROLL = 247,
        ACCURACY_SCROLL = 248,
        [Description("Field Manual 100%")]
        FIELD_MANUAL = 250,
        CASH_RECEIVEITEM = 252,
        FOOD_VIT_CASH = 273,
        BOX_OF_THUNDER = 289,
        REGENERATION_POTION = 292,
        CRITICALPERCENT = 295,
        GLASS_OF_ILLUSION = 296,
        MENTAL_POTION = 298,
        SPELLBREAKER = 300,
        TARGET_BLOOD = 301,
        GHOSTRING = 302,
        ANGELING = 302,
        CASH_PLUSECLASSXP = 312,
        [Description("Enchant Blade")]
        ENCHANT_BLADE = 316,
        //Rune Knight Runes
        THURISAZ = 319,
        HAGALAZ = 320,
        [Description("Fighting Spirit")]
        FIGHTINGSPIRIT = 322,
        [Description("Lauda Agnus")]
        LAUDA_AGNUS = 331,
        [Description("Lauda Ramus")]
        LAUDA_RAMUS = 332,
        HALLUCINATIONWALK = 334,
        [Description("Fear Breeze")]
        FEARBREEZE = 352,
        [Description("Recognized Spell")]
        RECOGNIZEDSPELL = 355,
        ACCELERATION = 361,
        TAO_GUNKA = 368,
        ABELHA = 369,
        SR_ORCS = 371,
        ORC_HEROI = 370,
        OVERHEAT = 373,
        [Description("Vanguard Force")]
        FORCEOFVANGUARD = 391,
        [Description("Shadow Spell")]
        AUTOSHADOWSPELL = 393,
        [Description("Prestige")]
        PRESTIGE = 402,
        [Description("Inspiration")]
        INSPIRATION = 407,
        [Description("Rising Dragon")]
        RAISINGDRAGON = 410,
        ACARAJE = 414,
        [Description("Gentle Touch-Convert")]
        GENTLETOUCH_CHANGE = 426,
        [Description("Gentle Touch-Revitalize")]
        GENTLETOUCH_REVITALIZE = 427,
        [Description("Dances with Wargs")]
        DANCE_WITH_WUG = 441,
        [Description("Windmill Rush")]
        RUSH_WINDMILL = 442,
        [Description("Moonlight Serenade")]
        MOONLIT_SERENADE = 447,
        [Description("Cart Boost")]
        GN_CARTBOOST = 461,
        [Description("HP Increase Potion(Large)")]
        HP_INCREASE_POTION_LARGE = 480,
        SP_INCREASE_POTION_LARGE = 481,
        //ENERGY_DRINK_RESERCH = 481,
        VITATA_POTION = 483,
        ENRICH_CELERMINE_JUICE = 484,
        FULL_SWINGK = 486,
        MANA_PLUS = 487,
        //3RD foods
        STR_3RD_FOOD = 491,
        INT_3RD_FOOD = 492,
        VIT_3RD_FOOD = 493,
        DEX_3RD_FOOD = 494,
        AGI_3RD_FOOD = 495,
        LUK_3RD_FOOD = 496,
        PAINKILLER = 577,
        RIDDING = 613,
        OVERLAPEXPUP = 618,
        MONSTER_TRANSFORM = 621,
        SIT = 622,
        [Description("16th Night")]
        IZAYOI = 652,
        COMBAT_PILL = 662,
        RWC_2011_SCROLL = 664,
        //RED_BOOSTER = 664,
        [Description("Arrow Equipped")]
        ARROW_ON = 695,
        [Description("Frigg's Song")]
        FRIGG_SONG = 715,
        [Description("Intense Telekinesis")]
        TELEKINESIS_INTENSE = 717,
        [Description("Unlimited")]
        UNLIMIT = 722,
        [Description("Eternal Chain")]
        E_CHAIN = 753,
        LIMIT_POWER_BOOSTER = 867,
        //Elemental Potions
        RESIST_PROPERTY_WATER = 908,
        RESIST_PROPERTY_GROUND = 909,
        RESIST_PROPERTY_FIRE = 910,
        RESIST_PROPERTY_WIND = 911,
        [Description("Infinity Drink")]
        INFINITY_DRINK = 1065,
        [Description("Basílica")]
        BASILICA = 1122,
        LUX_AMINA = 1154,
        [Description("Powerful Faith")]
        POWERFUL_FAITH = 1160,
        [Description("Firm Faith")]
        FIRM_FAITH = 1162,
        REF_T_POTION = 1169,
        RED_HERB_ACTIVATOR = 1170,
        BLUE_HERB_ACTIVATOR = 1171,
        [Description("Shield Spell")]
        SHIELDSPELL = 1316,
        CASH_PLUSEXP = 1400,
        SPIRIT = 1401,
        MISTY_FROST = 1141,
        [Description("Solar, Lunar and Stellar Miracle")]
        MIRACLE = 2113,
        [Description("Research Report")]
        RESEARCHREPORT = 1248,
        [Description("Kaite")]
        KAITE = 1402,                                                     
        BOX_OF_STORMS = 1405,
        //PADAWAN
        [Description("Force Element (Earth)")]
        ELEMENT_EARTH = 1423,
        [Description("Force Element (Wind)")]
        ELEMENT_WIND = 1424,
        [Description("Force Element (Water)")]
        ELEMENT_WATER = 1425,
        [Description("Force Element (Fire)")]
        ELEMENT_FIRE = 1426,
        [Description("Force Element (Ghost)")]
        ELEMENT_GHOST = 1427,
        [Description("Force Element (Shadow)")]
        ELEMENT_SHADOW = 1428,
        [Description("Force Element (Holy)")]
        ELEMENT_HOLY = 1429,
        //SITH
        [Description("Saber Parry")]
        SABERPARRY = 1430,
        [Description("Force Concentration")]
        FORCECONCENTRATE = 1432,
        [Description("Saber Thrust")]
        SABERTHRUST = 1438,
        [Description("Cold Skin")]
        COLDSKIN = 1439,
        [Description("Force Projection")]
        PROJECTION = 1441,
        //JEDI
        [Description("Force Levitate")]
        FORCELEVITATE = 1435,
        [Description("Jedi Frenzy")]
        JEDIFRENZY = 1433,
        [Description("Jedi Stealth")]
        JEDISTEALTH = 1437,
        [Description("Force Sacrifice")]
        FORCESACRIFICE = 1434,
        [Description("Force Persuasion")]
        FORCEPERSUASION = 1431,
        GREED_PARRY = 1442,
        HALOHALO = 2011,
        STR_Biscuit_Stick = 2035,
        VIT_Biscuit_Stick = 2036,
        AGI_Biscuit_Stick = 2037,
        INT_Biscuit_Stick = 2038,
        DEX_Biscuit_Stick = 2039,
        LUK_Biscuit_Stick = 2040,
        [Description("Union of the Sun, Moon and Stars")]
        FUSION = 2063,
        BOVINE = 2068,
        DRAGON = 2069,

        // DEBUFFS
        DECREASE_AGI = 13,
        [Description("50% Weight")]
        WEIGHT50 = 35,
        [Description("90% Weight")]
        WEIGHT90 = 36,
        BLEEDING = 124,
        SLOW_CAST = 282,
        CRITICALWOUND = 286,
        FREEZING = 351,
        DEEP_SLEEP = 435,
        MANDRAGORA = 470,
        STUN = 877,
        BURNING = 881,
        POISON = 883,
        CURSE = 884,
        SILENCE = 885,
        CONFUSION = 886,
        BLIND = 887,
        FEAR = 891,
        HALLUCINATION_DEBUFF = 1416,
    }

}

