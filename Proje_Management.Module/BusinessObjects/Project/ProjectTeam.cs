using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using Proje_Management.Module.BusinessObjects.Employee;
using System;
using System.Linq;


namespace Proje_Management.Module.BusinessObjects.Project
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    [Persistent("DatabaseTableTeams")]
    

    public class ProjectTeam : XPObject
    {
        public ProjectTeam(Session session) 
            : base(session) { }

        
    
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        string teamName;

        //[RuleRequiredField("title",DefaultContexts.Save,"Lütfen doldurun")]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string TeamName
        {
            get => teamName;
            set => SetPropertyValue(nameof(TeamName), ref teamName, value);
        }
        // Takımın Projeleri
        [Association("Proje-Team")]
        public XPCollection<Proje> TeamProjects => GetCollection<Proje>(nameof(TeamProjects));

        // Takıma Bağlı Çalışanlar
        [Association("Employer-Team")]
        public XPCollection<Employer> TeamMembers => GetCollection<Employer>(nameof(TeamMembers));


    }
}