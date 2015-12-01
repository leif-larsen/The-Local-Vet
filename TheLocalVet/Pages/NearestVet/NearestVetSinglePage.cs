using System;
using TheLocalVet.Models;
using TheLocalVet.ViewModels;
using Xamarin.Forms;
using TheLocalVet.Languages;

namespace TheLocalVet.Pages.NearestVet
{
	public class NearestVetSinglePage : ContentPage
    {
        public NearestVetSinglePage(VetModel vetModel)
        {
            this.BindingContext = new NearestVetSingleViewModel(vetModel);
            NavigationPage.SetHasNavigationBar(this, true);
            NavigationPage.SetHasBackButton(this, true);     

            InitGui();
        }

        private void InitGui()
        {
			TextCell nameCell = new TextCell();
			nameCell.SetBinding(TextCell.TextProperty, "Name");

            TextCell addressCell = new TextCell { Text = AppResources.NearestVetSinglePageAddress };
            addressCell.SetBinding(TextCell.DetailProperty, "Address");

            //TextCell distanceCell = new TextCell { Text = AppResources.Distance };
            //distanceCell.SetBinding(TextCell.DetailProperty, "Distance");

            TextCell phoneCell = new TextCell { Text = AppResources.Phone };
            phoneCell.SetBinding(TextCell.DetailProperty, "Phone");
            phoneCell.SetBinding(TextCell.CommandProperty, "CallVetCommand");

            TextCell emailCell = new TextCell { Text = AppResources.Email };
            emailCell.SetBinding(TextCell.DetailProperty, "Email");
            emailCell.SetBinding(TextCell.CommandProperty, "EmailVetCommand");

            TextCell websiteCell = new TextCell { Text = AppResources.Website };
            websiteCell.SetBinding(TextCell.DetailProperty, "Website");
            websiteCell.SetBinding(TextCell.CommandProperty, "VisitWebCommand");

            TextCell competencyCell = new TextCell { Text = AppResources.NearestVetSinglePageCompetency };
            competencyCell.SetBinding(TextCell.DetailProperty, "CompetencyString");

            //Label openingHoursLabel = new Label { Text = AppResources.NearestVetSinglePageOpeningHours };
            //Editor openingHoursEditor = new Editor();
            //openingHoursEditor.SetBinding(Editor.TextProperty, "OpeningHours");

            //TextCell expertiseCell = new TextCell { Text = AppResources.NearestVetSinglePageExpertise };
            //expertiseCell.SetBinding(TextCell.DetailProperty, "Expertise");

            TextCell homevisitCell = new TextCell { Text = AppResources.NearestVetSinglePageHomeVisit };
            homevisitCell.SetBinding(TextCell.DetailProperty, "HomeVisit");

            TextCell viewInMapCell = new TextCell { Text = AppResources.ViewInMap };
            viewInMapCell.SetBinding(TextCell.CommandProperty, "ViewInMapCommand");

            TableView table = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot(AppResources.NearestVetSinglePageTitle)
                {
                    new TableSection()
                    {
                        nameCell,
                        addressCell,
                        //distanceCell,
                        phoneCell,
                        emailCell,
                        websiteCell,
                        competencyCell,
                        //expertiseCell,
                        homevisitCell,
                    },
                    new TableSection()
                    {
                        viewInMapCell,
                    },
                }
            };

            //StackLayout openingHourStack = new StackLayout { Children = { openingHoursLabel, openingHoursEditor } };
            StackLayout contentStack = new StackLayout { Children = { table } };
            Content = new ScrollView { Content = contentStack };
        }
    }
}
