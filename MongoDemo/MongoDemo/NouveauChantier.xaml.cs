using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MongoDemo
{
	public partial class NouveauChantier : ContentPage
	{

        public NouveauChantier()
        {
            InitializeComponent();
        }

        protected async void Cancel_Clicked(object sender, EventArgs eventArgs)
        {
            await Navigation.PopModalAsync(true);
        }

        protected async void Save_Clicked(object sender, EventArgs eventArgs)
        {
            var location = locationCell.Text;
            var owner = ownerCell.Text;
            var beginDate = beginDateCell.Text;
            var refChantier = refChantierCell.Text;

            if (string.IsNullOrEmpty(location) || string.IsNullOrEmpty(owner) || string.IsNullOrEmpty(beginDate))
                return;

            var newToDo = new Chantier { Location = location, ReferenceChantier = refChantier, Owner = owner, BeginDate = beginDate };

            await MongoService.InsertChantier(newToDo);

            await Navigation.PopModalAsync(true);
        }
    }
}