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
        public static List<Criteria> criterias { get; set; }
        static CriteriaList()
        {
            Criteria criteria = new Criteria();
            foreach(Technology Tec in TechnologyList.technologies)
            {
                criteria.TechnlogyName = Tec.name;
                criteria.TecnologyId = Tec.guid;
                criteria.YearsOfExperience = 0;
                criterias.Add(criteria);
            }
        }
    }
}
