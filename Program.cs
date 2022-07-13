namespace LetsSpeak
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary();
            dictionary.Load();

            var dictionaryHandler = new DictionaryHandler(dictionary);
            var menuHandler = new MenuHandler();
            var menu = menuHandler.CreateMenu(dictionaryHandler);
            menuHandler.RunMenu(menu);

        }
    }
}