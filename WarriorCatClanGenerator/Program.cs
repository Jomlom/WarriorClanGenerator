using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorCatClanGenerator {
    internal class Program {

        private static Random r = new Random();

        static void Main(string[] args) {
            while (true) { NewClanMenu(); }
        }
        static void NewClanMenu() {
            Console.WriteLine("Press any key to generate new clan");
            Console.ReadKey();
            Console.WriteLine();
            NewClan();
        }
        static void NewClan() {
            Clan clan = new Clan();
            CreateClanName(ref clan);
            GenerateCats(ref clan);
            PrintClan(clan);
            //EditClan(ref clan);
        }
        static void CreateClanName(ref Clan clan) {
            clan.clanName = clanNames[r.Next(0, clanNames.Length)] + "clan";
        }
        static void GenerateCats(ref Clan clan) {
            clan.leader = RandomCat();
            clan.leader.name = RollName("star");
            clan.deputy = RandomCat();
            clan.medicineCat = RandomCat();
            for (int i = 0; i < clan.medicineApprentices.Length; i++) {
                clan.medicineApprentices[i] = RandomCat();
                clan.medicineApprentices[i].name = RollName("paw");
            }
            for (int i = 0; i < clan.warriors.Length; i++) {
                clan.warriors[i] = RandomCat();
            }
            for (int i = 0; i < clan.apprentices.Length; i++) {
                clan.apprentices[i] = RandomCat();
                clan.apprentices[i].name = RollName("paw");
            }
            for (int i = 0; i < clan.queens.Length; i++) {
                clan.queens[i] = RandomCat();
                clan.queens[i].gender = "she-cat";
            }
            for (int i = 0; i < clan.kits.Length; i++) {
                clan.kits[i] = RandomCat();
                clan.kits[i].name = RollName("paw");
                clan.kits[i].trait = null;
                clan.kits[i].quirk = null;
            }
            for (int i = 0; i < clan.elders.Length; i++) {
                clan.elders[i] = RandomCat();
            }
        }
        static Cat RandomCat() {
            Cat cat = new Cat();
            cat.name = RollName();
            cat.trait = RollTrait();
            cat.appearance = RollAppearance();
            cat.gender = RollGender();
            cat.fur = RollFur();
            cat.eyeColour = RollEyeColour();
            cat.quirk = RollQuirk();
            return cat;
        }
        static void PrintClan(Clan clan) {
            Console.Clear();
            Console.Write($"{clan.clanName}:\n\n");
            Console.Write($"Leader:\n");
            PrintCat(clan.leader);
            Console.Write($"\n\nDeputy:\n");
            PrintCat(clan.deputy);
            Console.Write($"\n\nMedicine Cat:\n");
            PrintCat(clan.medicineCat);
            if (clan.medicineApprentices.Length > 0) {
                Console.Write($"\n\nMedicine Cat Apprentice:\n");
                PrintCat(clan.medicineApprentices[0]);
            }
            if (clan.warriors.Length > 0) {
                Console.Write($"\n\nWarriors:\n");
                for (int i = 0; i < clan.warriors.Length; i++) {
                    PrintCat(clan.warriors[i]);
                    Console.Write("\n");
                }
            }
            if (clan.apprentices.Length > 0) {
                Console.Write($"\nApprentices:\n");
                for (int i = 0; i < clan.apprentices.Length; i++) {
                    PrintCat(clan.apprentices[i]);
                    Console.Write("\n");
                }
            }
            if (clan.queens.Length > 0) {
                Console.Write($"\nQueens:\n");
                for (int i = 0; i < clan.queens.Length; i++) {
                    PrintCat(clan.queens[i]);
                    Console.Write("\n");
                }
            }
            if (clan.kits.Length > 0) {
                Console.Write($"\nKits:\n");
                for (int i = 0; i < clan.kits.Length; i++) {
                    PrintCat(clan.kits[i]);
                    Console.Write("\n");
                }
            }
            if (clan.elders.Length > 0) {
                Console.Write($"\nElders:\n");
                for (int i = 0; i < clan.elders.Length; i++) {
                    PrintCat(clan.elders[i]);
                    Console.Write("\n");
                }
            }
            Console.Write("\n\n");
        }
        static void PrintCat(Cat cat) {
            Console.Write($"{cat.name} -");
            if (cat.trait != null) {
                if (cat.trait[0] == 'a' || cat.trait[0] == 'e' || cat.trait[0] == 'i' || cat.trait[0] == 'o' || cat.trait[0] == 'u') {
                    Console.Write($" an {cat.trait}");
                }
                else {
                    Console.Write($" a {cat.trait}");
                }
            }
            else {
                if (cat.appearance[0] == 'a' || cat.appearance[0] == 'e' || cat.appearance[0] == 'i' || cat.appearance[0] == 'o' || cat.appearance[0] == 'u') {
                    Console.Write($" an");
                }
                else {
                    Console.Write($" a");
                }
            }
            Console.Write($" {cat.appearance}");
            Console.Write($" {cat.gender}");
            Console.Write($" with {cat.fur} fur");
            if (cat.quirk != null) {
                Console.Write($", {cat.quirk}");
            }
            Console.Write($" and {cat.eyeColour} eyes");
        }
        //static void EditClan(ref string[] clan) {

        //}

        static string RollName() {
            return firstHalfNames[r.Next(0, firstHalfNames.Length)] + secondHalfNames[r.Next(0, secondHalfNames.Length)];
        }
        static string RollName(string secondHalf) {
            return firstHalfNames[r.Next(0, firstHalfNames.Length)] + secondHalf;
        }
        static string RollTrait() {
            return traits[r.Next(0, traits.Length)];
        }
        static string RollAppearance() {
            int chance = r.Next(1, 101);
            if (chance <= 20) {
                return rarePatterns[r.Next(0, rareFurs.Length)];
            }
            else {
                chance = r.Next(1, 101);
                if (chance <= 50) {
                    return colours[r.Next(0, colours.Length)];
                }
                else {
                    return colours[r.Next(0, colours.Length)] + " " + patterns[r.Next(0, patterns.Length)];
                }
            }
        }
        static string RollGender() {
            if (r.Next(0, 2) == 0) {
                return "tom";
            }
            else {
                return "she-cat";
            }
        }
        static string RollFur() {
            int chance = r.Next(1, 101);
            if (chance <= 30) {
                return rareFurs[r.Next(0, rareFurs.Length)];
            }
            else {
                return furs[r.Next(0, furs.Length)];
            }
        }
        static string RollQuirk() {
            int chance = r.Next(1, 101);
            if (chance <= 15) {
                return quirks[r.Next(0, quirks.Length)];
            }
            else {
                return null;
            }
        }
        static string RollEyeColour() {
            int chance = r.Next(1, 101);
            if (chance <= 5) {
                string firstEyeColour = specialEyeColours[r.Next(0, specialEyeColours.Length)];
                string secondEyeColour;
                do {
                    secondEyeColour = specialEyeColours[r.Next(0, specialEyeColours.Length)];
                } while (secondEyeColour == firstEyeColour);
                return firstEyeColour + "/" + secondEyeColour + " " + specialEyeTypes[r.Next(0, specialEyeTypes.Length)]; ;
            }
            else {
                return eyeColours[r.Next(0, eyeColours.Length)];
            }
        }

        class Clan {

            public string clanName;
            public Cat leader;
            public Cat deputy;
            public Cat medicineCat;
            public Cat[] medicineApprentices;
            public Cat[] warriors;
            public Cat[] apprentices;
            public Cat[] queens;
            public Cat[] kits;
            public Cat[] elders;

            public Clan() {
                leader = new Cat();
                deputy = new Cat();
                medicineCat = new Cat();
                medicineApprentices = new Cat[r.Next(0, 2)];
                warriors = new Cat[r.Next(9, 14)];
                apprentices = new Cat[r.Next(1, 5)];
                queens = new Cat[r.Next(1, 4)];
                kits = new Cat[r.Next(0, (queens.Length * 2) + 1)];
                elders = new Cat[r.Next(0, 4)];
            }
        }
        class Cat {
            public string name;
            public string trait;
            public string appearance;
            public string gender;
            public string fur;
            public string eyeColour;
            public string quirk;
        }

        private static string[] clanNames = new string[] {
        "Dark",
        "Fog",
        "Light",
        "Snow",
        "Bush",
        "Moss",
        "Tree",
        "Swift",
        "Willow",
        "Forest",
        "Mountain",
        "Lake",
        "Blaze",
        "Breeze",
        "Bright",
        "Clear",
        "Dawn",
        "Drizzle",
        "Ice",
        "Fade",
        "Glow",
        "Rise",
        "Shine",
        "Torrent",
        "Current",
        "Berry",
        "Ash",
        "Bone",
        "Bleak",
        "Dark",
        "Dusk",
        "Fallen",
        "Mist",
        "Moon",
        "Night",
        "Sharp",
        "Slash",
        "Dead",
        "Smoke",
        "Vine",
        "Tree",
        "Cold",
        "Earth",
        "Fire",
        "Fog",
        "Freeze",
        "Frozen",
        "Marsh",
        "Rain",
        "Rock",
        "Slush",
        "Storm",
        "Hollow",
        "Echo",
        "Hidden",
        "Stray",
        "Thorn",
        "Blizzard",
        "Mud",
        "Swamp",
        "Dusk",
        "Shade",
        "Sun",
        "Meadow",
        "Stream",
        "Tundra",
        "Taiga",
        "Lava",
        "Volcano",
        "Barren",
        "Farm",
        "Cliff",
        "Sand",
        "Moor",
        "Field",
        "Shore",
        "Cove",
        "Waste",
        "Cave",
        "Snow",
        "Ridge",
        "Flood",
        "Bog",
        "Bush"
        };
        private static string[] firstHalfNames = new string[] {
        "Mint",
        "Beetroot",
        "Pea",
        "Sprout",
        "Onion",
        "Celery",
        "Pumpkin",
        "Melon",
        "Lemon",
        "Lime",
        "Apricot",
        "Quince",
        "Teasel",
        "Brindle",
        "Ant",
        "Beech",
        "Dark",
        "Smooth",
        "Speckle",
        "Muddle",
        "Forest",
        "Mushroom",
        "Fungi",
        "Laurel",
        "Murk",
        "Wax",
        "Russet",
        "Jagged",
        "Hazel",
        "Deep",
        "Big",
        "Swift",
        "Raven",
        "Bee",
        "Moss",
        "Fox",
        "Mouse",
        "Acorn",
        "Fire",
        "Flame",
        "Clear",
        "Glow",
        "Fallen",
        "Murky",
        "Ash",
        "Soot",
        "Rain",
        "Snow",
        "Marsh",
        "Nettle",
        "Sap",
        "Fern",
        "Berry",
        "Hazel",
        "Orchid",
        "Mallow",
        "Fog",
        "Twig",
        "Heather",
        "Chesnut",
        "Rose",
        "Wolf",
        "Robin",
        "Jay",
        "Thrush",
        "Ivy",
        "Feather",
        "Bear",
        "Cotton",
        "Adder",
        "Skull",
        "Bone",
        "Ant",
        "Apple",
        "Peach",
        "Ice",
        "Badger",
        "Squirrel",
        "Spider",
        "Dust",
        "Daisy",
        "Beetle",
        "Shell",
        "Blaze",
        "Little",
        "Log",
        "Bounce",
        "Bracken",
        "Briar",
        "Bubble",
        "Bush",
        "Icicle",
        "Shade",
        "Sharp",
        "Nut",
        "Wasp",
        "Stag",
        "Dream",
        "Sweet",
        "Deer",
        "Cow",
        "Milk",
        "Puddle",
        "Lost",
        "Whisper",
        "Flutter",
        "Venom",
        "Poison",
        "Frog",
        "Thicket",
        "Pale",
        "Storm",
        "Lion",
        "Tiger",
        "Leopard",
        "Puma",
        "Jaguar",
        "Panther",
        "Vole",
        "Pidgeon",
        "Sparrow",
        "Starling",
        "Finch",
        "Dog",
        "Magpie",
        "Dove",
        "Wren",
        "Crow",
        "Duck",
        "Goose",
        "Swan",
        "Pollen",
        "Petal",
        "Snake",
        "Worm",
        "Beetle",
        "Otter",
        "Hedgehog",
        "Moth",
        "Beaver",
        "Vole",
        "Eagle",
        "Hawk",
        "Buzzard",
        "Hornet",
        "Seed",
        "Sprig",
        "Sun",
        "Moon",
        "Mud",
        "Rabbit",
        "Cub",
        "Owl",
        "Cold",
        "Frozen",
        "Trout",
        "Carp",
        "Pike",
        "Snail",
        "Slug",
        "Cricket",
        "Fly",
        "Bat",
        "Fern",
        "Thistle",
        "Withered",
        "Cinder",
        "Spark",
        "Hollow",
        "Torn",
        "Quail",
        "Buck",
        "Rowan",
        "Cherry",
        "Plum",
        "Honey",
        "Holly",
        "Spindle",
        "Murky",
        "Web",
        "Garlic",
        "Thyme",
        "Mint",
        "Juniper",
        "Yarrow",
        "Tansy",
        "Comfrey",
        "Sorrel",
        "Alder",
        "Birch",
        "Root",
        "Mugwort",
        "Hare",
        "Hen",
        "Egg",
        "Grass",
        "Talon",
        "Pig",
        "Meadow",
        "Cress",
        "Rock",
        "Pebble",
        "Carrot",
        "Cabbage",
        "Wild",
        "Walnut",
        "Lettuce",
        "Sleek",
        "Grape",
        "Mallow",
        "Weed",
        "Primrose",
        "Hyacinth",
        "Skunk",
        "Peony",
        "Daffodil",
        "Lavender",
        "Flax",
        "Pine",
        "Fir",
        "Raddish",
        "Sheep",
        "Stone",
        "Yew",
        "Lime",
        "Clover",
        "Gorse",
        "Reed",
        "Bug",
        "Bog",
        "Heavy",
        "Boggy",
        "Chalk",
        "Chaffinch",
        "Chiffchaff",
        "Coal",
        "Cuckoo",
        "Dunnock",
        "Kestrel",
        "Long",
        "Tall",
        "Mistle",
        "Thrush",
        "Nightingale",
        "Osprey",
        "Kite",
        "Robin",
        "Rook",
        "Starling",
        "Swallow",
        "Tawny",
        "Tree",
        "Twig",
        "Wheat",
        "Wren",
        "Shrub",
        "Jackdaw",
        "Pheasant",
        "Ladybug",
        "Bumble",
        "Cinnamon",
        "Clear",
        "Cloud",
        "Dapple",
        "Dead",
        "Doe",
        "Dew",
        "Drizzle",
        "Echo",
        "Elder",
        "Wisp",
        "Fawn",
        "Ferret",
        "Fin",
        "Flash",
        "Freckle",
        "Hail",
        "Hill",
        "Hound",
        "Jump",
        "Scratch",
        "Lake",
        "Leaf",
        "Lightning",
        "Long",
        "Small",
        "Lynx",
        "Loud",
        "Silent",
        "Minnow",
        "Maple",
        "Misty",
        "Mumble",
        "Nectar",
        "Newt",
        "Tadpole",
        "Odd",
        "Night",
        "Oat",
        "One",
        "Patch",
        "Pear",
        "Olive",
        "Pod",
        "Pounce",
        "Prickle",
        "Hay",
        "Quick",
        "Rat",
        "Rook",
        "Ripple",
        "Rush",
        "Rye",
        "Sand",
        "Sandy",
        "Scorch",
        "Shadow",
        "Thunder",
        "Wind",
        "River",
        "Shattered",
        "Shrew",
        "Slate",
        "Slight",
        "Shy",
        "Snap",
        "Spike",
        "Stream",
        "Sunny",
        "Swamp",
        "Tangle",
        "Tiny",
        "Toad",
        "Turtle",
        "Vixen",
        "Weasel",
        "Whistle",
        "Eel",
        "Heavy",
        "Horse",
        "Lizard",
        "Adder",
        "Mink",
        "Shrew",
        "Sneeze",
        "Fidget",
        "Hop",
        "Mottle",
        "Sage",
        "Chickadee",
        "Bluebell",
        "Aster",
        "Iris"
        };
        private static string[] secondHalfNames = new string[] {
        "bite",
        "burst",
        "spot",
        "beam",
        "bright",
        "sight",
        "trail",
        "freckle",
        "rush",
        "veil",
        "drift",
        "scales",
        "wing",
        "flight",
        "flake",
        "back",
        "tail",
        "claw",
        "lake",
        "heart",
        "belly",
        "face",
        "nose",
        "ear",
        "leg",
        "stripe",
        "pool",
        "wing",
        "song",
        "sting",
        "whisker",
        "gaze",
        "leaf",
        "shine",
        "flower",
        "breeze",
        "jump",
        "hop",
        "skip",
        "snap",
        "strike",
        "foot",
        "bite",
        "fang",
        "watcher",
        "catcher",
        "snarl",
        "spirit",
        "sight",
        "fall",
        "whisper",
        "whisker",
        "stalk",
        "stream",
        "puddle",
        "snow",
        "cloud",
        "meadow",
        "dusk",
        "pelt",
        "fur",
        "flight",
        "storm",
        "feather",
        "dawn",
        "shade",
        "nibble",
        "bark",
        "bee",
        "berry",
        "blaze",
        "bloom",
        "branch",
        "bright",
        "burrow",
        "bush",
        "crawl",
        "dapple",
        "eye",
        "eyes",
        "patch",
        "fern",
        "fall",
        "fang",
        "fire",
        "spark",
        "frost",
        "flower",
        "hawk",
        "ice",
        "jaw",
        "mask",
        "muzzle",
        "mouse",
        "moon",
        "pad",
        "mouse",
        "petal",
        "puddle",
        "rose",
        "ripple",
        "scratch",
        "runner",
        "fever",
        "shade",
        "shell",
        "seed",
        "sky",
        "snout",
        "speck",
        "splash",
        "stem",
        "stream",
        "strike",
        "teeth",
        "tuft",
        "whistle",
        "wing",
        "wish",
        "willow",
        "raven",
        "roar",
        "screech",
        "drop",
        "dust",
        "bush",
        "toe",
        "thorn",
        "weed",
        "water",
        "wind",
        "snow",
        "dream",
        "feather",
        "blossom",
        "throat",
        "cry",
        "dash",
        "dove",
        "freckle",
        "wish",
        "fox",
        "fly",
        "raven",
        "scorch",
        "flake",
        "fin",
        "flutter",
        "frost",
        "flash",
        "glare",
        "growl",
        "hiss",
        "glint",
        "gust",
        "haze",
        "hollow",
        "honey",
        "mud",
        "lark",
        "legs",
        "lick",
        "moon",
        "nut",
        "orchid",
        "path",
        "run",
        "runner",
        "shadow",
        "skull",
        "slash",
        "sneeze",
        "spark",
        "sprig",
        "stare",
        "stride",
        "sun",
        "tangle",
        "tear",
        "thorn",
        "thistle",
        "thicket",
        "tooth",
        "trail",
        "twist",
        "tusk",
        "tongue",
        "iris",
        "crunch",
        "valley",
        "web",
        "worm",
        "wisp",
        "whisper",
        "yowl",
        "pounce",
        "rain",
        "hound",
        "quiver",
        "shatter",
        "briar",
        "grin",
        "seeker",
        "fig",
        "bud",
        "fluff",
        "grass",
        "run",
        "chest",
        "nettle",
        "mane",
        "lily",
        "zip",
        "burst",
        "flare",
        "light",
        "crouch",
        "chirp",
        "stomp",
        "flick",
        "flow"
        };
        private static string[] traits = new string[] {
        "persistant",
        "strange",
        "secretive",
        "bold",
        "abnormally large",
        "charasmatic",
        "stubborn",
        "creative",
        "empathetic",
        "friendly",
        "elegant",
        "compassionate",
        "humble",
        "enthusiatic",
        "ambitious",
        "intoverted",
        "adventurous",
        "admirable",
        "calm",
        "confident",
        "daring",
        "dignified",
        "dramatic",
        "energetic",
        "fair",
        "gentle",
        "kind",
        "aggresive",
        "rude",
        "protective",
        "selfless",
        "witty",
        "reserved",
        "aloof",
        "antisocial",
        "blunt",
        "brutal",
        "cowardly",
        "cruel",
        "disloyal",
        "dishonest",
        "dull",
        "fickle",
        "fiery",
        "gloomy",
        "gullible",
        "hostile",
        "ignorant",
        "hesitant",
        "insecure",
        "irritable",
        "malicious",
        "miserable",
        "odd",
        "paranoid",
        "petty",
        "silly",
        "timid",
        "weak",
        "honest",
        "lithe",
        "nimble",
        "scrawny",
        "mysterious",
        "fierce",
        "cunning",
        "alert",
        "anxious",
        "moody",
        "naughty",
        "needy",
        "likable",
        "affectionate",
        "amusing",
        "bossy",
        "caring",
        "chill",
        "pampered",
        "chubby",
        "clumsy",
        "courageous",
        "picky",
        "playful",
        "crafty",
        "protective",
        "pretty",
        "curious",
        "crazy",
        "quiet",
        "quirky",
        "devoted",
        "demanding",
        "daring",
        "rebellious",
        "entertaining",
        "faithful",
        "relaxed",
        "sensitive",
        "foolish",
        "sleepy",
        "smart",
        "fun",
        "graceful",
        "stubborn",
        "greedy",
        "handsome",
        "sweet",
        "tempermental",
        "timid",
        "tough",
        "jolly",
        "intelligent",
        "lazy",
        "laidback",
        "keen",
        "unique",
        "small",
        "tall",
        "broad-shouldered",
        "thin",
        "tiny",
        "lean",
        "muscly",
        "round",
        "well-built",
        "skinny",
        "lanky",
        "stocky"
        };
        private static string[] colours = new string[] {
        "yellow",
        "fawn",
        "lilac",
        "cinnamon",
        "chocolate",
        "black",
        "dark grey",
        "orange",
        "red",
        "silver",
        "blue",
        "light brown",
        "brown",
        "cream",
        "dark blue",
        "warm blue",
        "light grey",
        "grey",
        "dark brown",
        "dark red",
        "ginger",
        "gold",
        "apricot",
        "dark ginger"
        };
        private static string[] patterns = new string[] {
        "dappled",
        "speckled",
        "spotted tabby",
        "marbled tabby",
        "mackeral tabby",
        "classic tabby",
        "mackeral tabby",
        "classic tabby",
        "sokoke tabby",
        "oceloid tabby",
        "ticked tabby",
        "rosetted tabby"
        };
        private static string[] rarePatterns = new string[] {
        "seal lynx-point",
        "chocolate lynx-point",
        "cinnamon lynx-point",
        "flame lynx-point",
        "blue lynx-point",
        "lilac lynx-point",
        "fawn lynx-point",
        "cream lynx-point",
        "seal colour-point",
        "chocolate colour-point",
        "cinnamon colour-point",
        "flame colour-point",
        "blue colour-point",
        "lilac colour-point",
        "fawn colour-point",
        "cream colour-point",
        "white",
        "black and tan underbelly",
        "brown and tan underbelly",
        "black and white swirled",
        "brown and white swirled",
        "black and white brindled bicolour",
        "black and white skunk stripe",
        "cream, red and brown calico",
        "cream, orange and black calico",
        "cream, orange and brown calico",
        "cream, black and brown calico",
        "cream, blue and silver calico",
        "black smoke,",
        "brown smoke",
        "white shaded",
        "golden shaded",
        "grey shaded",
        "black and white vitilago",
        "white",
        "white, red and brown calico",
        "white, orange and black calico",
        "white, orange and brown calico",
        "white, orange and cream calico",
        "white, grey and cream calico",
        "white, cream and brown calico",
        "white, black and brown calico",
        "white, silver and grey calico",
        "white, blue and silver calico",
        "red and brown tortie",
        "orange and black tortie",
        "orange and brown tortie",
        "orange and cream tortie",
        "grey and cream tortie",
        "cream and brown tortie",
        "black and red tortie",
        "silver and dark grey tortie",
        "blue and silver tortie",
        "cream, red and brown caliby",
        "cream, orange and black caliby",
        "cream, orange and brown caliby",
        "cream, black and brown caliby",
        "cream, blue and silver caliby",
        "white",
        "white, red and brown caliby",
        "white, orange and black caliby",
        "white, orange and brown caliby",
        "white, orange and cream caliby",
        "white, grey and cream caliby",
        "white, cream and brown caliby",
        "white, black and brown caliby",
        "white, silver and grey caliby",
        "white, blue and silver caliby",
        "red and brown tortorbie",
        "orange and black torbie",
        "orange and brown torbie",
        "orange and cream torbie",
        "grey and cream torbie",
        "cream and brown torbie",
        "black and red torbie",
        "silver and dark grey torbie",
        "blue and silver torbie"
        };
        private static string[] furs = new string[] {
            "short",
            "medium-length",
            "long"
        };
        private static string[] rareFurs = new string[] {
        "wavy",
        "shiny",
        "fluffy",
        "slick",
        "very short",
        "very long",
        "course",
        "silky",
        "thick",
        "unkept",
        "sleek",
        "tidy",
        "wild",
        "spiky",
        "thin",
        "scruffy",
        "soft",
        "curly",
        "glossy"
        };
        private static string[] quirks = new string[] {
        "a special connection to starclan",
        "webbed paws",
        "a whip-like tail",
        "a short muzzle",
        "scarred muzzle",
        "small paws",
        "an angular face",
        "a short tail",
        "dark eyebags",
        "long eyelashes",
        "droopy ears",
        "a square face",
        "scarred pelt",
        "scarred legs",
        "darker paws",
        "darker chest flecks",
        "a round face",
        "cheek fluff",
        "ear tufts",
        "a tufted tail",
        "rounded ears",
        "darker tipped ears",
        "curled ears",
        "a bobtail",
        "a curly tail",
        "polydactyl mutation",
        "shredded ears",
        "a nose scar",
        "a back leg scar",
        "a shoulder scar",
        "an eye scar",
        "a lip scar",
        "a long scar",
        "a scar shaped like an X",
        "scars from being struck by lightning",
        "long legs",
        "a scarred tail",
        "darker paws",
        "darker flecks",
        "a darker face",
        "a speckled nose",
        "a blind eye",
        "bad vision",
        "lots of scars",
        "a pink nose",
        "a twisted limb",
        "a back scar",
        "a nose scar",
        "wild neck fur",
        "slashed eyes",
        "ear fluff",
        "a few scars",
        "a missing eye",
        "a torn ear",
        "five toes on one foot",
        "a snaggle tooth",
        "large fangs",
        "small fangs",
        "a missing limb",
        "a broken tail",
        "a flat face",
        "folded ears",
        "a freakishly large tail",
        "a folded ear",
        "small ears",
        "tall ears",
        "crooked whiskers",
        "a scarred face",
        "a long tail",
        "long whiskers",
        "short legs",
        "a fluffy tail",
        "large paws",
        "dangerous claws",
        "a scarred throat",
        "burn scars",
        "a torn ear",
        "a bullet hole in one ear",
        "back scars",
        "a dark back stripe"
        };
        private static string[] eyeColours = new string[] {
        "blue",
        "icy-blue",
        "emerald-green",
        "ruby-red",
        "olive-green",
        "brown",
        "bright blue",
        "bright green",
        "green",
        "pale yellow",
        "yellow",
        "amber",
        "orange",
        "hazel",
        "copper",
        "red",
        "turquoise",
        "gold",
        "bronze",
        "pale blue",
        "gold",
        "pale green",
        "purple-blue",
        "silver"
        };
        private static string[] specialEyeColours = new string[] {
            "red",
            "blue",
            "green",
            "orange",
            "yellow"
        };
        private static string[] specialEyeTypes = new string[] {
            "dichromid",
            "heterochromia"
        };
    }
}