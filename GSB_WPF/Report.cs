using System;
using System.Collections.Generic;
using System.Text;

namespace GSB_WPF
{
    class Report
    {
        private string idVisitor;
        private string idReport;
        private string idPractitioner;
        private string visiteDate;

        public Report(string idVisitor, string idReport, string idPractitioner, string visiteDate)
        {
            this.idVisitor = idVisitor;
            this.idReport = idReport;
            this.idPractitioner = idPractitioner;
            this.visiteDate = visiteDate;
        }

        public Report(){}

        public string IdVisitor { get => idVisitor; set => idVisitor = value; }
        public string IdReport { get => idReport; set => idReport = value; }
        public string IdPractitioner { get => idPractitioner; set => idPractitioner = value; }
        public string VisiteDate { get => visiteDate; set => visiteDate = value; }
    }
}
