using System;
using System.ComponentModel;

namespace _4RTools.Utils
{

    [Flags]
    public enum EffectStatusIDs : uint
    {
        //Status
        QUAGMIRE = 8,
        HALLUCINATIONWALK = 334,
        HALLUCINATION = 34,
        [Description("Provoke")]
        PROVOKE = 2015,
        PROPERTYUNDEAD = 97,

        MISTY_FROST = 1141,
        OVERHEAT = 373,
        [Description("Endure")]
        ENDURE = 1,
        PAINKILLER = 577,
        [Description("Spear Quicken")]
        SPEARQUICKEN = 68,

        MONSTER_TRANSFORM = 621,
        [Description("Prestige")]
        PRESTIGE = 402,
        [Description("Inspiration")]
        INSPIRATION = 407,
        [Description("Aegis Domini")]
        SHIELDSPELL = 1316,

        [Description("Solar, Lunar and Stellar Miracle")]
        MIRACLE= 2113,
        SPIRIT = 1401,
        [Description("Solar, Lunar, Stellar Heat")]
        WARM = 165,
        [Description("Comfort of the Sun")]
        SUN_COMFORT = 169,
        [Description("Comfort of the Moon")]
        MOON_COMFORT = 170,
        [Description("Comfort of the Stars")]
        STAR_COMFORT = 171,
        [Description("Disparo Selvagem")]
        FEARBREEZE = 352,
        SOULLINK = 149,
        [Description("Concentration")]
        CONCENTRATION = 3,
        [Description("True Sight")]
        TRUESIGHT = 115,
        [Description("Glória")]
        GLORIA = 21,
        [Description("Magnificat")]
        MAGNIFICAT = 20,
        [Description("Angelus")]
        ANGELUS = 9,
        [Description("Lauda Agnus")]
        LAUDA_AGNUS = 331,
        [Description("Lauda Ramus")]
        LAUDA_RAMUS = 332,
        [Description("Wind Walk")]
        WINDWALK = 116,
        [Description("Overthrust")]
        OVERTHRUST = 25,
        [Description("Maximum Overthrust")]
        OVERTHRUSTMAX = 188,
        [Description("Weapon Perfection")]
        WEAPONPERFECT = 24,
        [Description("Maximize")]
        MAXIMIZE = 26,
        [Description("Crazy Uproar")]
        CRAZY_UPROAR = 30,
        [Description("Cart Boost")]
        CARTBOOST = 118,
        [Description("Meltdown")]
        MELTDOWN = 117,
        [Description("Adrenaline Rush")]
        ADRENALINE = 23,
        [Description("Adrenalina Concentrada")]
        ADRENALINE2 = 147,
        [Description("Energy Coat")]
        ENERGYCOAT = 31,
        [Description("Sight Blaster")]
        SIGHTBLASTER = 198,
        [Description("Auto Spell")]
        AUTOSPELL = 65,
        [Description("Double Casting")]
        DOUBLECASTING = 186,
        [Description("Memorize")]
        MEMORIZE = 127,
        [Description("Preserve")]
        PRESERVE = 181,
        [Description("Reject Sword")]
        SWORDREJECT = 120,
        [Description("Encantar com Veneno Mortal")]
        EDP = 114,
        [Description("Refletir Veneno")]
        POISONREACT = 7,
        [Description("Autoguard")]
        AUTOGUARD = 58,
        [Description("Reflect Shield")]
        REFLECTSHIELD = 59,
        [Description("Defender")]
        DEFENDER = 62,
        [Description("Shrink")]
        CR_SHRINK = 197,
        [Description("One Hand Quicken")]
        ONEHANDQUICKEN = 161,
        [Description("Two Hand Quicken")]
        TWOHANDQUICKEN = 2,
        [Description("Lâmina de Aura")]
        AURABLADE = 103,
        [Description("Concentration")]
        LKCONCENTRATION = 105,
        [Description("Parrying")]
        PARRYING = 104,
        [Description("Berserk")]
        BERSERK = 107,
        [Description("Autoberserk")]
        AUTOBERSERK = 132,
        [Description("Aura Ninja")]
        AURA_NINJA = 208,
        [Description("Peel Change")]
        PEEL_CHANGE = 206,
        COMBAT_PILL = 662,
        [Description("Enchant Blade")]
        ENCHANT_BLADE = 316,
        RWC_2011_SCROLL = 664,
        INFINITY_DRINK = 1065,
        HP_INCREASE_POTION_LARGE = 480,
        SP_INCREASE_POTION_LARGE = 481,
        ENRICH_CELERMINE_JUICE = 484,
        RED_HERB_ACTIVATOR = 1170,
        BLUE_HERB_ACTIVATOR = 1171,
        REF_T_POTION = 1169,
        OVERLAPEXPUP = 618,
        PROTECTARMOR = 56,
        CASH_PLUSEXP = 1400,
        CASH_PLUSECLASSXP = 312,
        CASH_RECEIVEITEM = 252,
        [Description("Aceleração")]
        ACCELERATION = 361,
        LIMIT_POWER_BOOSTER = 867,
        [Description("Ataque Gatling")]
        GATLINGFEVER = 204,
        ASSUMPTIO = 110,
        [Description("Proteção da Vanguarda")]
        FORCEOFVANGUARD = 391,
        [Description("Ilimitar")]
        UNLIMIT = 722,
        [Description("Poema de Bragi")]
        POEMBRAGI = 72,
        APPLEIDUN = 73,
        [Description("Sinfonia dos Ventos")]
        RUSH_WINDMILL = 442,
        [Description("Serenata ao Luar")]
        MOONLIT_SERENADE = 447,
        [Description("Dragão Ascendente")]
        RAISINGDRAGON = 410,
        [Description("Firm Faith")]
        FIRM_FAITH = 1162,
        [Description("Powerful Faith")]
        POWERFUL_FAITH = 1160,
        [Description("Chakra do Vigor")]
        GENTLETOUCH_REVITALIZE = 427,
        [Description("Chakra da Fúria")]
        GENTLETOUCH_CHANGE = 426,
        [Description("Propulsão do Carrinho")]
        GN_CARTBOOST = 461,
        [Description("Reflexo de Combate")]
        WEAPONBLOCKING = 337,
        [Description("Canção de Frigga")]
        FRIGG_SONG = 715,
        [Description("Research Report")]
        RESEARCHREPORT = 1248,
        [Description("Resistência Final")]
        MADNESSCANCEL = 203,
        [Description("Pânico do Justiceiro")]
        ADJUSTMENT = 209,
        [Description("Aumentar Precisão")]
        ACCURACY = 210,
        [Description("Fúria Interior")]
        FURY = 86,
        [Description("Impositio Manus")]
        IMPOSITIO = 15,
        [Description("Reação Ilimitada")]
        E_CHAIN = 753,
        [Description("Desejo das Sombras")]
        AUTOSHADOWSPELL = 393,
        [Description("Furtividade")]
        CLOAKING = 5,
        [Description("Esconderijo")]
        HIDING = 4,
        [Description("Impacto Explosivo")]
        MAGNUM = 131,
        [Description("Aura de Combate")]
        FIGHTINGSPIRIT = 322,
        [Description("Basílica")]
        BASILICA = 1122,
        EDEN = 9999,
        //ELEMENTAL CONVERTERS
        [Description("Brisa Leve (Fogo)")]
        PROPERTYFIRE = 90,
        [Description("Brisa Leve (Água)")]
        PROPERTYWATER = 91,
        [Description("Brisa Leve (Vento)")]
        PROPERTYWIND = 92,
        [Description("Brisa Leve (Terra)")]
        PROPERTYGROUND = 93,
        [Description("Brisa Leve (Sombrio)")]
        PROPERTYDARK = 146,
        [Description("Brisa Leve (Fantasma)")]
        PROPERTYTELEKINESIS = 148,
        WEAPONPROPERTY = 64,
        [Description("Brisa Leve (Sagrado)")]
        ASPERSIO = 17,
        [Description("Enlouquecedor")]
        MINDBREAKER = 126,
        [Description("Corrida")]
        RUN = 145,
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

