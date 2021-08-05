using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MossRec.Models;

namespace MossRec
{
    // First page, where Mossad recruiter selects the criteria for filtering candidates
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            lviwCriteria.ItemsSource = CriteriaList.criterias;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var index = CriteriaList.criterias.FindIndex(c => c.TechnlogyName == lblTechnologyName.Text);
            CriteriaList.criterias[index].YearsOfExperience = Int32.Parse(txtYears.Text);
            Navigation.PushAsync(new MainPage());
            this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 2]);
        }

        private void lviwCriteria_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Criteria selectedCriteria = (Criteria)lviwCriteria.SelectedItem;
            lblTechnologyName.Text = selectedCriteria.TechnlogyName;
            lblTechnologyName.IsVisible = true;
            txtYears.IsVisible = true;
            lblYrs.IsVisible = true;
            cmdOk.IsVisible = true;
        }

        private void CmdNext_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CandidateSwiper());
        }
    }
}
