namespace LetsSpeak
{
    internal class Dictionary
    {
        private static readonly string fileName = "Dictionary.json";
        private Dictionary<string, string> words = new Dictionary<string, string>();

        public bool Add(string name, string definition)
        {
            if (!words.ContainsKey(name))
            {
                words.Add(name, definition);
                return true;
            }
            return false;
        }
        public bool Remove(string name)
        {
            if (words.ContainsKey(name))
            {
                words.Remove(name);
                return true;
            }

            return false;
        }
        public Dictionary<string, string> GetWordList()
        {
            return words;
        }
        public void Save()
        {
            var serializer = new Serializer();
            serializer.SaveFile(fileName, words);
        }

        public void Load()
        {
            var serializer = new Serializer();
            words = serializer.LoadFile(fileName);
        }
    }
}
