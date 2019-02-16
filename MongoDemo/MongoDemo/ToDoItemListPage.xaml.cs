using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace MongoDemo
{
    public partial class ChantierListPage : ContentPage
    {
        public ObservableCollection<Chantier> ToDoItems { get; set; }

        public ChantierListPage()
        {
            InitializeComponent();

            ToDoItems = new ObservableCollection<Chantier>();

            todoList.ItemsSource = ToDoItems;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var allItems = await MongoService.GetAllChantiers();

            //var allItems = await MongoService.SearchByName("first");

            foreach (var item in allItems)
            {
                if (!ToDoItems.Any((arg) => arg.Id == item.Id))
                    ToDoItems.Add(item);
            }

            if (allItems.Count == 0)
            {
                var newItem = new Chantier { Location = "Antony", ReferenceChantier = "RF20190215", Owner = "Mohamed", BeginDate = "15/02/2019" };
                await MongoService.InsertChantier(newItem);

                ToDoItems.Add(newItem);
            }
        }

        protected async void Add_Clicked(object sender, EventArgs eventArgs)
        {
            var detailPage = new NavigationPage(new NouveauChantier());

            await Navigation.PushModalAsync(detailPage, true);
        }

        protected async void Delete_Item(object sender, EventArgs eventArgs)
        {
            if (!(sender is MenuItem menuItem))
                return;

            if (!(menuItem.CommandParameter is Chantier toDoItem))
                return;

            var success = await MongoService.DeleteChantier(toDoItem);

            if (success)
            {
                ToDoItems.Remove(toDoItem);
            }
        }
    }
}
