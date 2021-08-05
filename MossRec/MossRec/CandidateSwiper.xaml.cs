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
            // 2. If there are no more candidates, go to next Page.
            // 3. Load next Candidate data on the Form.
            InitializeComponent();
       }


    }
}