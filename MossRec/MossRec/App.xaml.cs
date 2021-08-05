using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MossRec.Models;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MossRec
{
    /*
     * Idea:
     * 1. Create a list of candidates
     * 2. Create a list of experiences
     * 3. Create a list of criteria
     * 4. Create a list of technologies
     * 5. Show a View with a multiselectable ListView of all technologies with a field for yearsOfExperience
     *  - Create a list of criteria out of the selected technologies and yearsOfExperience
     * 6. Go through the list of candidates, check if their experiences match the list of criteria, and if so put a true in selected
     * 7. Show a View for 1 record of a candidate 
     *  - It'll show 1 by 1 
     * 
     */
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
