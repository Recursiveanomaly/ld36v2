using UnityEngine;
using System.Collections.Generic;
using System;

public class Player : SingletonMonoBehaviour<Player>
{
    Dictionary<string, bool> m_knownPictographs = new Dictionary<string, bool>();

    Dictionary<string, List<string>> m_connectedWords = new Dictionary<string,List<string>>();

    [NonSerialized]
    public List<string> m_allWords = new List<string>()
    {
        "make"       ,
        "has"        ,
        "are"        ,
        "with"       ,
        "of"         ,
        "from"       ,
        "for"        ,
        "man"        ,
        "woman"      ,
        "no"         ,
        "in"         ,

        "love"       ,
        "make"       ,
        "name"       ,
        "child"      ,
        "kill"       ,
        "food"       ,
        "eat"        ,
        "gods"       ,
        "cruel"      ,
        "giants"     ,
        "trade"      ,
        "animal"     ,
        "money"      ,
        "steal"      ,
        "sword"      ,
        "fire"       ,

        "horse"      ,
        "travel"     ,
        "many"       ,
        "city"       ,
        "ship"       ,
        "water"      ,
        "exit"       ,
        "win"        ,
        "queen"      ,
        "king"       ,

        "tree"       ,
        "hurt"       ,
        "witch"      ,
        "guard"      ,
        "gold"       ,
        "hero"       ,
        "sleep"      ,
        "snake"      ,
        "ram"        ,

        //red herrings
        "goat"       ,
        "wheat"      ,
        "wine"       ,
        "spear"      ,
        "fish"       ,
        "net"        ,
        "priest"     ,
        "bull"       ,
        "cow"        ,
        "grapes"     ,
        "olive"      ,
        "oil"        ,
        "shield"     ,
        "key"        ,
        "helmet"     ,
        "speak"      ,
        "beer"       ,
        "glass"      ,
        "cloth"      ,
        "mother"     ,
        "father"     ,
        "brother"    ,
        "sister"     ,
        "dagger"     ,
        "weapon"     ,
        "mirror"     ,
        "yarn"       ,
    };

    int m_unlockCount = 0;

