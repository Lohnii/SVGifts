using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharactersSO", menuName = "StardewValleyGiftsUnity/CharacterSO")]
public class CharactersSO : ScriptableObject {
    public string charName;
    public Gifts[] gifts = new Gifts[5];

    public bool VerifyIfDifferent(string item, GiftType tipo){
        Items it = Manager.ParseItem(item);
        for (int g = 0; g < gifts.Length; g++)
        {
            if(tipo == gifts[g].giftType) { //mesmo tipo                    
                for (int e = 0; e < gifts[g].exceptions.Count; e++){
                    if(gifts[g].exceptions[e] == it) return false;
                }
            }
        }

        return true;
    }

}

[System.Serializable]
public class Gifts {
    public GiftType giftType;
    public List<Items> exceptions;

    public List<Items>[] items;
} 

public enum GiftType {
    Loves, Likes, Neutral, Dislikes, Hates, None
}

public enum Items {
    //Crops
    BlueJazz, Cauliflower, CoffeeBean, Garlic, GreenBean, Kale, Parsnip, Potato, Rhubarb, Strawberry, Tulip, UnmilledRice, Blueberry, Corn, Hops, 
    HotPepper, Melon, Poppy, Radish, RedCabbage, Starfruit, SummerSpangle, Sunflower, Tomato, Wheat, Amaranth, Artichoke, Beet, BokChoy, Cranberries, 
    Eggplant, FairyRose, Grape, Pumpkin, Yam, AncientFruit, CactusFruit, Pineapple, QiFruit, SweetGemBerry, TaroRoot, TeaLeaves,

    //Artisan Goods
    Honey, Beer, Cheese, GoatCheese, Mead, PaleAle, Wine, Coffee, GreenTea, Juice, Cloth, DinosaurMayonnaise, 
    DuckMayonnaise, Mayonnaise, VoidMayonnaise, Oil, TruffleOil, AgedRoe, Caviar, JelliesAndPickles, MapleSyrup, OakResin, PineTar,
    
    //Cooking
    AlgaeSoup, ArtichokeDip, AutumnsBounty, BakedFish, BananaPudding, BeanHotpot, BlackberryCobbler, BlueberryTart, Bread, Bruschetta, CarpSurprise, CheeseCauliflower, 
    ChocolateCake, Chowder, Coleslaw, CompleteBreakfast, Cookie, CrabCakes, CranberryCandy, CranberrySauce, CrispyBass, DishOTheSea, EggplantParmesan, Escargot, 
    FarmersLunch, FiddleheadRisotto, FishStew, FishTaco, FriedCalamari, FriedEel, FriedEgg, FriedMushroom, FruitSalad, GlazedYams, GingerAle, Hashbrowns, IceCream, 
    LobsterBisque, LuckyLunch, MakiRoll, MangoStickyRice, MapleBar, MinersTreat, Omelet, PaleBroth, Pancakes, ParsnipSoup, PepperPoppers, PinkCake, Pizza, PlumPudding, 
    Poi, PoppyseedMuffin, PumpkinPie, PumpkinSoup, RadishSalad, RedPlate, RhubarbPie, RicePudding, RoastedHazelnuts, RootsPlatter, Salad, SalmonDinner, Sashimi, 
    SeafoamPudding, ShrimpCocktail, Spaghetti, SpicyEel, SquidInkRavioli, StirFry, StrangeBun, Stuffing, SuperMeal, SurvivalBurger, TomKhaSoup, Tortilla, 
    TripleShotEspresso, TropicalCurry, TroutSoup, VegetableMedley,

    //Crafting
    BugSteak, FieldSnack, LifeElixir, OilofGarlic,CherryBomb,Bomb,MegaBomb,
    Sprinkler,QualitySprinkler,IridiumSprinkler,
    BarbedHook,CorkBobber,CuriosityLure,DressedSpinner,LeadBobber,QualityBobber,Spinner,TrapBobber,TreasureHunter,

    //floors and paths
    WoodFloor,RusticPlankFloor,StrawFloor,WeatheredFloor,CrystalFloor,StoneFloor,StoneWalkwayFloor,BrickFloor,WoodPath,GravelPath,CobblestonePath,
    SteppingStonePath,CrystalPath,    
    //fences
    Gate,WoodFence,StoneFence,IronFence,HardwoodFence,
    //fertilizers
    BasicFertilizer,BasicRetainingSoil,DeluxeFertilizer,DeluxeRetainingSoil,DeluxeSpeedGro,HyperSpeedGro,QualityFertilizer,QualityRetainingSoil,SpeedGro,TreeFertilizer,

    //Flowers
    SweetPea, Crocus,
    //Minerals
    EarthCrystal, FireQuartz, FrozenTear, Quartz, Amethyst, Aquamarine, Diamond, Emerald, Jade, PrismaticShard, Ruby, Topaz, Aerinite, Alamite, Baryte, Basalt, Bixite, 
    Calcite, Celestine, Dolomite, Esperite, FairyStone, FireOpal, Fluorapatite, Geminite, GhostCrystal, Granite, Helvite, Hematite, Jagoite, Jamborite, Jasper, Kyanite, 
    LemonStone, Limestone, Lunarite, Malachite, Marble, Mudstone, Nekoite, Neptunite, Obsidian, OceanStone, Opal, Orpiment, PetrifiedSlime, Pyrite, Sandstone, Slate, 
    Soapstone, StarEgg, Tigerseye, Geode, FrozenGeode, MagmaGeode, OmniGeode,StarShards,ThunderEgg, 
    //Fruit Trees
    Apple,Apricot,Banana,Cherry,Mango,Orange,Peach,Pomegranate,

    //Vegetables 
    FiddleheadFern,

