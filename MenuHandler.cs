using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsSpeak
{
    internal class MenuHandler
    {

        public Menu CreateMenu(DictionaryHandler dictionaryHandler)
        { 
            var mainMenu = new Menu("Dictionary");

            var editMenu = new Menu("Edit Dictionary");
            editMenu.Add(new Menu("Add Word", dictionaryHandler.AddWord));
            editMenu.Add(new Menu("Remove Word", dictionaryHandler.RemoveWord));

            mainMenu.Add(new Menu("Search Words", dictionaryHandler.SearchWords));
            mainMenu.Add(editMenu);
            mainMenu.Add(new Menu("Exit", dictionaryHandler.ExitSystem));

            return mainMenu;
        }

        public void RunMenu(Menu menu)
        {
            if (menu.type == MenuType.SUBMENU)
            {
                if (menu.menuList.Count == 0) return;

                ConsoleKeyInfo key;

                while (true)
                {
                    ShowMenu(menu);
                    key = Console.ReadKey();

                    if (HandleKey(menu, key.Key))
                        break;
                }
            }
            else if (menu.type == MenuType.COMMAND)
            {
                menu.action();
                RunMenu(menu.parent);
            }
        }

        public bool HandleKey(Menu menu, ConsoleKey key)
        {
            if (key == ConsoleKey.UpArrow)
                menu.selectedIndex = Math.Max(menu.selectedIndex - 1, 0);
            if (key == ConsoleKey.DownArrow)
                menu.selectedIndex = Math.Min(menu.selectedIndex + 1, Math.Max(menu.menuList.Count - 1, 0));
            else if (key == ConsoleKey.Enter)
            {
                RunMenu(menu.menuList[menu.selectedIndex]);
                return true;
            }
            else if (key == ConsoleKey.Escape && menu.parent != null)
            {
                RunMenu(menu.parent);
                return true;
            }

            return false;
        }
        public void ShowMenu(Menu menu)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ResetColor();

            for (int i = 0; i < menu.menuList.Count; i++)
            {
                Console.ResetColor();

                if (i == menu.selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }

                Console.WriteLine(menu.menuList[i].Title);
            }
        }
    }
}
