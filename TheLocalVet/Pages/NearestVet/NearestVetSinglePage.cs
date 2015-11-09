using System;
using TheLocalVet.Languages;
using TheLocalVet.Models;
using TheLocalVet.ViewModels;
using Xamarin.Forms;

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
            TextCell nameCell = new TextCell { Text = AppResources.NearestVetSinglePageName };
            nameCell.SetBinding(TextCell.DetailProperty, "Name");

            TextCell addressCell = new TextCell { Text = AppResources.NearestVetSinglePageAddress };
            addressCell.SetBinding(TextCell.DetailProperty, "Address");

            TextCell distanceCell = new TextCell { Text = AppResources.Distance };
            distanceCell.SetBinding(TextCell.DetailProperty, "Distance");

            TextCell phoneCell = new TextCell { Text = AppResources.Phone };
            phoneCell.SetBinding(TextCell.DetailProperty, "Phone");

            TextCell emailCell = new TextCell { Text = AppResources.Email };
            emailCell.SetBinding(TextCell.DetailProperty, "Email");

            TextCell websiteCell = new TextCell { Text = AppResources.Website };
            websiteCell.SetBinding(TextCell.DetailProperty, "Website");

            TextCell openingHoursCell = new TextCell { Text = AppResources.NearestVetSinglePageOpeningHours };
            openingHoursCell.SetBinding(TextCell.DetailProperty, "OpeningHours");

            TextCell competencyCell = new TextCell { Text = AppResources.NearestVetSinglePageCompetency };
            competencyCell.SetBinding(TextCell.DetailProperty, "CompetencyString");

            TextCell expertiseCell = new TextCell { Text = AppResources.NearestVetSinglePageExpertise };
            expertiseCell.SetBinding(TextCell.DetailProperty, "Expertise");

            TextCell homevisitCell = new TextCell { Text = AppResources.NearestVetSinglePageHomeVisit };
            homevisitCell.SetBinding(TextCell.DetailProperty, "HomeVisit");

            TableView table = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot(AppResources.NearestVetSinglePageTitle)
                {
                    new TableSection()
                    {
                        nameCell,
                        addressCell,
                        distanceCell,
                        phoneCell,
                        emailCell,
                        websiteCell,
                        openingHoursCell,
                        competencyCell,
                        expertiseCell,
                        homevisitCell,
                    }
                }
            };

            StackLayout contentStack = new StackLayout { Children = { table } };
            Content = new ScrollView { Content = contentStack };
        }
    }
}