    //Specials
    ArtifactTrove, BearsKnowledge, Bouquet, ClubCard, CoffeeMaker, DarkTalisman, Deconstructor, DragonTooth, DwarvishTranslationGuide, Enricher, GalaxySoul, GoldenCoconut, 
    GoldenPumpkin, GoldenWalnut, Hay, KeyToTheTown, MagicInk, MagicRockCandy, MagnifyingGlass, MermaidsPendant, MiniFridge, MovieTicket, OrnateNecklace, Pearl, 
    PierresMissingStocklist, PinaColada, PressureNozzle, PrismaticJelly, QiGem, QiSeasoning, RustyKey, SewingMachine, SkullKey, SlimeEgg, SpecialCharm, SpringOnionMastery, 
    SquidInk, Stardrop, SupplyCrate, Telephone, TreasureChest, VoidGhostPendant, WeddingRing, WiltedBouquet, WoodChipper, Workbench, RabbitsFoot,

    //foraging
    Sap,CommonMushroom,Daffodil,Dandelion,Leek,Morel,Salmonberry,SpringOnion,WildHorseradish,RedMushroom,SpiceBerry,Blackberry,Chanterelle,
    Hazelnut,WildPlum,CrystalFruit,Holly,SnowYam,WinterRoot,BeachClam,Cockle,Coral,Mussel,NautilusShell,Oyster,RainbowShell,SeaUrchin,Seaweed,
    MinesCaveCarrot,PurpleMushroom,DesertCactusFruit,Coconut,CavernDinosaurEgg,IslandGinger,MagmaCap,

    //fish
    Angler,Crimsonfish,Glacierfish,GlacierfishJr,Legend,LegendII,MsAngler,MutantCarp,RadioactiveCarp,SonofCrimsonfishAlbacore,Anchovy,Clam,Eel,Flounder,
    Halibut,Herring,Octopus,Pufferfish,RedMullet,RedSnapper,Sardine,SeaCucumber,SonofCrimsonfish,Squid,SuperCucumber,Tilapia,TunaAngler,Bream,Catfish,Chub,
    Dorado,Lingcod,Perch,Pike,RainbowTrout,Salmon,Shad,SmallmouthBass,Sunfish,TigerTrout,WalleyeLakeBullhead,Carp,LargemouthBass
    ,MidnightCarp,Sturgeon,WalleyeForestPondMidnightCarp,WalleyeWoodsCarp,WoodskipGhostfish,
    IcePip,LavaEel,StonefishCarp,RadioactiveCarpSandfish,ScorpionCarpBugLairCarp,SlimejacksSwampCatfish,VoidSalmonMarketBlobfish,MidnightSquid,
    SpookFish,SuperCucumberPotClam,Crab,Crayfish,Lobster,Periwinkle,Shrimp,SnailIslandBlueDiscus,Lionfish,
    Stingray,Tuna,

    //animals and foraging
    Egg,LargeEgg,BrownEgg,LargeBrownEgg,DinosaurEgg,DuckEgg,DuckFeather,GoldenEgg,Wool,VoidEgg,Milk,LargeMilk,GoatMilk,LargeGoatMilk,OstrichEgg,Truffle,Roe,
    Slime,SlimeBall,Cat,Dog,Horse,

    //seeds
    AllSeeds,

    BoneFragment,CinderShard,Coal,CopperBars,GoldBars,GoldOre,IridiumBars,IridiumOre,IronBars,RefinedQuartz,

    BatteryPacks,Clay,Fiber,Hardwood,Stone,Wood,WoodAmphibianFossil,Anchor,AncientDoll,AncientDrum,AncientSeed,AncientSword,Arrowhead,BoneFlute,ChewingStick,
    ChickenStatue,ChippedAmphora,DriedStarfish,DwarfGadget,DwarfScrollI,DwarfScrollII,DwarfScrollIII,DwarfScrollIV,DwarvishHelm,ElvishJewelry,GlassShards,GoldenMask,
    GoldenRelic,NautilusFossil,OrnamentalFan,PalmFossil,PrehistoricHandaxe,PrehistoricRib,PrehistoricScapula,PrehistoricSkull,PrehistoricTibia,PrehistoricTool,
    PrehistoricVertebra,RareDisc,RustyCog,RustySpoon,RustySpur,SkeletalHand,SkeletalTail,StrangeDoll,Trilobite,Albacore,WalleyeLake,Bullhead,WalleyeForestPond,
    WalleyeWoods,Woodskip,Ghostfish,Stonefish,Sandfish,ScorpionCarpBugLair,SlimejacksSwamp,VoidSalmonMarket,Blobfish,SuperCucumberPot,SnailIsland,BlueDiscus,
    CaveCarrot,Driftwood,JackOLantern,Rice,SolarEssence,TeaSet,Vinegar,VoidEssence,WheatFlour,

    //hates
    Bait,MagicBait,Magnet,WildBait,FossilizedLeg,FossilizedRibs,FossilizedSkull,FossilizedSpine,FossilizedTail,MummifiedFrog,MummifiedBat,SnakeSkull,SnakeVertebrae,
    BugMeat,BatWing,Trash,IronOre,SoggyNewspaper,BrokenCD,BrokenGlasses,JojaCola,RottenPlant,CopperOre,CrabPot,DrumBlock,EnergyTonic,ErrorItem,ExplosiveAmmo,FairyDust,
    FluteBlock,GrassStarter,GreenAlgae,JournalScrap,MonsterMusk,MuscleRemedy,RadioactiveBar,RadioactiveOre,RainTotem,SecretNote,Snail,Sugar,Torch,WarpTotemBeach,
    WarpTotemDesert,WarpTotemFarm,WarpTotemIsland,WarpTotemMountains,WhiteAlgae,

}