    protected virtual void Awake()
    {
        base.Awake();

        SetIsKnown("make", true);
        SetIsKnown("has", true);
        SetIsKnown("are", true);
        SetIsKnown("with", true);
        SetIsKnown("of", true);
        SetIsKnown("from", true);
        SetIsKnown("for", true);
        SetIsKnown("man", true);
        SetIsKnown("woman", true);
        SetIsKnown("no", true);
        SetIsKnown("in", true);
        m_unlockCount = 0; // don't count freebies


        m_connectedWords["love"] = new List<string>() { "marry", "like", "relish", "regard", "wed", "mate", "bond", "engage" };
        m_connectedWords["make"] = new List<string>() { "create", "form", "beget", "birth", "forge", "produce", "mold", "spawn", "parent" };
        m_connectedWords["name"] = new List<string>() { "call", "recognize", };
        m_connectedWords["child"] = new List<string>() { "children", "baby", "kid", "offspring", "babe", "porgeny", "newborn", "tyke", "kiddie", };
        m_connectedWords["kill"] = new List<string>() { "execture", "assassinate", "murder", "slay", "dispatch", "slaughter", "poison", "erase", "off", "waste", "wipe out", "massacre", "eliminate" };
        m_connectedWords["food"] = new List<string>() { "bread", "cooking", "fare", "feed", "meat", "meal", "eats", "fodder", "grub", "slop", "victual", "vittles", "foodstuff", "medicine", "potion", "herb" };
        m_connectedWords["eat"] = new List<string>() { "bite", "chew", "devour", "chow", "dine", "ingest", "swallow", "munch", "sup", "gorge" };
        m_connectedWords["gods"] = new List<string>() { "god", "creator", "deity", "divinity", "pantheon" };
        m_connectedWords["cruel"] = new List<string>() { "evil", "atrocious", "callouse", "ruthless", "harsh", "hearthless", "hateful", "sadistic", "spiteful", "vicious", "wicked", "uncaring" };
        m_connectedWords["giants"] = new List<string>() { "giant", "titan", "monster", "colossus", "goliath", "behemoth" };
        m_connectedWords["trade"] = new List<string>() { "business", "commerce", "deal", "exchange", "market", "sell", "buy", "dealing", "barter", "interchange", "sales", "merchant" };
        m_connectedWords["animal"] = new List<string>() { "mammal", "creature", "beast", };
        m_connectedWords["money"] = new List<string>() { "bill", "cash", "check", "payment", "wealth", "buck", "dough", "fund", };
        m_connectedWords["steal"] = new List<string>() { "take", "pilfer", "plunder", "swipe", "heist", "cheat", "pillage", "poach", "snitch", "thieve", "remove",  };
        m_connectedWords["sword"] = new List<string>() { "blade", "axe", "saber", "dagger", "sabre", "weapon", "arm", };
        m_connectedWords["fire"] = new List<string>() { "burn", "campfire", "hearth", "stove", "fireplace", "heat", "blaze", "char", "charring", "flame", "flare", "pyre", "spark" };

        m_connectedWords["horse"] = new List<string>() { "donkey", "ass", "mare", "filly", "colt", "gelding", "bronco", "nag", "pony", "steed", "stallion", };
        m_connectedWords["travel"] = new List<string>() { "move", "explore", "passage", "trip", "wander", "tour", "trek", "excursion", "ride", "sail", "sailing",  };
        m_connectedWords["many"] = new List<string>() { "much", "legion", "copious", "countless", "crowd", "crowded", "myriad", "rife", "plentiful", "several", "teeming", "varied", "various", "frequent", "abounding"};
        m_connectedWords["city"] = new List<string>() { "town", "civic", "castle", "fortress", "burghat", "state" };
        m_connectedWords["ship"] = new List<string>() { "boat", "barge", "canoe", "dinghy", "gondole", "yacht", "raft", "sailboat", "barge", "tub", };
        m_connectedWords["water"] = new List<string>() { "drink", "rain", "h2o", "aqua", "river", "ocean", "sea" };
        m_connectedWords["exit"] = new List<string>() { "leave", "door", "hole"};
        m_connectedWords["win"] = new List<string>() { "victory", "gain", "success", "triumph", "conquest" };
        m_connectedWords["queen"] = new List<string>() { "empress", };
        m_connectedWords["king"] = new List<string>() { "ruler", "monarch", "regent", "emperor", "majesty" };

        m_connectedWords["tree"] = new List<string>() { "forest", "sapling", "seedling", "timber" };
        m_connectedWords["hurt"] = new List<string>() { "die", "injury", "injure", "stab", "cripple", "break", "deform", "impair", "mangle", "ruin"};
        m_connectedWords["witch"] = new List<string>() { "magician", "enchanter", "mage", "sorcerer", "conjurer", "witche", "priest", "priestess" };
        m_connectedWords["guard"] = new List<string>() { "protect", "save", "resue", "defend", "defender", "ward", "warden", "escort", "shield" };
        m_connectedWords["gold"] = new List<string>() { "coin", };
        m_connectedWords["hero"] = new List<string>() { "champion", };
        m_connectedWords["sleep"] = new List<string>() { "coma", "dream", "nap", "slumber", "trance", "doze", "rest" };
        m_connectedWords["snake"] = new List<string>() { "dragon", };
        m_connectedWords["ram"] = new List<string>() { "sheep", "fleece", };


    }

    public int UnlockCount()
    {
        return m_unlockCount;
    }

    public bool IsKnown(string pictograph)
    {
        pictograph = SanitizeString(pictograph);

        return !string.IsNullOrEmpty(pictograph) && m_knownPictographs.ContainsKey(pictograph) && m_knownPictographs[pictograph];
    }

    public void SetIsKnown(string pictograph, bool isKnown)
    {
        pictograph = SanitizeString(pictograph);

        if (string.IsNullOrEmpty(pictograph)) return;

        m_knownPictographs[pictograph] = isKnown;
        if (isKnown) m_unlockCount++;

        if (KnownPictographsChanged != null) KnownPictographsChanged();
    }

    public static string SanitizeString(string pictograph)
    {
        pictograph = pictograph.Trim().ToLower();
        if (pictograph.EndsWith("s"))
        {
            pictograph = pictograph.Remove(pictograph.Length - 1, 1);
        }

        bool foundVariant = false;
        foreach (var keyValuePair in Player.Instance.m_connectedWords)
        {
            foreach (var variant in keyValuePair.Value)
            {
                if (pictograph.Equals(variant))
                {
                    pictograph = keyValuePair.Key;
                    foundVariant = true;
                    break;
                }
            }
            if (foundVariant) break;
        }

        // special case
        if (pictograph.Equals("god")) pictograph = "gods";

        // special case
        if (pictograph.Equals("giant")) pictograph = "giants";

        // special case
        if (pictograph.Equals("men")) pictograph = "man";

        // special case
        if (pictograph.Equals("women")) pictograph = "woman";

        if (pictograph.Equals("titan")) pictograph = "woman";

        return pictograph;
    }

    public event Action KnownPictographsChanged;
}