        FALCON_ON = 28,
        ARROW_ON = 695,
        PECO_RIDING = 27,
        GREED_PARRY = 1442,

        [Description("Field Manual 100%")]
        FIELD_MANUAL = 250,

        FULL_SWINGK = 486,
        MANA_PLUS = 487,

        //POTIONS
        CONCENTRATION_POTION = 37,
        AWAKENING_POTION = 38,
        BERSERK_POTION = 39,
        ASPDPOTIONINFINITY = 40,

        //FOODS
        FOOD_STR = 241,
        FOOD_AGI = 242,
        FOOD_VIT = 243,
        FOOD_DEX = 244,
        FOOD_INT = 245,
        FOOD_LUK = 246,
        FOOD_VIT_CASH = 273,
        ACARAJE = 414,
        STR_Biscuit_Stick = 2035,
        VIT_Biscuit_Stick = 2036,
        AGI_Biscuit_Stick = 2037,
        INT_Biscuit_Stick = 2038,
        DEX_Biscuit_Stick = 2039,
        LUK_Biscuit_Stick = 2040,


        REGENERATION_POTION = 292,

        CRITICALPERCENT = 295,


        //Boxes
        // Drowisness Box is also:
        // - Tasty White Ration (10 mins)
        DROWSINESS_BOX = 151,
        // Resentment Box is also:
        // - Tasty Pink Ration (10 min)
        // - Chewy Ricecake (30 min)
        RESENTMENT_BOX = 150,
        SUNLIGHT_BOX = 184,

