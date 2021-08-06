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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CandidateSwiper : ContentPage
    {
        protected int intCandidateIndex = new int();
        protected Candidate CurrentCandidate = new Candidate();
        public CandidateSwiper()
        {
            // List of selected criteria
            List<Criteria> SelectedCriteria = CriteriaList.criterias.Where(c => c.YearsOfExperience > 0).ToList();
            // Filter CandidateList --  actually Candidates' Id's.
            //Candidate candidate = new Candidate();
            foreach (Candidate Cand in CandidateList.candidates)
            {
                int intCriteriaCount = 0;
                int intExperienceCount = 0;
                foreach (Criteria Cri in SelectedCriteria)
                {
                    foreach (Experience Exp in Cand.experience)
                    {
                        // Check if there's no match
                        if ((Cri.TecnologyId == Exp.technologyId) && (Exp.yearsOfExperience >= Cri.YearsOfExperience))
                        {
                            intExperienceCount++;
                        }
                    }
                    intCriteriaCount++;
                }
                if (intCriteriaCount != intExperienceCount)
                {
                    CandidateList.MarkForDeletion(Cand);
                }
            }
            // Delete all Candidates marked for deletion
            CandidateList.candidates.RemoveAll(c => c.barcode == "Bórrame2021");
            // Now static CandidateList.candidates has the Candidates that matches de criterias.
            // 
            // The first Candidate will be used as datasource for the Form of this Page.
            // The form detects swipes.
            // On each swipe it will do:
            // 1. If it was to the right -> Remove the Candidate from list.
            // 2. If there are no more candidates, go to next Page (SelectedCandidatesPage).
            // 3. Load next Candidate data on the Form.
            InitializeComponent();
       }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            lblMessage.Text = "Total of selected candidates: " + CandidateList.candidates.Count.ToString();
            intCandidateIndex = 0;
            imgPhoto.Source = CandidateList.candidates[intCandidateIndex].profilePicture;
            CurrentCandidate = CandidateList.candidates[intCandidateIndex];
            lblMessage.Text = "(" + (intCandidateIndex+1).ToString() + "/" + CandidateList.candidates.Count.ToString() + ")" + CurrentCandidate.firstName + "?";
        }

        private void cmdChosenList_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SelectedCandidatesPage());
            //this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 2]);
        }

        private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
        {
            switch (e.Direction)
            {
                case SwipeDirection.Left:
                    lblMessage.Text = CurrentCandidate.firstName + " : REJECTED";
                    CandidateList.MarkForDeletion(CurrentCandidate);
                    break;
                case SwipeDirection.Right:
                    lblMessage.Text = CurrentCandidate.firstName + " : ACCEPTED";
                    break;
                case SwipeDirection.Up:
                    // Handle the swipe
                    break;
                case SwipeDirection.Down:
                    // Handle the swipe
                    break;
            }
            if (intCandidateIndex < CandidateList.candidates.Count - 1)
            {
                intCandidateIndex++;
                imgPhoto.Source = CandidateList.candidates[intCandidateIndex].profilePicture;
                CurrentCandidate = CandidateList.candidates[intCandidateIndex];
                lblMessage.Text = "(" + (intCandidateIndex + 1).ToString() + "/" + CandidateList.candidates.Count.ToString() + ")" + lblMessage.Text + " || " + CurrentCandidate.firstName + "?";
            }
            else
            {
                CandidateList.candidates.RemoveAll(c => c.barcode == "Bórrame2021");
                DisplayAlert("Swipe finished", "All candidates have been seen.", "Finish");
                Navigation.PushAsync(new SelectedCandidatesPage());
            }
        }
    }
}