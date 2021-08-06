using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MossRec.Models;

namespace MossRec
{
    // Show a list of the static CandidateList.
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedCandidatesPage : ContentPage
    {
        public SelectedCandidatesPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            lviwChosenList.ItemsSource = CandidateList.candidates;
        }
    }
}