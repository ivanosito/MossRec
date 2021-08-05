using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MossRec.Models
{
    public class Criteria
    {
        public string TechnlogyName { get; set; }
        public string TecnologyId { get; set; }
        public int YearsOfExperience { get; set; }
    }

    // The list of all possible criteria
    public static class CriteriaList
    {
        private static List<Criteria> _Criterias = new List<Criteria>();
        public static List<Criteria> criterias
        {
            get { return _Criterias; }
            set { _Criterias = value; }
        }
        static CriteriaList()
        {
            foreach(Technology Tec in TechnologyList.technologies)
            {
                Criteria criteria = new Criteria();
                criteria.TechnlogyName = Tec.name;
                criteria.TecnologyId = Tec.guid;
                criteria.YearsOfExperience = 0;
                _Criterias.Add(criteria);
            }
        }
    }
}
