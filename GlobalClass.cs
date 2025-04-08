namespace gradtest {
    public static class GlobalClass
    {
        public static Dictionary<string, byte> map = new Dictionary<string, byte>{
            { "about" , 0},
            { "damage" , 1},
            { "benefitsofquitting" , 2},
            { "howtoquitsmoking" , 3},
            { "stories" , 4},
        };
        public static Dictionary<byte, string> pam = new Dictionary<byte, string>{
            { 0,"about"},
            { 1,"damage" },
            { 2,"benefitsofquitting"},
            { 3,"howtoquitsmoking" },
            { 4,"stories" }
        };
        public static int checkerType(string type)
        {
            if (type != "videos" && type != "blogs") return -1;
            return (type == "videos" ? 0 : 1);
        }
        public static int checkerCategory(string category)
        {
            if(map.ContainsKey(category)) return map[category];
            return -1;
        }
    }
}
