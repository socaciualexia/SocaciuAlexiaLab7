using System;
using SocaciuAlexiaLab7;
using System.IO;
using SocaciuAlexiaLab7.Data;

namespace SocaciuAlexiaLab7
{
    public partial class App : Application
    {
        static ShoppingListDatabase database;

        internal static ShoppingListDatabase Database
        {
            get
            {
                if(database == null)
                {
                    database = new ShoppingListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ShoppingList.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
