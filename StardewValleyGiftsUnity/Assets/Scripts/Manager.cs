using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class Manager : MonoBehaviour
{
    public CharactersSO[] characters;
    public UniversalOpinionsSO[] universals;

    public InputField tipoStr;

    public SerializableList<string> failedStr;

    public bool addAllUniv;

    public void AddUniversal(string itemStr){
        //pega o tipo
        GiftType tipo = GiftType.None;
        try {
            //success
            tipo = ParseGiftType(tipoStr.text);
            AddUniversal(itemStr, tipo);
        } catch {
            print("Unable to parse " + tipoStr);
        }
    }

    public void AddUniversal(string itemStr, GiftType tipo){
        //pega o universalSO
        int u = Array.FindIndex(universals,x => x.giftType == tipo);

        //verifica se o index eh valido
        if(u < 0 || u > universals.Length){
            print("Could not find universal type " + u + " " + tipo.ToString());
        }

        try {
            //success
            universals[u].items.Add(ParseItem(itemStr));
            //print("added " + itemStr);

        } catch {
            print("Could not parse item " + itemStr);
            failedStr.list.Add(itemStr);
        }
    }

    private void Start() {
        if(addAllUniv) AddAllUniversals();
    }

    private void AddAllUniversals() {
        
        //likes
        string flowers = "SweetPea,Crocus,Sunflower,Tulip,SummerSpangle,FairyRose,BlueJazz";
        AddSpecific(flowers, GiftType.Likes);
        string minerals = "EarthCrystal,FireQuartz,FrozenTear";
        AddSpecific(minerals, GiftType.Likes);
        string fruitTreeFruits = "Apple,Apricot,Cherry,Orange,Peach,Pomegranate,";
        AddSpecific(fruitTreeFruits, GiftType.Likes);
        string gems = "Amethyst,Aquamarine,Diamond,Emerald,Jade,Ruby,Topaz";
        AddSpecific(gems, GiftType.Likes);
        string vegetables = "Amaranth,Artichoke,Beet,BokChoy,Cauliflower,Corn,Eggplant,FiddleheadFern,Garlic,GreenBean,Kale,Parsnip,Potato,Pumpkin,Radish,RedCabbage,TaroRoot,Tomato,Yam";
        AddSpecific(vegetables, GiftType.Likes);
        string likes = "LifeElixir,MapleSyrup";
        AddSpecific(likes, GiftType.Neutral);

        //neutrals
        string neutrals = "Bread,Clam,Coral,DuckFeather,FriedEgg,Hops,NautilusShell,RainbowShell,Roe,SquidInk,SweetGemBerry,TeaLeaves,Truffle,Wheat,Wool";
        AddSpecific(neutrals, GiftType.Neutral);
        

        //dislikes
        string buildingMat = "BatteryPacks,Clay,Fiber,Hardwood,Stone,Wood";
        AddSpecific(buildingMat, GiftType.Dislikes);
        string artifacts = "BatteryPacks,Clay,Fiber,Hardwood,Stone,WoodAmphibianFossil,Anchor,AncientDoll,AncientDrum,AncientSeed,AncientSword,Arrowhead,BoneFlute,ChewingStick,ChickenStatue,ChippedAmphora,DinosaurEgg,DriedStarfish,DwarfGadget,DwarfScrollI,DwarfScrollII,DwarfScrollIII,DwarfScrollIV,DwarvishHelm,ElvishJewelry,GlassShards,GoldenMask,GoldenRelic,NautilusFossil,OrnamentalFan,PalmFossil,PrehistoricHandaxe,PrehistoricRib,PrehistoricScapula,PrehistoricSkull,PrehistoricTibia,PrehistoricTool,PrehistoricVertebra,RareDisc,RustyCog,RustySpoon,RustySpur,SkeletalHand,SkeletalTail,StrangeDoll,StrangeDoll,Trilobite";
        AddSpecific(artifacts, GiftType.Dislikes);
        string bombs = "CherryBomb,Bomb,MegaBomb";
        AddSpecific(bombs, GiftType.Dislikes);
        string craftedFloorsPaths = "WoodFloor,RusticPlankFloor,StrawFloor,WeatheredFloor,CrystalFloor,StoneFloor,StoneWalkwayFloor,BrickFloor,WoodPath,GravelPath,CobblestonePath,SteppingStonePath,CrystalPath";
        AddSpecific(craftedFloorsPaths, GiftType.Dislikes);
        string fences = "Gate,WoodFence,StoneFence,IronFence,HardwoodFence";
        AddSpecific(fences, GiftType.Dislikes);
        string fertilizer = "BasicFertilizer,BasicRetainingSoil,DeluxeFertilizer,DeluxeRetainingSoil,DeluxeSpeedGro,HyperSpeedGro,QualityFertilizer,QualityRetainingSoil,SpeedGro,TreeFertilizer,";
        AddSpecific(fertilizer, GiftType.Dislikes);
        string fish = "Angler,Crimsonfish,Glacierfish,GlacierfishJr,Legend,LegendII,MsAngler,MutantCarp,RadioactiveCarp,SonofCrimsonfish,Albacore,Anchovy,Clam,Cockle,Crimsonfish,Eel,Flounder,Halibut,Herring,Mussel,Octopus,Oyster,Pufferfish,RedMullet,RedSnapper,Sardine,SeaCucumber,SonofCrimsonfish,Squid,SuperCucumber,Tilapia,Tuna,Angler,Bream,Catfish,Chub,Dorado,Glacierfish,GlacierfishJr,Lingcod,MsAngler,Perch,Pike,RainbowTrout,Salmon,Shad,SmallmouthBass,Sunfish,TigerTrout,WalleyeLake,Bullhead,Carp,Chub,LargemouthBass,Legend,LegendII,Lingcod,MidnightCarp,Perch,RainbowTrout,Sturgeon,WalleyeForestPond,MidnightCarp,Perch,Pike,SmallmouthBass,WalleyeWoods,Carp,Catfish,Woodskip,Ghostfish,IcePip,LavaEel,Stonefish,Carp,MutantCarp,RadioactiveCarp,Sandfish,ScorpionCarpBugLair,Carp,SlimejacksSwamp,Catfish,VoidSalmonMarket,Blobfish,MidnightSquid,Octopus,SeaCucumber,SpookFish,SuperCucumberPot,Clam,Cockle,Crab,Crayfish,Lobster,Mussel,Oyster,Periwinkle,Shrimp,SnailIsland,BlueDiscus,Flounder,LavaEel,Lionfish,MidnightCarp,Octopus,Pufferfish,Stingray,SuperCucumber,Tilapia,Tuna";
        AddSpecific(fish, GiftType.Dislikes);
        string geodeminerals = "Aerinite,Alamite,Baryte,Basalt,Bixite,Calcite,Celestine,Dolomite,Esperite,FairyStone,FireOpal,Fluorapatite,Geminite,GhostCrystal,Granite,Helvite,Hematite,Jagoite,Jamborite,Jasper,Kyanite,LemonStone,Limestone,Lunarite,Malachite,Marble,Mudstone,Nekoite,Neptunite,Obsidian,OceanStone,Opal,Orpiment,PetrifiedSlime,Pyrite,Sandstone,Slate,Soapstone,StarShards,ThunderEgg,Tigerseye";
        AddSpecific(geodeminerals, GiftType.Dislikes);
        string geodes = "Geode,FrozenGeode,MagmaGeode,OmniGeode";
        AddSpecific(geodes, GiftType.Dislikes);
        string seeds = "AllSeeds";
        AddSpecific(seeds, GiftType.Dislikes);
        string sprinkles = "Sprinkler,QualitySprinkler,IridiumSprinkler";
        AddSpecific(sprinkles, GiftType.Dislikes);
        string tackle = "BarbedHook,CorkBobber,CuriosityLure,DressedSpinner,LeadBobber,QualityBobber,Spinner,TrapBobber,TreasureHunter";
        AddSpecific(tackle, GiftType.Dislikes);
        string minedAndMetals = "BoneFragment,CinderShard,Coal,CopperBars,GoldBars,GoldOre,IridiumBars,IridiumOre,IronBars,RefinedQuartz";
        AddSpecific(minedAndMetals, GiftType.Dislikes);

        string dislikes = "CaveCarrot,Driftwood,FieldSnack,JackOLantern,OakResin,Oil,PineTar,QiFruit,Rice,SolarEssence,SpringOnion,TeaSet,UnmilledRice,Vinegar,VoidEgg,VoidEssence,WheatFlour";
        AddSpecific(dislikes, GiftType.Dislikes);

        //hates
        string bait = "Bait,MagicBait,Magnet,WildBait,";
        string fossils = "FossilizedLeg,FossilizedRibs,FossilizedSkull,FossilizedSpine,FossilizedTail,MummifiedFrog,MummifiedBat,SnakeSkull,SnakeVertebrae,";
        string monsterLoot = "Slime,BugMeat,BatWing,";
        string trash = "Trash,Coal,IronOre,Coal,SoggyNewspaper,Cloth,BrokenCD,RefinedQuartz,BrokenGlasses,RefinedQuartz,JojaCola,RottenPlant,";
        string hates = "ArtifactTrove,BugSteak,Carp,CopperOre,CrabPot,DragonTooth,DrumBlock,EnergyTonic,ErrorItem,ExplosiveAmmo,FairyDust,FluteBlock,GrassStarter,GreenAlgae,GoldenCoconut,Hay,IronOre,JournalScrap,MonsterMusk,MuscleRemedy,OilofGarlic,Poppy,QiSeasoning,RadioactiveBar,RadioactiveOre,RainTotem,RedMushroom,Sap,SeaUrchin,SeafoamPudding,Seaweed,SecretNote,SlimeEgg,Snail,StrangeBun,Sugar,Torch,TreasureChest,VoidMayonnaise,WarpTotemBeach,WarpTotemDesert,WarpTotemFarm,WarpTotemIsland,WarpTotemMountains,WhiteAlgae,";
        string allHates = bait + fossils + monsterLoot+ trash + hates;
        AddSpecific(allHates, GiftType.Hates);

        //save failed stuff
        if (File.Exists(Application.dataPath + "/failedItems.json")) {
            File.Delete(Application.dataPath + "/failedItems.json");
        }
        string json = JsonUtility.ToJson(failedStr);
        File.WriteAllText(Application.dataPath + "/failedItems.json", json);
    }

    public void AddSpecific(string todos, GiftType tipo){
        //separa os itens
        string[] it = todos.Split(',');

        tipoStr.text = tipo.ToString();

        for (int i = 0; i < it.Length; i++)
        {
            if(it[i] != "")
                if(VerifyIfDifferent(it[i]))
                    AddUniversal(it[i]);//todo fazer ele pegar o tipo certo
        }
    }

    bool VerifyIfDifferent(string item){ //verifica se nao esta adicionando o mesmo item
        for (int u = 0; u < universals.Length; u++)
        {
            for (int i = 0; i < universals[u].items.Count; i++)
            {
                if(universals[u].items[i].ToString() == item)
                    return false; //igual
            }
        }

        return true; //diferente
    }

    private void Update() {
        //recarrega a cena
        if(Input.GetKeyDown(KeyCode.Space)) UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public static GiftType ParseGiftType(string s){
        GiftType parsed_enum = (GiftType)System.Enum.Parse( typeof(GiftType),s );
        return parsed_enum;
    }
    
    public static Items ParseItem(string s){
        Items parsed_enum = (Items)System.Enum.Parse( typeof(Items),s );
        return parsed_enum;
    }

    [System.Serializable]
    public class SerializableList<T> {
        public List<T> list;
    }

}
