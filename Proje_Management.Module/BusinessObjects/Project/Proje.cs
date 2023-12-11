using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using Proje_Management.Module.BusinessObjects.projectDocuments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using static DevExpress.Data.Mask.Internal.MaskSettings<T>;

namespace Proje_Management.Module.BusinessObjects.Project
{
    [DefaultClassOptions]
    [ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    [Persistent("DatabaseTableProjects")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Proje : XPBaseObject
    { 
        public Proje(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string scope;
        string problemContext;
        string aim;
        string projeName;

        private System.DateTime projectStartDate ;
        private System.DateTime projectEndDate;
        private System.DateTime estimatedStartDate;
        private System.DateTime estimatedEndDate;
        private System.DateTime registrationDate;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ProjeName
        {
            get => projeName;
            set => SetPropertyValue(nameof(ProjeName), ref projeName, value);
        }

        [Association("Project-ProjectManager")]
        public Employee.Employer ProjectManager
        {
            get => GetPropertyValue<Employee.Employer>(nameof(ProjectManager));
            set => SetPropertyValue(nameof(ProjectManager), value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Aim
        {
            get => aim;
            set => SetPropertyValue(nameof(Aim), ref aim, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ProblemContext
        {
            get => problemContext;
            set => SetPropertyValue(nameof(ProblemContext), ref problemContext, value);
        }
        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Scope
        {
            get => scope;
            set => SetPropertyValue(nameof(Scope), ref scope, value);
        }
        public System.DateTime RegistrationDate
        {
            get => registrationDate;
            set => SetPropertyValue(nameof(RegistrationDate), ref registrationDate, value);
        }
        public System.DateTime ProjectStartDate
        {
            get => projectStartDate;
            set
            {
                if (value < System.DateTime.Today)
                {
                    throw new ArgumentException("Proje başlangıç tarihi minimum değerden küçük olamaz.");
                }
                SetPropertyValue(nameof(ProjectStartDate), ref projectStartDate, value);
            }
        }

       

        public System.DateTime EstimatedStartDate
        {
            get => estimatedStartDate;
            set 
            {
                if (value < System.DateTime.Today)
                {
                    throw new ArgumentException("Proje başlangıç tarihi minimum değerden küçük olamaz.");
                }
                SetPropertyValue(nameof(EstimatedStartDate), ref estimatedStartDate, value);
            } 
        }
        public System.DateTime EstimatedEndDate
        {
            get => estimatedEndDate;
            set => SetPropertyValue(nameof(EstimatedEndDate), ref estimatedEndDate, value);
        }
        [Association("Proje-Team")]
        public ProjectTeam TeamProject
        {
            get => GetPropertyValue<ProjectTeam>(nameof(TeamProject));
            set => SetPropertyValue(nameof(TeamProject), value);
        }
        [Association("ProjectDocs-Proje")]
        public XPCollection<ProjectDocuments> projectDocuments => GetCollection<ProjectDocuments>(nameof(projectDocuments));
    }
}


