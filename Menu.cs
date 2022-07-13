namespace LetsSpeak
{
    enum MenuType
    {
        COMMAND,
        SUBMENU
    }
    internal class Menu
    {
        public string Title;
        public Action action;
        public Menu parent;
        public List<Menu> menuList;
        public MenuType type;
        public int selectedIndex;


        public Menu(string title)
        {
            menuList = new List<Menu>();
            this.Title = title;
            this.type = MenuType.SUBMENU;
        }

        public Menu (string title, Action action) : this (title)
        {
            this.action = action;
            this.type = MenuType.COMMAND;
        }
        public void Add(Menu menu)
        {
            menu.parent = this;
            menuList.Add(menu);
        }
    }
}