        BOX_OF_STORMS = 1405,


        //Elemental Potions
        RESIST_PROPERTY_WATER = 908,
        RESIST_PROPERTY_GROUND = 909,
        RESIST_PROPERTY_FIRE = 910,
        RESIST_PROPERTY_WIND = 911,

        BOX_OF_THUNDER = 289,
        SPEED_POT = 41,

        ENERGY_DRINK_RESERCH = 481,
        [Description("Maestria Arcana")]
        RECOGNIZEDSPELL = 355,
        [Description("Cambalhota")]
        DODGE_ON = 143,
        [Description("Inspiração")]
        IZAYOI = 652,
        [Description("Imagem Falsa")]
        BUNSINJYUTSU = 207,
        TARGET_BLOOD = 301,

        //Scrolls
        [Description("Canto Candidus")]
        INC_AGI = 12,
        [Description("Clementia")]
        BLESSING = 10,

        //3RD foods
        STR_3RD_FOOD = 491,
        INT_3RD_FOOD = 492,
        VIT_3RD_FOOD = 493,
        DEX_3RD_FOOD = 494,
        AGI_3RD_FOOD = 495,
        LUK_3RD_FOOD = 496,

        //Rune Knight Runes
        //OTHILA = 322,
        HAGALAZ = 320,
        THURISAZ = 319,
        LUX_AMINA = 1154,

        [Description("Telecinesia")]
        TELEKINESIS_INTENSE = 717,
        [Description("Amplificação Mística")]
        MYST_AMPLIFY = 113,

        // DEBUFFS
        CRITICALWOUND = 286,
        FREEZING = 351,
        CURSE = 884,
        BLEEDING = 124,
        SILENCE = 885,
        DECREASE_AGI = 13,
        CONFUSION = 886,
        STUN = 877,
        DEEP_SLEEP = 435,
        POISON = 883,

        SLOW_CAST = 282,
        MANDRAGORA = 470,
        BURNING = 881,

        FEAR = 891,
        BLIND = 887,

        // pergaminhos cheffenia

        GHOSTRING = 302,
        ANGELING = 302,
        TAO_GUNKA = 368,
        SR_ORCS = 371,
        ORC_HEROI = 370,
        ABELHA = 369,

        [Description("Dança com Lobos")]
        DANCE_WITH_WUG = 441,
        SIT = 622,

        SPELLBREAKER = 300,
        HALOHALO = 2011,
        // Flee Scroll is also:
        // -- Spray of Flowers (flee +10, 5 mins) 
        FLEE_SCROLL = 247,
        ACCURACY_SCROLL = 248,
        GLASS_OF_ILLUSION = 296,
        MENTAL_POTION = 298,
        VITATA_POTION = 483,
        RIDDING = 613,
        [Description("Divina Providência")]
        PROVIDENCE = 61,
        [Description("União Solar, Lunar e Estelar")]
        FUSION = 2063,
        BOVINE = 2068,
        DRAGON = 2069,
        RED_BOOSTER = 664,
        [Description("Bater em Retirada")]
        HOM_AVOID = 192,
        [Description("Kaupe")]
        KAUPE = 158,
        [Description("Kaite")]
        KAITE = 1402,
        [Description("Kaizel")]
        KAIZEL = 156,
        [Description("Kaahi")]
        KAAHI = 157,
        ANTI_BOT = 5020,
        [Description("Espreitar")]
        CHASEWALK = 182,

    }

}

