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

            string foo;
            foreach (Candidate candidate in CandidateList.candidates)
            {
                if (candidate.experience.Count > 0)
                {
                    foo = candidate.experience[0].technologyId;
                    SelectedIds.AddId(candidate.candidateId);
                }
            }
            foo = "This is The End";
        }
    }
}
