using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : Singleton<MenuManager>
{
    public MenuClassifier LoadingScreen;

    private Dictionary<string, Menu> MenuList = new Dictionary<string, Menu>();

    public T GetMenu<T>(MenuClassifier menuClassifier) where T : Menu
    {
        Menu menu;
        if (MenuList.TryGetValue(menuClassifier.name, out menu))
        {
            return (T)menu;
        }
        return null;
    }

    public void AddMenu(Menu menu)
    {
        if (MenuList.ContainsKey(menu.menuClassifier.name))
        {
            Debug.Assert(false, $"Menu is already registered {menu.name}");
        }
        MenuList.Add(menu.menuClassifier.name, menu);
    }

    public void RemoveMenu(Menu menu)
    {
        MenuList.Remove(menu.menuClassifier.name);
    }

    public void ShowMenu(MenuClassifier menuClassifier)
    {
        Menu menu;
        if (MenuList.TryGetValue(menuClassifier.name, out menu))
        {
            menu.OnShowMenu();
        }
    }

    public void HideMenu(MenuClassifier menuClassifier)
    {
        Menu menu;
        if (MenuList.TryGetValue(menuClassifier.name, out menu))
        {
            menu.OnHideMenu();
        }
    }
}
