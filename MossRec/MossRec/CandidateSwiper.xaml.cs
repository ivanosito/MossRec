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
        public CandidateSwiper()
        {
            // List of selected criteria
            List<Criteria> SelectedCriteria = CriteriaList.criterias.Where(c => c.YearsOfExperience > 0).ToList();
            // Filter CandidateList
            Candidate candidate = new Candidate();
            foreach (Candidate Cand in CandidateList.candidates)
            {
                foreach (Criteria Cri in SelectedCriteria)
                {
                    foreach(Experience Exp in Cand.experience)
                    {
                        // Check if there's no match
                        if(Cri.TecnologyId != Exp.technologyId)   // A certaing required technolgy is not among Candidates experience
                        {
                            // Remove current Candidate from Candidatelist
                            CandidateList.RemoveCandidate(Cand);
                        } 
                        else if(Cri.YearsOfExperience > Exp.yearsOfExperience) // Candidate has a required technology. Check if years of Experience are not enough
                        {
                            // Remove current Candidate from Candidatelist
                            CandidateList.RemoveCandidate(Cand);
                        }
                    }
                }
            }
            // Now static CandidateList.candidates has the Candidates that matches de criterias.
            // 
            // The first Candidate will be used as datasource for the Form of this Page.
            // The form detects swipes.
            // On each swipe it will do:
            // 1. If it was to the right -> Remove the Candidate from list.
            // 2. If there are no more candidates, go to next Page.
            // 3. Load next Candidate data on the Form.
            InitializeComponent();
       }


    }
}