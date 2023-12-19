using DevExpress.CodeParser;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using Proje_Management.Module.BusinessObjects.projectDocuments;
using System.Net.WebSockets;
using static System.Net.Mime.MediaTypeNames;

public enum ProjectStatus
{
    [ImageName("State_Validation")]
    OnayBekliyor,
    [ImageName("State_Task_Executing")]
    DevamEdiyor,
    [ImageName("State_Task_Completed")]
    Tamamlandi,
    // Diğer durumlar buraya eklenebilir
}

// Parasal Getiri Tipi Enum
public enum FinancialReturnType
{
    Gunluk,
    Aylik,
    Yillik
}

public enum ProjectType
{
    Yurtdışı, Tübitak, Kobi
}

namespace Proje_Management.Module.BusinessObjects.Project
{
    [DefaultClassOptions]
    [ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    [Persistent("DatabaseTableProjects")]
    [Appearance("RedProjectObject", AppearanceItemType = "ViewItem", TargetItems = "*", Criteria = "projectEndDate <  LocalDateTimeToday() AND ProjectStatus != 'Tamamlandi'", Context = "ListView", BackColor = "Red")]
    [Appearance("GreenProjectObject", AppearanceItemType = "ViewItem", TargetItems = "*", Criteria = "ProjectStatus == 'Tamamlandi'", Context = "ListView", BackColor = "Green")]
    [Appearance("OrangeProjectObject", AppearanceItemType = "ViewItem", TargetItems = "*", Criteria = " projectEndDate >  LocalDateTimeToday() AND ProjectStatus == 'DevamEdiyor'", Context = "ListView", BackColor = "Orange")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Proje : XPObject
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

        private string projectNumber;
        [Size(10)] // Maksimum 10 karakter
        [RuleRegularExpression(DefaultContexts.Save, @"^\d{1,10}$", CustomMessageTemplate = "Lütfen sadece rakam girin")]
        public string ProjectNumber
        {
            get => projectNumber;
            set => SetPropertyValue(nameof(ProjectNumber), ref projectNumber, "PRJ" + value);
        }


        private ProjectManager.ProjectManager yonetici;

        [Association("Project-ProjectManager")]
        public ProjectManager.ProjectManager ProjectManager
        {
            get => yonetici;
            set => SetPropertyValue(nameof(ProjectManager), ref yonetici, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Aim
        {
            get => aim;
            set => SetPropertyValue(nameof(Aim), ref aim, value);
        }

        [Size(15)]
        public string ProblemContext
        {
            get => problemContext;
            set => SetPropertyValue(nameof(ProblemContext), ref problemContext, value);
        }
        
        [Size(15)]
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
            set =>
            
                SetPropertyValue(nameof(ProjectStartDate), ref projectStartDate, value);
            
        }

       public DateTime ProjectEndDate { get => projectEndDate;
            set {
                if(value <= projectStartDate)
                {
                    throw new ArgumentException("Proje bitiş tarihi minimum değerden küçük olamaz.");
                }
                SetPropertyValue(nameof(ProjectEndDate), ref projectEndDate, value);
            }
            
        }

        public System.DateTime EstimatedStartDate
        {
            get => estimatedStartDate;
            set => SetPropertyValue(nameof(EstimatedStartDate), ref estimatedStartDate, value);




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
        
        private decimal financialReturn;
        public decimal FinancialReturn
        {
            get => financialReturn;
            set => SetPropertyValue(nameof(FinancialReturn), ref financialReturn, value);
        }

        // Parasal Getiri Tipi
        private FinancialReturnType financialReturnType;
        public FinancialReturnType FinancialReturnType
        {
            get => financialReturnType;
            set => SetPropertyValue(nameof(FinancialReturnType), ref financialReturnType, value);
        }
        private ProjectStatus projectStatus;
        public ProjectStatus ProjectStatus
        {
            get => projectStatus;
            set => SetPropertyValue(nameof(ProjectStatus), ref projectStatus, value);
        }
       
        private ProjectType projectType;

        public ProjectType ProjectType
        {
            get => projectType;
            set => SetPropertyValue(nameof(ProjectType), ref projectType, value);
        }



    }


}



